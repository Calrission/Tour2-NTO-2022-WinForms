namespace TravelCompanyCore
{
    public partial class RoleList : Form
    {
        public RoleList()
        {
            InitializeComponent();
        }

        private void RoleList_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwRoles.DataSource = db.Roles.ToList();
            }
        }

        private void dgwRoles_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwRoles.SelectedRows.Count > 0 && (bool)dgwRoles.SelectedCells[3].Value == false; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((bool)dgwRoles.SelectedCells[3].Value == false && // Предотвращение удаления системных ролей
                MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить роль «{0}»?", dgwRoles.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Models.Role? role = db.Roles.FirstOrDefault(r => r.Id == (Guid)dgwRoles.SelectedCells[0].Value); // Находим удаляемый объект
                    if (role != null) // удаляем его
                    {
                        db.Roles.Remove(role);
                        db.SaveChanges();
                    }
                    dgwRoles.DataSource = db.Roles.ToList(); // перепривязка
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditRole er = new())
            {
                er.EditableRole = new();
                er.EditableRole.Id = Guid.Empty; // Признак того, что роль создаётся, а не редактируется
                er.EditableRole.Name = String.Empty;
                er.EditableRole.Description = String.Empty;
                er.EditableRole.isSystem = false;

                if (er.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwRoles.DataSource = db.Roles.ToList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((bool)dgwRoles.SelectedCells[3].Value == false) // Предотвращение редактирования системных ролей
            {
                using (EditRole er = new())
                {
                    er.EditableRole = new();
                    er.EditableRole.Id = (Guid)dgwRoles.SelectedCells[0].Value; // Существующий Id - признак того, что роль редактируется
                    er.EditableRole.Name = dgwRoles.SelectedCells[1].Value.ToString();
                    er.EditableRole.Description = dgwRoles.SelectedCells[2].Value.ToString();
                    er.EditableRole.isSystem = (bool)dgwRoles.SelectedCells[3].Value;

                    if (er.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                    {
                        using (ApplicationContext db = new ApplicationContext())
                            dgwRoles.DataSource = db.Roles.ToList();
                    }
                }
            }
        }

        private void dgwRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }
    }
}
