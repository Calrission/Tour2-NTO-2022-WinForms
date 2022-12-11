namespace TravelCompanyCore
{
    public partial class RegionList : Form
    {
        public RegionList()
        {
            InitializeComponent();
        }

        private void RegionList_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwRegions.DataSource = db.Regions.ToList();
            }
        }

        private void dgwRegions_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwRegions.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить регион «{0}»?", dgwRegions.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Guid id2delete = (Guid)dgwRegions.SelectedCells[0].Value;
                    // Если к Региону привязан Отель, его удалять нельзя:
                    if (db.Hotels.Any(h => h.RegionId == id2delete))
                        MessageBox.Show(String.Format("К региону «{0}» привязан один или несколько Отелей, его нельзя удалить", dgwRegions.SelectedCells[1].Value.ToString()));
                    else
                    {
                        Models.Region? region = db.Regions.FirstOrDefault(r => r.Id == (Guid)dgwRegions.SelectedCells[0].Value); // Находим удаляемый объект
                        if (region != null) // удаляем его
                        {
                            db.Regions.Remove(region);
                            db.SaveChanges();
                        }
                        dgwRegions.DataSource = db.Regions.ToList(); // перепривязка
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditRegion er = new())
            {
                er.EditableRegion = new();
                er.EditableRegion.Id = Guid.Empty; // Признак того, что регион создаётся, а не редактируется
                er.EditableRegion.Name = String.Empty;
                er.EditableRegion.Description = String.Empty;

                if (er.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwRegions.DataSource = db.Regions.ToList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (EditRegion er = new())
            {
                er.EditableRegion = new();
                er.EditableRegion.Id = (Guid)dgwRegions.SelectedCells[0].Value; // Существующий Id - признак того, что регион редактируется
                er.EditableRegion.Name = dgwRegions.SelectedCells[1].Value.ToString();
                er.EditableRegion.Description = dgwRegions.SelectedCells[2].Value.ToString();

                if (er.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwRegions.DataSource = db.Regions.ToList();
                }
            }
        }

        private void dgwRegions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }
    }
}