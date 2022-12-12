using Microsoft.EntityFrameworkCore;
using System.Data;
using TravelCompanyCore.Models;

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
            dgwTourOrders.AutoGenerateColumns = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим в грид
                dgwTourOrders.DataSource = db.TourOrders
                    .Include(h => h.TourOrderItems)
                    .Include(h => h.Client)
                    .Include(h => h.PaymentType)
                    .Include(tos => tos.TourOrderStatus)
                    .Include(tos => tos.TourOrderStatusReason).ToList();

                comboBoxStatus.DataSource = db.TourOrderStatuses.ToList().Prepend(new TourOrderStatus { Id = Guid.Empty, Name = "Все" }).ToList();
                comboxPayType.DataSource = db.PaymentTypes.ToList().Prepend(new PaymentType { Id = Guid.Empty, Name = "Все" }).ToList();
            }
        }

        private void dgwTourOrders_SelectionChanged(object sender, EventArgs e)
        {
            bool isEditable = dgwTourOrders.SelectedRows.Count > 0; // флаг активации кнопок "Удалить" и "Изменить"

            btnEdit.Enabled = isEditable;
            btnChangeStatus.Enabled = isEditable;

            if (isEditable && (Guid)dgwTourOrders.SelectedCells[5].Value == TourOrderStatus.DraftId) // Черновик
            {
                btnEdit.Text = "Изменить";
                btnDelete.Enabled = isEditable;
            }
            else // А здесь есть чего:
            {
                btnEdit.Text = "Просмотр";
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((Guid)dgwTourOrders.SelectedCells[5].Value == TourOrderStatus.DraftId) // Удалить можно только Черновик!!!
            {
                if (dgwTourOrders.SelectedCells != null
                && MessageBox.Show( // Удостоверяемся, что пользователь в сознании
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
                        dgwTourOrders.DataSource = db.TourOrders
                            .Include(h => h.TourOrderItems)
                            .Include(h => h.Client)
                            .Include(h => h.PaymentType)
                            .Include(tos => tos.TourOrderStatus)
                            .Include(tos => tos.TourOrderStatusReason).ToList(); // перепривязка
                    }
                }
            }
            else MessageBox.Show("Удалить можно только «Черновик»!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgwTourOrders.SelectedCells != null)
            {
                using (ieEditTourOrder eto = new())
                {
                    eto.TourOrderId = (Guid)dgwTourOrders.SelectedCells[0].Value;

                    if (eto.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                    {
                        using (ApplicationContext db = new ApplicationContext())
                            dgwTourOrders.DataSource = db.TourOrders
                                .Include(h => h.TourOrderItems)
                                .Include(h => h.Client)
                                .Include(h => h.PaymentType)
                                .Include(tos => tos.TourOrderStatus)
                                .Include(tos => tos.TourOrderStatusReason).ToList();
                    }
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
                        dgwTourOrders.DataSource = db.TourOrders
                            .Include(h => h.TourOrderItems)
                            .Include(h => h.Client)
                            .Include(h => h.PaymentType)
                            .Include(tos => tos.TourOrderStatus)
                            .Include(tos => tos.TourOrderStatusReason).ToList();
                }
            }
        }

        private void dgwTourOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, new EventArgs());
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            using (ChangeTourOrderStatus ctos = new())
            {
                ctos.TourOrderId = (Guid)dgwTourOrders.SelectedCells[0].Value;
                if (ctos.ShowDialog(this) == DialogResult.OK) // если юзер сохранился, перепривязываем грид
                {
                    using (ApplicationContext db = new ApplicationContext())
                        dgwTourOrders.DataSource = db.TourOrders
                            .Include(h => h.TourOrderItems)
                            .Include(h => h.Client)
                            .Include(h => h.PaymentType)
                            .Include(tos => tos.TourOrderStatus)
                            .Include(tos => tos.TourOrderStatusReason).ToList();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bthSearch_Click(object sender, EventArgs e)
        {
            string SearchText = txtSearchString.Text;
            using (ApplicationContext db = new())
            {
                dgwTourOrders.DataSource = db.TourOrders.Include(h => h.TourOrderItems)
                    .Include(h => h.Client)
                    .Include(h => h.PaymentType)
                    .Include(tos => tos.TourOrderStatus)
                    .Include(tos => tos.TourOrderStatusReason)
                    .ToList()
                    .Where(t => (
                        (t.Client.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)) &&
                        ((Guid)comboBoxStatus.SelectedValue == Guid.Empty || ((Guid)comboBoxStatus.SelectedValue != Guid.Empty && (Guid)comboBoxStatus.SelectedValue == t.TourOrderStatusId)) &&
                        ((Guid)comboxPayType.SelectedValue == Guid.Empty || ((Guid)comboxPayType.SelectedValue != Guid.Empty && (Guid)comboxPayType.SelectedValue == t.PaymentTypeId))
                    ))
                    .ToList();
            };
        }
    }
}
