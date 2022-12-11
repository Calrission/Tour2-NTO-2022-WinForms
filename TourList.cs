using Microsoft.EntityFrameworkCore;

namespace TravelCompanyCore
{
    public enum WorkingMode
    {
        Normal, TourSelection
    }
    public partial class TourList : Form
    {
        public TourList()
        {
            InitializeComponent();
        }

        public WorkingMode workingMode; // Режим работы окна - обычный (Normal) или выбор строк для другого окна (TourSelection)

        private List<Guid> selTours;
        public List<Guid> SelectedTourIds // Коллекция Id выбранных в гриде туров, работает только в режиме TourSelection
        {
            get
            {
                if (workingMode == WorkingMode.Normal) return new(); // Если свойство вызовут в режиме Normal, нужно вернуть List, а не null
                else return selTours;
            }
        }

        private void TourList_Load(object sender, EventArgs e)
        {
            dgwTours.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwTours.DataSource = db.Tours.Include(t => t.Food).Include(t => t.Hotel).ToList();
            }
            if (workingMode == WorkingMode.TourSelection) // Настройка внешнего вида окна и активация SelectedToursId
            {
                btnSelect.Visible = true;
                dgwTours.Columns[7].Width = dgwTours.Columns[7].Width - 30;
                dgwTours.Columns[8].Visible = true;
                selTours = new();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditTour et = new())
            {
                et.EditableId = Guid.Empty;
                if (et.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwTours.DataSource = db.Tours.Include(t => t.Food).Include(t => t.Hotel).ToList();
                }
            }
        }

        private void dgwTours_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwTours.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить тур в отель «{0}»?", dgwTours.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Guid id2delete = (Guid)dgwTours.SelectedCells[0].Value;
                    // Если Тур входит в Заказ, его удалять нельзя:
                    if (db.TourOrderItems.Any(toi => toi.TourId == id2delete))
                        MessageBox.Show(String.Format("Тур в отель «{0}» входит в состав одного или нескольких Заказов, его нельзя удалить", dgwTours.SelectedCells[1].Value.ToString()));
                    else
                    {
                        Models.Tour? tour = db.Tours.FirstOrDefault(r => r.Id == (Guid)dgwTours.SelectedCells[0].Value); // Находим удаляемый объект
                        if (tour != null) // удаляем его
                        {
                            db.Tours.Remove(tour);
                            db.SaveChanges();
                        }
                        dgwTours.DataSource = db.Tours.Include(t => t.Food).Include(t => t.Hotel).ToList(); // перепривязка
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (EditTour et = new())
            {
                et.EditableId = (Guid)dgwTours.SelectedCells[0].Value;
                if (et.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwTours.DataSource = db.Tours.Include(t => t.Food).Include(t => t.Hotel).ToList();
                }
            }
        }

        private void dgwTours_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selTours.Clear(); // На всякий случай
            foreach (DataGridViewRow tourRow in dgwTours.Rows) // Шерстим все строки
            {
                if ((bool)tourRow.Cells[8].FormattedValue) // Если галочка стоит,
                    selTours.Add((Guid)tourRow.Cells[0].Value); // добавляем Id строки в колллекцию выбранных Id
            }
            if (selTours.Count > 0)
            {
                this.DialogResult = DialogResult.OK; // Чтобы понять, что выбор состоялся
                this.Close();
            }
        }
    }
}
