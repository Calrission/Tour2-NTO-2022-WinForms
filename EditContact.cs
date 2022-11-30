using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public partial class EditContact : Form
    {
        List<Role>rls=new List<Role>(); // Здесь бесссылочно будет храниться строковый список имен ролей в системе
        public Guid? EditableId { get; set; }

        public EditContact()
        {
            InitializeComponent();
        }
        bool isModelValid()
        {
            if (String.IsNullOrEmpty(txtLastName.Text.Trim()) || txtLastName.Text.Trim().Length < 2)
                return false;
            if (String.IsNullOrEmpty(txtFirstName.Text.Trim()) || txtFirstName.Text.Trim().Length < 2)
                return false;
            if (String.IsNullOrEmpty(txtEmail.Text.Trim()) || !email_validation().IsMatch(txtEmail.Text.Trim()))
                return false;
            if (String.IsNullOrEmpty(mtxtPhone.Text.Trim()) || !phone_validation().IsMatch(mtxtPhone.Text.Trim()))
                return false;
            if (clbRoles.CheckedItems.Count == 0)
                return false;
            return true;
        }
        private void EditContact_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                rls=db.Roles.ToList();

                if (EditableId != null && EditableId != Guid.Empty)
                {
                    // При редактировании дозаполняем контакт значениями из БД, поскольку из грида всего не перетащишь
                    Models.Contact? EditableContact = db.Contacts.Include(c => c.Roles).ToList().Find(c => c.Id == EditableId); // благодаря инклюду прилетят и роли
                    CheckState toCheckOrNotToCheck = CheckState.Unchecked; // Ставить ли галочку при привязке
                    foreach (Role rl in rls) // Привязываем справочные значения к контролу...
                    {
                        // ...проверяем, есть ли такая роль у контакта...
                        toCheckOrNotToCheck = EditableContact.Roles.Exists(r => r == rl) ? toCheckOrNotToCheck = CheckState.Checked : toCheckOrNotToCheck = CheckState.Unchecked;
                        clbRoles.Items.Add(rl, toCheckOrNotToCheck); // ...и добавляем роль в контрол (с галочкой, если это роль контакта)
                    }
                    txtFirstName.Text = EditableContact.FirstName;
                    txtLastName.Text = EditableContact.LastName;
                    txtPatronymicName.Text = EditableContact.PatronymicName;
                    txtEmail.Text = EditableContact.EmailAddress;
                    mtxtPhone.Text = EditableContact.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
                }
                else
                {
                    foreach (Role rl in rls) // Привязываем справочные значения к контролу безо всяких галочек
                    {
                        clbRoles.Items.Add(rl);
                    }
                }
            }
        }

        #region Валидация при вводе
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
                errorProvider1.SetError(txtEmail, "Не указан Email!");
            else if (!email_validation().IsMatch(txtEmail.Text.Trim()))
                errorProvider1.SetError(txtEmail, "Неверный формат Email!");
            else
                errorProvider1.Clear();
        }

        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private static Regex phone_validation()
        {
            string pattern = @"^\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLastName.Text.Trim()))
                errorProvider1.SetError(txtLastName, "Не указана Фамилия!");
            else if (txtLastName.Text.Trim().Length < 2)
                errorProvider1.SetError(txtLastName, "Фамилия не должна быть короче двух значащих символов!");
            else
                errorProvider1.Clear();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstName.Text.Trim()))
                errorProvider1.SetError(txtFirstName, "Не указано Имя!");
            else if (txtFirstName.Text.Trim().Length < 2)
                errorProvider1.SetError(txtFirstName, "Имя не должно быть короче двух значащих символов!");
            else
                errorProvider1.Clear();
        }

        private void txtPatronymicName_Validating(object sender, CancelEventArgs e) // Отчества может и не быть...
        {
            //if (String.IsNullOrEmpty(txtPatronymicName.Text.Trim()))
            //    errorProvider1.SetError(txtPatronymicName, "Не указано Отчество!");
            //else if (txtPatronymicName.Text.Trim().Length < 2)
            //    errorProvider1.SetError(txtPatronymicName, "Отчество не должно быть короче двух значащих символов!");
            //else
            //    errorProvider1.Clear();
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

        private void clbRoles_Validating(object sender, CancelEventArgs e)
        {
            if (clbRoles.CheckedItems.Count == 0)
                errorProvider1.SetError(clbRoles, "Укажите хотя бы одну роль для контакта!");
            else
                errorProvider1.Clear();
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isNew = false; // флаг редактирования

            if (isModelValid())
            {
                // Работаем сразу в контексте
                using (ApplicationContext db = new ApplicationContext())
                {
                    Models.Contact EditableContact = new();
                    if (EditableId == Guid.Empty) // Создание Контакта
                    {
                        isNew = true;
                        EditableContact.Id = Guid.NewGuid(); // Генерим новичку Id...
                        EditableContact.Roles = new(); // ...и создаём ему пустое множество ролей
                    }
                    else // Редактирование Контакта
                    {
                        EditableContact = db.Contacts.Include(c => c.Roles).ToList().Find(c => c.Id == EditableId); // С ролями, то есть
                    }

                    EditableContact.FirstName = txtFirstName.Text.Trim();
                    EditableContact.LastName = txtLastName.Text.Trim();
                    EditableContact.PatronymicName = txtPatronymicName.Text.Trim();
                    EditableContact.EmailAddress = txtEmail.Text.Trim();
                    EditableContact.PhoneNumber = "+7" + mtxtPhone.Text.Trim();

                    foreach (Role rl in rls)
                    {
                        if (!clbRoles.CheckedItems.Contains(rl)) // Если чек НЕ стоит, то роль нужно удалить. Безусловно
                        {
                            // Нет, не безусловно!
                            // Удалить роль менеджера можно только если Контакт НЕ является менеджером какого-либо Отеля:
                            if (rl.Id == Models.Role.ManagerId
                                && !db.Hotels.Any(h => h.ManagerId == EditableContact.Id))
                            {
                                EditableContact.Roles.Remove(db.Roles.FirstOrDefault(r => r == rl));
                            }
                            // Аналогично роль Контакта клиента можно удалить только если Контакт НЕ является представителем какого-либо Клиента:
                            if (rl.Id == Models.Role.ClientContactId
                                && !db.Clients.Any(c => c.ContactId == EditableContact.Id))
                            {
                                EditableContact.Roles.Remove(db.Roles.FirstOrDefault(r => r == rl));
                            }
                        }
                        else // Если чек стоит... 
                        {
                            if (!EditableContact.Roles.Exists(c => c == rl)) // ...то если такой роли у Контакта до сих пор не было,
                                EditableContact.Roles.Add(db.Roles.FirstOrDefault(r => r == rl)); // её нужно добавить (и только в этом случае)
                        }
                    }

                    if (isNew) db.Contacts.Add(EditableContact); // создаём
                    else db.Contacts.Update(EditableContact); // редактируем
                    db.SaveChanges();                    
                }

                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
    }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
