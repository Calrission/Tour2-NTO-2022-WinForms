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
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class ChangeTourOrderStatus : Form
    {
        public Guid TourOrderId { get; set; }
        private TourOrder to = new();
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
                    // Заказ с элементами и соответствующими этим элементам связями:
                    to = db.TourOrders
                        .Include(to => to.TourOrderItems)
                        .ThenInclude(toi => toi.Tour)
                        .ThenInclude(t => t.Hotel)
                        .First(to => to.Id == TourOrderId);
                    // Не дадим редактировать Заказ со статусом, отличным от Черновика
                    bool isDraft = to.TourOrderStatusId == TourOrderStatus.DraftId;

                    rbtnCheckChanged(sender, e);
                }
                else
                {
                    // Надо смываться, форма загружена неправильно!
                }
            }
        }
        private void rbtnCheckChanged(object sender, EventArgs e)
        {
            comboReasons.Enabled = rbtnCancel.Checked;
            lblReason.Enabled = rbtnCancel.Checked;
            chkHotelConfirmation.Enabled = rbtnRealized.Checked;
        }
    }
}
