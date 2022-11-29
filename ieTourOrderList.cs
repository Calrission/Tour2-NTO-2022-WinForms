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
    public partial class ieTourOrderList : Form
    {
        public ieTourOrderList()
        {
            InitializeComponent();
        }

        private void ieTourOrderList_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwTourOrders.DataSource = db.TourOrders.Include(h => h.TourOrderItems).Include(h => h.Client).Include(h => h.PaymentType).ToList();
            }
        }

        private void dgwTourOrders_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwTourOrders.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"
            btnEdit.Enabled = isEditable;
            btnDelete.Enabled = isEditable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( // Удостоверяемся, что пользователь в сознании
                String.Format("Вы действительно хотите удалить заказ клиента «{0}»?", dgwTourOrders.SelectedCells[1].Value.ToString()),
                "Запрос на удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Models.TourOrder? to = db.TourOrders.FirstOrDefault(r => r.Id == (Guid)dgwTourOrders.SelectedCells[0].Value); // Находим удаляемый объект
                    if (to != null) // удаляем его
                    {
                        db.TourOrders.Remove(to);
                        db.SaveChanges();
                    }
                    dgwTourOrders.DataSource = db.TourOrders.Include(h => h.TourOrderItems).Include(h => h.Client).Include(h => h.PaymentType).ToList(); // перепривязка
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (ieEditTourOrder eto = new())
            {
                eto.TourOrderId = (Guid)dgwTourOrders.SelectedCells[0].Value;

                if (eto.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwTourOrders.DataSource = db.TourOrders.Include(h => h.TourOrderItems).Include(h => h.Client).Include(h => h.PaymentType).ToList();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (ieEditTourOrder eto = new())
            {
                eto.TourOrderId = Guid.Empty;

                if (eto.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwTourOrders.DataSource = db.TourOrders.Include(h => h.TourOrderItems).Include(h => h.Client).Include(h => h.PaymentType).ToList();
                }
            }
        }

        private void dgwTourOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void dgwTourOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }
    }
}
