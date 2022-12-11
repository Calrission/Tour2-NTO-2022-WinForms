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
            cmd.CommandText = "select * from Hotels";
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
