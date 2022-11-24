using Microsoft.EntityFrameworkCore;

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
                    Models.Client? client = db.Clients.FirstOrDefault(r => r.Id == (Guid)dgwClients.SelectedCells[0].Value); // Находим удаляемый объект
                    if (client != null) // удаляем его
                    {
                        db.Clients.Remove(client);
                        db.SaveChanges();
                    }
                    dgwClients.DataSource = db.Clients.Include(t => t.Contact).Include(t => t.ClientType).ToList(); // перепривязка
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
    }
}
