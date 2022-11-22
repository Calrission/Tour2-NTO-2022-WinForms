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

namespace TravelCompanyCore
{
    public partial class TourList : Form
    {
        public TourList()
        {
            InitializeComponent();
        }

        private void TourList_Load(object sender, EventArgs e)
        {
            dgwTours.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwTours.DataSource = db.Tours.Include(t => t.Food).Include(t => t.Hotel).ToList();
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
    }
}
