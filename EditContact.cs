﻿using Microsoft.EntityFrameworkCore;
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

namespace TravelCompanyCore
{
    public partial class EditContact : Form
    {
        private List<Models.Role> roles; // Справочник ролей (всех)
        //internal Models.Contact? EditableContact { get; set; }
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
            //if (EditableContact != null)
            //{
            //    using (ApplicationContext db = new ApplicationContext())
            //    {
            //        // При редактировании дозаполняем контакт значениями из БД, поскольку из грида всего не перетащишь
            //        if (EditableContact.Id != Guid.Empty) EditableContact = db.Contacts.
            //                Include(c => c.Roles).ToList().Find(c => c.Id == EditableContact.Id); // благодаря инклюду прилетают и роли
            //        roles = db.Roles.ToList(); // Весь справочник ролей
            //        bool toCheckOrNotToCheck = false; // Ставить ли галочку при привязке
            //        foreach (Models.Role rl in roles) // Привязываем справочные значения к контролу...
            //        {
            //            toCheckOrNotToCheck = EditableContact.Roles.Contains(rl); // ...проверяем, есть ли такая роль у контакта...
            //            clbRoles.Items.Add(rl.Name, toCheckOrNotToCheck); // ...и добавляем роль в контрол (с галочкой, если это роль контакта)
            //        }
            //        txtFirstName.Text = EditableContact.FirstName;
            //        txtLastName.Text = EditableContact.LastName;
            //        txtPatronymicName.Text = EditableContact.PatronymicName;
            //        txtEmail.Text = EditableContact.EmailAddress;
            //        mtxtPhone.Text = EditableContact.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
            //    }
            //}
            using (ApplicationContext db = new ApplicationContext())
            {
                roles = db.Roles.ToList(); // Весь справочник ролей

                if (EditableId != null && EditableId != Guid.Empty)
                {
                    // При редактировании дозаполняем контакт значениями из БД, поскольку из грида всего не перетащишь
                    Models.Contact? EditableContact = db.Contacts.Include(c => c.Roles).ToList().Find(c => c.Id == EditableId); // благодаря инклюду прилетят и роли
                    CheckState toCheckOrNotToCheck = CheckState.Unchecked; // Ставить ли галочку при привязке
                    foreach (Models.Role rl in roles) // Привязываем справочные значения к контролу...
                    {
                        // ...проверяем, есть ли такая роль у контакта...
                        toCheckOrNotToCheck = EditableContact.Roles.Contains(rl)? toCheckOrNotToCheck = CheckState.Checked : toCheckOrNotToCheck = CheckState.Unchecked;
                        clbRoles.Items.Add(rl.Name, toCheckOrNotToCheck); // ...и добавляем роль в контрол (с галочкой, если это роль контакта)
                    }
                    txtFirstName.Text = EditableContact.FirstName;
                    txtLastName.Text = EditableContact.LastName;
                    txtPatronymicName.Text = EditableContact.PatronymicName;
                    txtEmail.Text = EditableContact.EmailAddress;
                    mtxtPhone.Text = EditableContact.PhoneNumber.Remove(0, 2); // За вычетом первых двух символов +7
                }
                else
                {
                    foreach (Models.Role rl in roles) // Привязываем справочные значения к контролу безо всяких галочек
                    {
                        clbRoles.Items.Add(rl.Name);
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

            //////if (isModelValid())
            //////{
            //////    if (EditableContact != null)
            //////    {
            //////        if (EditableContact.Id == Guid.Empty) // Создание Контакта
            //////        {
            //////            isNew = true;
            //////            EditableContact.Id = Guid.NewGuid(); // Генерим новичку Id...
            //////            EditableContact.Roles = new(); // ...и создаём ему пустое множество ролей
            //////        }
            //////        EditableContact.FirstName = txtFirstName.Text.Trim();
            //////        EditableContact.LastName = txtLastName.Text.Trim();
            //////        EditableContact.PatronymicName = txtPatronymicName.Text.Trim();
            //////        EditableContact.EmailAddress= txtEmail.Text.Trim();
            //////        EditableContact.PhoneNumber = "+7" + mtxtPhone.Text.Trim();
            //////        // Теперь роли
            //////        EditableContact.Roles.Clear(); // Удаляем все роли

            //////        using (ApplicationContext db = new ApplicationContext())
            //////        {
            //////            if (isNew) db.Contacts.Add(EditableContact); // создаём
            //////            else db.Contacts.Update(EditableContact); // редактируем
            //////            db.SaveChanges(); // сохраняемся с пустыми ролями, чтобы удалить все записи из промежуточных таблиц
            //////        }

            //////        // Попробуем отдельный контекст для связей:
            //////        using (ApplicationContext db2 = new ApplicationContext())
            //////        {
            //////            foreach (string role in clbRoles.SelectedItems) // Для каждой роли, чекнутой в списке
            //////            {
            //////                EditableContact.Roles.Add(roles.First(r => r.Name == role)); // Делаем добавление
            //////            }
            //////            db2.Contacts.Update(EditableContact); // обновляем ещё раз, чтобы добавить новые записи в промежуточную таблицу
            //////            db2.SaveChanges(); // Создание работает, редактирование без смены роли - тоже. Смена роли НЕ работает :(
            //////        }

            //////    }
            //////    this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
            //////    this.Close();
            ///

            if (isModelValid())
            {
                // Работаем сразу в конексте
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
                        //EditableContact = db.Contacts.Find(EditableId);
                        EditableContact = db.Contacts.Include(c => c.Roles).ToList().Find(c => c.Id == EditableId); // С ролями, то есть
                    }

                    EditableContact.FirstName = txtFirstName.Text.Trim();
                    EditableContact.LastName = txtLastName.Text.Trim();
                    EditableContact.PatronymicName = txtPatronymicName.Text.Trim();
                    EditableContact.EmailAddress = txtEmail.Text.Trim();
                    EditableContact.PhoneNumber = "+7" + mtxtPhone.Text.Trim();

                    foreach (string role in clbRoles.Items)
                    {
                        if (!clbRoles.CheckedItems.Contains(role)) // Если чек НЕ стоит, то роль нужно удалить. Безусловно
                            EditableContact.Roles.Remove(roles.First(r => r.Name == role));
                        else // Если чек стоит... 
                        {
                            if (!EditableContact.Roles.Exists(c => c.Name == role)) // ...то если такой роли ещё нет,
                                EditableContact.Roles.Add(roles.First(r => r.Name == role)); // её нужно добавить (и только в этом случае)
                        }
                    }

                    //foreach (string role in clbRoles.SelectedItems) // Для каждой роли, чекнутой в списке
                    //{
                    //    EditableContact.Roles.Add(roles.First(r => r.Name == role)); // Делаем добавление
                    //}

                    if (isNew) db.Contacts.Add(EditableContact); // создаём
                    else db.Contacts.Update(EditableContact); // редактируем
                    db.SaveChanges();                    
                }

                this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                this.Close();
            }
    }
    }
}
