using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class EditClient : Form
    {

        public Guid EditableId { get; set; }

        public EditClient()
        {
            InitializeComponent();
        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                comboxClientType.DataSource = db.TypesClient.ToList();
                comboContact.DataSource = db.Contacts.ToList();

                if (EditableId != Guid.Empty)
                {
                    var client = db.Clients.Find(EditableId);
                    comboxClientType.SelectedValue = client.ClientTypeId;
                    comboContact.SelectedValue = client.ContactId;
                    txtName.Text = client.Name;
                }
            }
        }

        bool isModelValid()
        {
            if (txtName.Text.Trim().Length == 0)
                return false;
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isModelValid() )
            {
                bool IsNew = EditableId == Guid.Empty;

                using(ApplicationContext db = new ApplicationContext())
                {
                    var Client = new Client { };
                    if (!IsNew) { Client = db.Clients.Find(EditableId); }

                    Client.Name = txtName.Text;
                    if (comboContact.Enabled) 
                        Client.ContactId = (Guid) comboContact.SelectedValue;
                    else Client.ContactId = Guid.Parse("242B1D5F-9103-474A-AEC4-F9143E87D58A");
                    Client.ClientTypeId = (Guid) comboxClientType.SelectedValue;

                    if (IsNew)
                    {
                        Client.Id = Guid.NewGuid();
                        db.Clients.Add(Client); // создаём
                    }
                    else db.Clients.Update(Client); // редактируем
                    db.SaveChanges();

                    this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void comboxClientType_SelectedValueChanged(object sender, EventArgs e)
        {
            comboContact.Enabled = (Guid)comboxClientType.SelectedValue != Guid.Parse("cd3b7458-6f73-49c3-a56b-af81101cc3cd");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 00)
                errorProvider1.SetError(txtName, "Наименование не должно быть пустым !");
            else
                errorProvider1.Clear();
        }
    }
}
