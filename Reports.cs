using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Reporting.WinForms;
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
            var reportTypes = new List<String>() { "Свой вариант", "Текущий год", "1 полугодие", "2 полугодие", "I квартал", "II квартал", "III квартал", "IV квартал", "Текущий месяц", "Текущяя неделя" };
            using(ApplicationContext db = new())
            {
                comboBoxTypeReport.DataSource = reportTypes;
            }
        }


        private void btnShowReport_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Clear();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("TourName");
            dataTable.Columns.Add("Отменено");
            dataTable.Columns.Add("Забронировано");
            dataTable.Columns.Add("Оплачено");
            dataTable.Columns.Add("Продано");

            DateTime StartDateTime = dateTimePickerStart.Value;
            DateTime EndDateTime = dateTimePickerEnd.Value;
            StartDateTime = new DateTime(StartDateTime.Year, StartDateTime.Month, StartDateTime.Day, 0, 0, 0);
            EndDateTime = new DateTime(EndDateTime.Year, EndDateTime.Month, EndDateTime.Day, 0, 0, 0);

            double? TotalAmount = 0;
            double? PeriodAmount = 0;

            double? MoneyBooking = 0;
            double? MoneyPay = 0;
            double? MoneyLost = 0;
            double? MoneyRealization = 0;

            using (ApplicationContext db = new())
            {
                var allOrders = db.TourOrders
                    .Include(t => t.TourOrderItems)
                    .ToList()
                    .Where(t => {
                        DateTime date = (DateTime)t.TourOrderStatusShiftDate;
                        date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                        return date >= StartDateTime && date <= EndDateTime;
                    })
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

                MoneyBooking = allOrders
                    .Where(t => t.TourOrderStatusId == Guid.Parse("5F24C6F9-704A-403A-B30B-04E2F361A403"))
                    .Sum(t => t.TotalCost);

                MoneyPay = allOrders
                    .Where(t => t.TourOrderStatusId == Guid.Parse("D40D224C-D35A-4E2E-9D85-4EFAF3CA701E"))
                    .Sum(t => t.TotalCost);

                MoneyLost = allOrders
                    .Where(t => t.TourOrderStatusId == Guid.Parse("0A593624-6F2F-4FEA-BFF3-0A67904DE4E1"))
                    .Sum(t => t.TotalCost);

                MoneyRealization = allOrders
                    .Where(t => t.TourOrderStatusId == Guid.Parse("4A31DF95-6013-4AC7-AA88-C7E9ED348E02"))
                    .Sum(t => t.TotalCost);

            }
            reportViewer1.LocalReport.ReportEmbeddedResource = "TravelCompanyCore.ReportDefinitions.SalesAndOrdersOld.rdlc";

            reportViewer1.LocalReport.SetParameters(new ReportParameter("Period", string.Format("Заказы за период с {0} по {1}", dateTimePickerStart.Value.ToLongDateString(), dateTimePickerEnd.Value.ToLongDateString())));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Debet", string.Format("Всего средств на счету: {0} рублей.\nПоступления за выбранный период: {1} рублей.", TotalAmount.ToString(), PeriodAmount.ToString())));
            
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MoneyBooking", string.Format("Потенциальный доход: {0}", MoneyBooking)));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MoneyPay", string.Format("Потенциальный доход: {0}", MoneyPay)));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MoneyLost", string.Format("Потеряно: {0}", MoneyLost)));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MoneyRealization", string.Format("Доход: {0}", MoneyRealization)));

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

            if (Name == "Текущий год")
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
            else if (Name == "Текущий месяц")
            {
                return Tuple.Create(new DateTime(Year, Month, 1), new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)));
            }
            else if (Name == "Текущяя неделя")
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
