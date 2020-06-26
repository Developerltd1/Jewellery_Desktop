using Microsoft.Reporting.WinForms;
using ShahiApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }
        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            // this.ShahiDBDataSet1.EnforceConstraints = false;
            // this.usp_SalesReportTableAdapter.Fill(this.ShahiDBDataSet1.usp_SalesReport, dtFrom.Value, dtTo.Value);
            // this.rvSaleReports.RefreshReport();
            DataTable dt = ManageReport.GetSalesReport(dtFrom.Value, dtTo.Value);
            
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "Reports/SalesReport.rdlc";
            ReportDataSource Rds = new ReportDataSource();
            Rds.Name = "DataSet1"; //Using in rdlc Report DataSetName
            Rds.Value = dt;
            reportViewer1.LocalReport.DataSources.Add(Rds);
            reportViewer1.RefreshReport();
        }
    }
}
