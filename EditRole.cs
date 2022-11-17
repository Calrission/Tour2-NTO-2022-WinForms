using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCompanyCore
{
    public partial class EditRole : Form
    {
        internal Models.Role? EditableRole { get; set; }
        public EditRole()
        {
            InitializeComponent();
        }

        bool isModelValid()
        {
            if (txtRoleName.Text.Trim().Length < 2)
            {
                lblRoleNameValidation.Text = "Наименование роли не должно быть короче двух значащих символов";
                return false;
            }
            return true;
        }
        private void EditRole_Load(object sender, EventArgs e)
        {
            if (EditableRole != null)
            {
                txtRoleName.Text = EditableRole.Name;
                rtxtRoleDescription.Text = EditableRole.Description;
                lblRoleNameValidation.Text = String.Empty;
            }
            else lblRoleNameValidation.Text = "Форма загружена не правильно, обратитесь к Грише";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = false; // флаг редактирования

            if (isModelValid())
            {
                if (EditableRole != null)
                {
                    if (EditableRole.Id == Guid.Empty) // Создание роли
                    {
                        isNew = true;
                        EditableRole.Id = Guid.NewGuid();
                    }
                    EditableRole.Name = txtRoleName.Text;
                    EditableRole.Description = rtxtRoleDescription.Text;

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        if (isNew) db.Roles.Add(EditableRole); // создаём
                        else db.Roles.Update(EditableRole); // редактируем
                        db.SaveChanges();
                    }
                }
                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
        }
    }
}
