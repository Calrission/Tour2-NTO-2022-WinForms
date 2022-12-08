using Microsoft.EntityFrameworkCore;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class ClientList : Form
    {
        public ClientList()
        {
            InitializeComponent();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            dgwClients.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                comboxClientType.DataSource = db.ClientTypes.ToList().Prepend(new ClientType { Id = Guid.Empty, Name = "Все" }).ToList();
                dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (EditClient ec = new())
            {
                ec.EditableId = (Guid)dgwClients.SelectedCells[0].Value;
                if (ec.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditClient ec = new())
            {
                ec.EditableId = Guid.Empty;
                if (ec.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить клиента «{0}»?", dgwClients.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Guid id2delete = (Guid)dgwClients.SelectedCells[0].Value;
                    // Если Клиент имеет заказы, его удалять нельзя:
                    if (db.TourOrders.Any(to => to.ClientId == id2delete))
                        MessageBox.Show(String.Format("Клиент «{0}» сделал один или несколько Заказов, его нельзя удалить", dgwClients.SelectedCells[1].Value.ToString()));
                    else
                    {
                        Models.Client? client = db.Clients.FirstOrDefault(r => r.Id == id2delete); // Находим удаляемый объект
                        if (client != null) // удаляем его
                        {
                            db.Clients.Remove(client);
                            db.SaveChanges();
                        }
                        dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList(); // перепривязка
                    }
                }
            }
        }

        private void dgwClients_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwClients.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void dgwClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            string text2search = txtSearchString.Text.Trim();

            using (ApplicationContext db = new ApplicationContext())
            {
                if (!string.IsNullOrEmpty(text2search)) // фильтруем по тексту
                {
                    if ((Guid)comboxClientType.SelectedValue != Guid.Empty) // И по типу
                    {
                        dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList() // Придётся так, чтобы работал IgnoreCase :(
                            .Where(
                            t => (t.Name.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            || t.Contact.FirstName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            || t.Contact.LastName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            )
                            && t.ClientTypeId == (Guid)comboxClientType.SelectedValue)
                            .ToList();
                    }
                    else // или без типа
                    {
                        dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList() // Придётся так, чтобы работал IgnoreCase :(
                            .Where(
                            t => t.Name.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            || t.Contact.FirstName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            || t.Contact.LastName.Contains(text2search, StringComparison.InvariantCultureIgnoreCase)
                            ).ToList();
                    }
                }
                else if ((Guid)comboxClientType.SelectedValue != Guid.Empty) // Только по типу
                    dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType)
                        .Where(t => t.ClientTypeId == (Guid)comboxClientType.SelectedValue)
                        .ToList();
                else // Вообще не фильтруем
                    dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList();
            }
        }
    }
}
