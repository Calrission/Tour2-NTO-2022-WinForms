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

namespace TravelCompanyCore
{
    public partial class EditContact : Form
    {
        internal Models.Contact? EditableContact { get; set; }
        public EditContact()
        {
            InitializeComponent();
        }
        bool isModelValid()
        {
            if (txtFirstName.Text.Trim().Length < 2)
            {
                //lblFirstNameValidation.Text = "Наименование роли не должно быть короче двух значащих символов";
                return false;
            }
            return true;
        }
        private void EditContact_Load(object sender, EventArgs e)
        {
            if (EditableContact != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // При редактировании дозаполняем контакт значениями из БД, поскольку из грида всего не перетащишь
                    if (EditableContact.Id != Guid.Empty) EditableContact = db.Contacts.Find(EditableContact.Id); // не факт, что роли так тоже прилетят
                    List<Models.Role> roles = db.Roles.ToList(); // Весь справочник ролей
                    bool toCheckOrNotToCheck = false; // Ставить ли галочку при привязке
                    foreach (Models.Role rl in roles) // Привязываем справочные значения к контролу...
                    {
                        toCheckOrNotToCheck = EditableContact.Roles.Contains(rl); // ...проверяем, есть ли такая роль у контакта...
                        clbRoles.Items.Add(rl.Name, toCheckOrNotToCheck); // ...и добавляем роль в контрол (с галочкой, если это роль контакта)
                    }
                    txtFirstName.Text = EditableContact.FirstName;
                    txtLastName.Text = EditableContact.LastName;
                    txtPatronymicName.Text = EditableContact.PatronymicName;
                    txtEmail.Text = EditableContact.EmailAddress;
                    mtxtPhone.Text = EditableContact.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
                    //lblRoleNameValidation.Text = String.Empty;
                }
            }
            //else lblRoleNameValidation.Text = "Форма загружена не правильно, обратитесь к Грише";
        }
    }
}
