using Microsoft.EntityFrameworkCore;
using System.Data;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class ChangeTourOrderStatus : Form
    {
        public Guid TourOrderId { get; set; }
        private TourOrder to = new();
        private TourOrderRealization tr = null;
        public ChangeTourOrderStatus()
        {
            InitializeComponent();
        }

        private void ChangeTourOrderStatus_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                comboReasons.DataSource = db.TourOrderStatusReasons.Where(tosr => tosr.Id != TourOrderStatusReason.NoReasonId).ToList();

                if (TourOrderId != Guid.Empty)
                {
                    to = db.TourOrders
                        .Include(to => to.TourOrderStatus).Include(to => to.TourOrderStatusReason) // Чтобы отобразить текущий статус
                        .First(to => to.Id == TourOrderId);

                    lblCurrentStatus.Text = String.Format("{0} от {1}", to.StatusWitnReasonDescription, to.TourOrderStatusShiftDate.Value.ToString());

                    setStatusAvailability(to.TourOrderStatusId);

                    rbtnCheckChanged(sender, e);

                    if (to.TourOrderStatusId == TourOrderStatus.RealizedId)
                    {
                        tr = db.TourOrderRealizations.Single(t => t.TourOrderId == TourOrderId);
                        chkHotelConfirmation.Checked = tr.BookingConfirmation;
                    }
                }
                else
                {
                    // Надо смываться, форма загружена неправильно!
                }
            }
        }

        private void setStatusAvailability(Guid currentStatus)
        {
            if (currentStatus == TourOrderStatus.DraftId)
            {
                rbtnBooking.Enabled = true;
                rbtnCancel.Enabled = false;
                rbtnPaid.Enabled = false;
                rbtnRealized.Enabled = false;
            }
            else if (currentStatus == TourOrderStatus.BookingId)
            {
                rbtnBooking.Enabled = false;
                rbtnCancel.Enabled = true;
                rbtnPaid.Enabled = true;
                rbtnRealized.Enabled = false;
            }
            else if (currentStatus == TourOrderStatus.CancellationId)
            {
                rbtnBooking.Enabled = false;
                rbtnCancel.Enabled = true; // Можно поменять причину
                comboReasons.SelectedValue = to.TourOrderStatusReasonId; // Выставляем текущую причину
                rbtnPaid.Enabled = false;
                rbtnRealized.Enabled = false;
            }
            else if (currentStatus == TourOrderStatus.PaidId)
            {
                rbtnBooking.Enabled = false;
                rbtnCancel.Enabled = false;
                rbtnPaid.Enabled = false;
                rbtnRealized.Enabled = true;
            }
            else if (currentStatus == TourOrderStatus.RealizedId)
            {
                rbtnBooking.Enabled = false;
                rbtnCancel.Enabled = false;
                rbtnPaid.Enabled = false;
                rbtnRealized.Enabled = true;
            }
            else // Во всех остальных статусах ничо нельзя
            {
                rbtnBooking.Enabled = false;
                rbtnCancel.Enabled = false;
                rbtnPaid.Enabled = false;
                rbtnRealized.Enabled = false;
            }
        }

        private void rbtnCheckChanged(object sender, EventArgs e)
        {
            comboReasons.Enabled = rbtnCancel.Checked;
            lblReason.Enabled = rbtnCancel.Checked;
            chkHotelConfirmation.Enabled = rbtnRealized.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Guid newReasonId = TourOrderStatusReason.NoReasonId; // По умолчанию беспричинно
            Guid newStatusId = Guid.Empty;
            this.DialogResult = DialogResult.Cancel; // По умолчанию перепривязка данных в родительском окне не нужна - типа ничего не изменилось

            // Бронь можно установить только на Черновик
            if (rbtnBooking.Enabled && rbtnBooking.Checked && to.TourOrderStatusId == TourOrderStatus.DraftId)
                newStatusId = TourOrderStatus.BookingId;

            // Отменить можно только Бронь или саму Отмену (для смены причины)
            if (rbtnCancel.Enabled && rbtnCancel.Checked
                && (to.TourOrderStatusId == TourOrderStatus.BookingId || to.TourOrderStatusId == TourOrderStatus.CancellationId))
            {
                newStatusId = TourOrderStatus.CancellationId;
                newReasonId = (Guid)comboReasons.SelectedValue;
            }

            // Оплатить можно только Бронь
            if (rbtnPaid.Enabled && rbtnPaid.Checked && to.TourOrderStatusId == TourOrderStatus.BookingId)
                newStatusId = TourOrderStatus.PaidId;

            // Продать можно только Оплату
            if (rbtnRealized.Enabled && rbtnRealized.Checked && (to.TourOrderStatusId == TourOrderStatus.PaidId || to.TourOrderStatusId == TourOrderStatus.RealizedId))
                newStatusId = TourOrderStatus.RealizedId;

            if (newStatusId != Guid.Empty)
            {
                if ((newStatusId == TourOrderStatus.CancellationId && newReasonId != to.TourOrderStatusReasonId) // Если мы изменяем причину Отмены
                || (tr != null && tr.BookingConfirmation != chkHotelConfirmation.Checked)       // Если статус продано, но изменено потверждение брони
                    || to.TourOrderStatusId != newStatusId) //  Или если новый статус отличается от старого
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // Заново получаем объект в текущем контексте:
                        TourOrder EditableTO = db.TourOrders.First(to => to.Id == TourOrderId);
                        // Обновляем поля:
                        EditableTO.TourOrderStatusId = newStatusId;
                        EditableTO.TourOrderStatusReasonId = newReasonId;
                        EditableTO.TourOrderStatusShiftDate = DateTime.Now;

                        db.TourOrders.Update(EditableTO);

                        if (newStatusId == TourOrderStatus.PaidId)
                        {
                            db.TourOrderPayments.Add(new TourOrderPayment
                            {
                                TourOrderId = EditableTO.Id,
                                TotalCost = EditableTO.TotalCost,
                                PaymentDate = DateTime.Now
                            });
                        }
                        else if (newStatusId == TourOrderStatus.RealizedId && tr == null)
                        {
                            db.TourOrderRealizations.Add(EditableTO.convertToTourOrderRelalization(chkHotelConfirmation.Checked));
                        }
                        else if (tr != null)
                        {
                            tr = db.TourOrderRealizations.Single(t => t.Id == tr.Id);
                            tr.BookingConfirmation = chkHotelConfirmation.Checked;
                            db.Update(tr);
                        }

                        db.SaveChanges();
                    }
                    this.DialogResult = DialogResult.OK; // Чтобы окно закрылось и последующая перепривязка данных в родительском окне состоялась
                }
            }
        }

        private void rbtnRealized_CheckedChanged(object sender, EventArgs e)
        {
            chkHotelConfirmation.Enabled = true;
        }
    }
}