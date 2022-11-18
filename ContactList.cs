﻿using System;
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
    public partial class ContactList : Form
    {
        public ContactList()
        {
            InitializeComponent();
        }

        private void ContactList_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwContacts.DataSource = db.Contacts.ToList();
            }
        }

        private void dgwContacts_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwContacts.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить контакт «{1} {0} {2}»?", dgwContacts.SelectedCells[1].Value.ToString(),
                dgwContacts.SelectedCells[2].Value.ToString(),
                dgwContacts.SelectedCells[3].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Models.Contact? contact = db.Contacts.FirstOrDefault(r => r.Id == (Guid)dgwContacts.SelectedCells[0].Value); // Находим удаляемый объект
                    if (contact != null) // удаляем его
                    {
                        db.Contacts.Remove(contact);
                        db.SaveChanges();
                    }
                    dgwContacts.DataSource = db.Contacts.ToList(); // перепривязка
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //using (EditContact ct = new())
            //{
            //    ct.EditableContact = new();
            //    ct.EditableContact.Id = Guid.Empty; // Признак того, что регион создаётся, а не редактируется
            //    ct.EditableContact.FirstName = String.Empty;
            //    ct.EditableContact.LastName= String.Empty;
            //    ct.EditableContact.PatronymicName= String.Empty;
            //    ct.EditableContact.PhoneNumber = "+7";
            //    ct.EditableContact.EmailAddress= String.Empty;
            //    ct.EditableContact.Roles = new();

            //    if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
            //    {
            //        using (ApplicationContext db = new ApplicationContext())
            //            dgwContacts.DataSource = db.Contacts.ToList();
            //    }
            //}
            using (EditContact ct = new())
            {
                ct.EditableId = Guid.Empty;
                if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwContacts.DataSource = db.Contacts.ToList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //using (EditContact ct = new())
            //{
            //    ct.EditableContact = new();
            //    ct.EditableContact.Id = (Guid)dgwContacts.SelectedCells[0].Value; // Существующий Id - признак того, что регион редактируется

            //    if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
            //    {
            //        using (ApplicationContext db = new ApplicationContext())
            //            dgwContacts.DataSource = db.Contacts.ToList();
            //    }
            //}

            using (EditContact ct = new())
            {
                ct.EditableId= (Guid)dgwContacts.SelectedCells[0].Value;
                if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwContacts.DataSource = db.Contacts.ToList();
                }
            }
        }

        private void dgwContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }
    }
}
