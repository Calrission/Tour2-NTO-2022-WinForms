﻿using Microsoft.EntityFrameworkCore;
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
            using(ApplicationContext db = new())
            {
                comboBoxTypeReport.DataSource = db.ReportType.ToList().Prepend(new ReportType { Id = Guid.Empty, Name = "Свой вариант" }).ToList().OrderBy(t => t.Position).ToList();
            }
        }

        private void btnPrepareReport_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Тур");
            dataTable.Columns.Add("Отменено");
            dataTable.Columns.Add("Забронировано");
            dataTable.Columns.Add("Оплачено");
            dataTable.Columns.Add("Продано");

            using (ApplicationContext db = new())
            {
                var allOrders = db.TourOrders
                    .Include(t => t.TourOrderItems)
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
            }
            reportViewer1.LocalReport.ReportEmbeddedResource = "TravelCompanyCore.ReportDefinitions.SalesAndOrders.rdlc";

            ReportDataSource rds = new ReportDataSource("DataSet222", dataTable);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        } 

        private void comboBoxTypeReport_ValueMemberChanged(object sender, EventArgs e)
        {
            var newReportType = ((List<ReportType>)comboBoxTypeReport.DataSource)[comboBoxTypeReport.SelectedIndex];
            dateTimePickerStart.Enabled = newReportType.Id == Guid.Empty;
            dateTimePickerEnd.Enabled = newReportType.Id == Guid.Empty;
            if (newReportType.Id != Guid.Empty)
            {
                var pair = newReportType.GetDiaposonDates();
                dateTimePickerStart.Value = pair.Item1;
                dateTimePickerEnd.Value = pair.Item2;
            }
        }
    }
}
