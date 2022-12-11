﻿using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TravelCompanyCore
{
    public partial class HotelList : Form
    {
        public HotelList()
        {
            InitializeComponent();
        }

        private void HotelList_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwHotels.DataSource = db.Hotels.Include(h => h.Region).Include(h => h.Manager).ToList();
                comboxRegion.DataSource = db.Regions.ToList().Prepend(new Models.Region { Id = Guid.Empty, Name = "Все" }).ToList();
            }
        }

        private void dgwHotels_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwHotels.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить отель «{0}»?", dgwHotels.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Guid id2delete = (Guid)dgwHotels.SelectedCells[0].Value;
                    // Если Отель входит в состав к-л Тура, его удалять нельзя:
                    if (db.Tours.Any(t => t.HotelId == id2delete))
                        MessageBox.Show(String.Format("Отель «{0}» входит в состав одного или нескольких Туров, его нельзя удалить", dgwHotels.SelectedCells[1].Value.ToString()));
                    else
                    {
                        Models.Hotel? hotel = db.Hotels.FirstOrDefault(r => r.Id == id2delete); // Находим удаляемый объект
                        if (hotel != null) // удаляем его
                        {
                            db.Hotels.Remove(hotel);
                            db.SaveChanges();
                        }
                        dgwHotels.DataSource = db.Hotels.Include(h => h.Region).Include(h => h.Manager).ToList(); // перепривязка
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (EditHotel eh = new())
            {
                eh.EditableId = (Guid)dgwHotels.SelectedCells[0].Value;

                if (eh.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwHotels.DataSource = db.Hotels.Include(h => h.Region).Include(h => h.Manager).ToList();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (EditHotel eh = new())
            {
                eh.EditableId = Guid.Empty;

                if (eh.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwHotels.DataSource = db.Hotels.Include(h => h.Region).Include(h => h.Manager).ToList();
                }
            }
        }

        private void dgwHotels_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            string TextSearch = txtSearchString.Text;
            using (ApplicationContext db = new())
            {
                dgwHotels.DataSource = db.Hotels
                    .Include(h => h.Region)
                    .Include(h => h.Manager)
                    .ToList()
                    .Where(t => (
                        t.Name.Contains(TextSearch, StringComparison.InvariantCultureIgnoreCase) &&
                        ((Guid)comboxRegion.SelectedValue == Guid.Empty || ((Guid)comboxRegion.SelectedValue != Guid.Empty && t.RegionId == (Guid)comboxRegion.SelectedValue))
                    ))
                    .ToList();
            };
        }
    }
}
