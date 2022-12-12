using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Data.Common;
using TravelCompanyCore.Models;
using TravelCompanyCore.ReportDefinitions;

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
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=TravelCompanyCoreStorage.db");
            SqliteCommand cmd = sqliteConnection.CreateCommand();
            cmd.CommandText = "SELECT TourName, SUM (CASE StatusName WHEN 'Отмена' THEN 1 ELSE 0 END) AS \"Отменено\", SUM (CASE StatusName WHEN 'Бронь' THEN 1 ELSE 0 END) AS \"Забронировано\", SUM (CASE StatusName WHEN 'Оплата' THEN 1 ELSE 0 END) AS \"Оплачено\", SUM (CASE StatusName WHEN 'Продан' THEN 1 ELSE 0 END) AS \"Продано\" FROM (select t.Id as TourId, h.Name || ' ' || (cast(DaysAmount as text) || ' дней/') || (cast(NightsAmount as text) || ' ночей c ')  || (cast(StartDateTime as text)) as TourName, tos.Name as StatusName from tourorderitems as toi inner join TourOrders as tt on tt.Id=toi.TourOrderId inner join Tours t on t.Id=toi.TourId inner join Hotels h on h.Id=t.HotelId inner join TourOrderStatuses tos on tos.Id=tt.TourOrderStatusId where TourOrderStatusShiftDate >= @FromDate and TourOrderStatusShiftDate <= @ToDate) GROUP BY TourName";
            
            cmd.Parameters.Clear();
            
            SqliteParameter dt1 = new();
            dt1.ParameterName = "FromDate";
            dt1.Value = DateTime.MinValue;
            
            SqliteParameter dt2 = new();
            dt2.ParameterName = "ToDate";
            dt2.Value = DateTime.Now;            

            cmd.Parameters.Add(dt1);
            cmd.Parameters.Add(dt2);

            cmd.Connection = sqliteConnection;
            sqliteConnection.Open();
            SqliteDataReader executeReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(executeReader);
            sqliteConnection.Close();

            ReportDataSource rds = new ReportDataSource("DataSet222", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();

            reportViewer1.LocalReport.ReportEmbeddedResource = "TravelCompanyCore.ReportDefinitions.SalesAndOrders.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
