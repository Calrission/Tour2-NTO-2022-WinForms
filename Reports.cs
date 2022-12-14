using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System.Data;
using TravelCompanyCore.Models;

namespace TravelCompanyCore
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            var reportTypes = new List<String>() { "Свой вариант", "Год", "1 полугодие", "2 полугодие", "I квартал", "II квартал", "III квартал", "IV квартал", "Месяц", "Неделя" };
            using(ApplicationContext db = new())
            {
                comboBoxTypeReport.DataSource = reportTypes;
            }
        }


        private void btnShowReport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("TourName");
            dataTable.Columns.Add("Отменено");
            dataTable.Columns.Add("Забронировано");
            dataTable.Columns.Add("Оплачено");
            dataTable.Columns.Add("Продано");

            DateTime StartDateTime = dateTimePickerStart.Value;
            DateTime EndDateTime = dateTimePickerEnd.Value;

            double? TotalAmount = 0;
            double? PeriodAmount = 0;
            int CountBooking = 0;

            using (ApplicationContext db = new())
            {
                var allOrders = db.TourOrders
                    .Include(t => t.TourOrderItems)
                    .ToList()
                    .Where(t => t.TourOrderStatusShiftDate >= StartDateTime && t.TourOrderStatusShiftDate <= EndDateTime)
                    .ToList();

                db.Tours
                    .Include(t => t.Hotel)
                    .ToList()
                    .ForEach(t => {
                        string NameTour = t.ToString();
                        var ordersTour = allOrders.Where(w => w.TourOrderItems.Any(w => w.TourId == t.Id));
                        int CountBookingStatus = ordersTour.Where(w => w.TourOrderStatusId == TourOrderStatus.BookingId).Count();
                        int CountPayStatus = ordersTour.Where(w => w.TourOrderStatusId == TourOrderStatus.PaidId).Count();
                        int CountCancelStatus = ordersTour.Where(w => w.TourOrderStatusId == TourOrderStatus.CancellationId).Count();
                        int CountRealizationStatus = ordersTour.Where(w => w.TourOrderStatusId == TourOrderStatus.RealizedId).Count();

                        dataTable.Rows.Add(NameTour, CountCancelStatus, CountBookingStatus, CountPayStatus, CountRealizationStatus);
                    }
                );

                var pays = db.TourOrderPayments.ToList();
                TotalAmount = pays.ConvertAll(t => t.TotalCost).ToList().Sum();
                PeriodAmount = pays.Where(t => t.PaymentDate >= StartDateTime && t.PaymentDate <= EndDateTime).ToList().ConvertAll(t => t.TotalCost).ToList().Sum();
            }
            reportViewer1.LocalReport.ReportEmbeddedResource = "TravelCompanyCore.ReportDefinitions.SalesAndOrders.rdlc";

            reportViewer1.LocalReport.SetParameters(new ReportParameter("Period", string.Format("Заказы за период с {0} по {1}", dateTimePickerStart.Value.ToLongDateString(), dateTimePickerEnd.Value.ToLongDateString())));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Debet", string.Format("Всего средств на счету: {0} рублей.\nПоступления за выбранный период: {1} рублей.", TotalAmount.ToString(), PeriodAmount.ToString())));

            ReportDataSource rds = new ReportDataSource("DataSet222", dataTable);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void comboBoxTypeReport_ValueMemberChanged(object sender, EventArgs e)
        {
            var Name = ((List<string>)comboBoxTypeReport.DataSource)[comboBoxTypeReport.SelectedIndex];
            dateTimePickerStart.Enabled = Name == "Свой вариант";
            dateTimePickerEnd.Enabled = dateTimePickerStart.Enabled;
            if (!dateTimePickerStart.Enabled)
            {
                var pair = GetDiaposonDates(Name);
                dateTimePickerStart.Value = pair.Item1;
                dateTimePickerEnd.Value = pair.Item2;
            }
        }

        private Tuple<DateTime, DateTime> GetDiaposonDates(string Name)
        {
            var now = DateTime.Now;
            var Year = now.Year;
            var Month = now.Month;

            if (Name == "Год")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "1 полугодие")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 6, 30));
            }
            else if (Name == "2 полугодие")
            {
                return Tuple.Create(new DateTime(Year, 7, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "I квартал")
            {
                return Tuple.Create(new DateTime(Year, 1, 1), new DateTime(Year, 3, 31));
            }
            else if (Name == "II квартал")
            {
                return Tuple.Create(new DateTime(Year, 4, 1), new DateTime(Year, 6, 30));
            }
            else if (Name == "III квартал")
            {
                return Tuple.Create(new DateTime(Year, 7, 1), new DateTime(Year, 9, 30));
            }
            else if (Name == "IV квартал")
            {
                return Tuple.Create(new DateTime(Year, 10, 1), new DateTime(Year, 12, 31));
            }
            else if (Name == "Месяц")
            {
                return Tuple.Create(new DateTime(Year, Month, 1), new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)));
            }
            else if (Name == "Неделя")
            {
                int DayOfWeek = ((int)DateTime.Now.DayOfWeek == 0) ? 6 : (int)DateTime.Now.DayOfWeek - 1;
                var start = DateTime.Now.AddDays(-DayOfWeek);
                var end = DateTime.Now.AddDays(6 - DayOfWeek);
                return Tuple.Create(start, end);
            }

            return null;
        }
    }
}
