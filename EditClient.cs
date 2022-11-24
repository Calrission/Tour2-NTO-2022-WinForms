using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            using (ApplicationContext db = new ApplicationContext())
            {
                comboxClientType.DataSource = db.TypesClient.ToList();
                if (EditableId != Guid.Empty)
                {
                    Client client = db.Clients.Find(EditableId);
                    comboxClientType.SelectedValue = client.ClientTypeId; // В результате должен запуститься обработчик comboxClientType_SelectedValueChanged
                    txtName.Text = client.Name;
                    comboContact.SelectedValue = client.ContactId;
                    if (client.PhoneNumber.Length > 1) mtxtPhone.Text = client.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
                }
            }
        }

        bool isModelValid()
        {
            if (txtName.Text.Trim().Length == 0)
                return false;
            if ((Guid)comboxClientType.SelectedValue == ClientType.IndividualId)
            {
                if (string.IsNullOrEmpty(mtxtPhone.Text.Trim()) || !phone_validation().IsMatch(mtxtPhone.Text.Trim()))
                    return false;
            }

            if (comboContact.SelectedItem == null)
                return false;
            return true;
        }

        private static Regex phone_validation()
        {
            string pattern = @"^\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isModelValid())
            {
                bool IsNew = EditableId == Guid.Empty;

                using (ApplicationContext db = new ApplicationContext())
                {
                    Client client = new();
                    if (!IsNew)
                        client = db.Clients.Find(EditableId);
                    client.Name = txtName.Text.Trim();
                    client.ClientTypeId = (Guid)comboxClientType.SelectedValue;
                    client.ContactId = (Guid)comboContact.SelectedValue; // Ибо выбора в случае физика всё равно не будет
                    if (client.ClientTypeId == ClientType.IndividualId)
                        client.PhoneNumber = "+7" + mtxtPhone.Text.Trim(); // У физика обязательно должен быть телефон                    

                    if (IsNew)
                    {
                        client.Id = Guid.NewGuid();
                        db.Clients.Add(client); // создаём
                    }
                    else db.Clients.Update(client); // редактируем
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
            using (ApplicationContext db = new ApplicationContext())
            {
                if ((Guid)comboxClientType.SelectedValue == ClientType.EntityId)
                {
                    // Нас интересует только Контакты с ролью "Контакт клиента" за исключением Бота Пахома
                    Role ClientContactRole = db.Roles.FirstOrDefault(r => r.Id == Role.ClientContactId);
                    comboContact.DataSource = db.Contacts.Include(c => c.Roles).Where(t => t.Id != Contact.BotId && t.Roles.Contains(ClientContactRole)).ToList();

                    comboContact.Enabled = true;
                    lblContactText.Text = "Контактное лицо";
                    comboContact.Visible = true;
                    mtxtPhone.Visible = false;
                    mtxtPhone.CausesValidation = false;
                    lbl7.Visible = false;
                }
                else if ((Guid)comboxClientType.SelectedValue == ClientType.IndividualId)
                {
                    comboContact.DataSource = db.Contacts.ToList().FindAll(t => t.Id == Contact.BotId);
                    comboContact.Enabled = false;
                    lblContactText.Text = "Контактный телефон";
                    comboContact.Visible = false;
                    mtxtPhone.Visible = true;
                    mtxtPhone.CausesValidation = true;
                    lbl7.Visible = true;
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 1)
                errorProvider1.SetError(txtName, "Наименование не должно быть пустым !");
            else
                errorProvider1.Clear();
        }

        private void mtxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(mtxtPhone.Text.Trim()))
                errorProvider1.SetError(mtxtPhone, "Не указан Телефон!");
            else if (!phone_validation().IsMatch(mtxtPhone.Text.Trim()))
                errorProvider1.SetError(mtxtPhone, "Номер телефона не соответствует формату!");
            else
                errorProvider1.Clear();
        }

        private void comboContact_Validating(object sender, CancelEventArgs e)
        {
            if (comboContact.SelectedItem == null)
                errorProvider1.SetError(comboContact, "Выберите (при необходимости создайте) Контакт!");
            else
                errorProvider1.Clear();
        }
    }
}
