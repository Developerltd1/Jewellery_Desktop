using ShahiApplication.Forms;
using ShahiApplication.SMSForm;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockForm stock = new StockForm();
            stock.Show();
            //this.Visible = false; 
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            report.Show();
        }

        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            Sale_Invoices_Form sale = new Sale_Invoices_Form();
            sale.Show();
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            SMSAlertForm sms = new SMSAlertForm();
            sms.Show();
        }

        private void btnWorkers_Click(object sender, EventArgs e)
        {
            WorkerForm worker = new WorkerForm();
            worker.Show();
        }

        private void btnCheckOrder_Click(object sender, EventArgs e)
        {
            CheckOrderForm order = new CheckOrderForm();
            order.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
