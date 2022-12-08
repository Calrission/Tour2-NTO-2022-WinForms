using Microsoft.EntityFrameworkCore;
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
    public partial class ContactList : Form
    {
        public ContactList()
        {
            InitializeComponent();
        }

        private void ContactList_Load(object sender, EventArgs e)
        {
            dgwContacts.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид                
                dgwContacts.DataSource = db.Contacts.Where(t => t.Id != Contact.BotId).Include(c => c.Roles).ToList(); // Пахома оставляем за бортом, он не редактируемый
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
                String.Format("Вы действительно хотите удалить контакт «{0} {1} {2}»?", dgwContacts.SelectedCells[1].Value.ToString(),
                dgwContacts.SelectedCells[2].Value.ToString(),
                dgwContacts.SelectedCells[3].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Guid id2delete = (Guid)dgwContacts.SelectedCells[0].Value;
                    // Если Контакт используется к-л Клиентом или является менеджером к-л Отеля, его удалять нельзя:
                    if (db.Clients.Any(c => c.ContactId == id2delete))
                        MessageBox.Show(
                            String.Format("Контакт «{0} {1} {2}» является представителем одного или нескольких Клиентов, его нельзя удалить",
                            dgwContacts.SelectedCells[1].Value.ToString(),
                            dgwContacts.SelectedCells[2].Value.ToString(),
                            dgwContacts.SelectedCells[3].Value.ToString()));
                    else if (db.Hotels.Any(h => h.ManagerId == id2delete))
                        MessageBox.Show(
                            String.Format("Контакт «{0} {1} {2}» является менеджером одного или нескольких Отелей, его нельзя удалить",
                            dgwContacts.SelectedCells[1].Value.ToString(),
                            dgwContacts.SelectedCells[2].Value.ToString(),
                            dgwContacts.SelectedCells[3].Value.ToString()));
                    else
                    {
                        Models.Contact? contact = db.Contacts.FirstOrDefault(r => r.Id == id2delete); // Находим удаляемый объект
                        if (contact != null) // удаляем его
                        {
                            db.Contacts.Remove(contact);
                            db.SaveChanges();
                        }
                        txtSearchString.Text = string.Empty;
                        dgwContacts.DataSource = db.Contacts.Where(t => t.Id != Contact.BotId).Include(c => c.Roles).ToList(); // перепривязка
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditContact ct = new())
            {
                ct.EditableId = Guid.Empty;
                if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    txtSearchString.Text = string.Empty;
                    using (ApplicationContext db = new ApplicationContext())
                        dgwContacts.DataSource = db.Contacts.Where(t => t.Id != Contact.BotId).Include(c => c.Roles).ToList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (EditContact ct = new())
            {
                ct.EditableId = (Guid)dgwContacts.SelectedCells[0].Value;
                if (ct.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    txtSearchString.Text = string.Empty;
                    using (ApplicationContext db = new ApplicationContext())
                        dgwContacts.DataSource = db.Contacts.Where(t => t.Id != Contact.BotId).Include(c => c.Roles).ToList();
                }
            }
        }

        private void dgwContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            string text2search = txtSearchString.Text.Trim();
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!string.IsNullOrEmpty(text2search)) // Если есть что искать
                {
                    dgwContacts.DataSource = db.Contacts.Include(c => c.Roles).ToList() // Придётся так, чтобы работал IgnoreCase :(
                        .Where(t => t.Id != Contact.BotId // Отсечь Пахома
                        && (t.LastName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                        || t.FirstName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                        || t.EmailAddress.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                        ))
                        .ToList();
                }
                else
                    dgwContacts.DataSource = db.Contacts.Where(t => t.Id != Contact.BotId).Include(c => c.Roles).ToList();
            }
        }
    }
}
