using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication.Forms
{
    public partial class ReceiptPrint : Form
    {
        public ReceiptPrint()
        {
            InitializeComponent();
        }

        private void ReceiptPrint_Load(object sender, EventArgs e)
        {
            tbReceipt.Text = Sale_Invoices_Form.passingText;
            this.shahiDBDataSet.EnforceConstraints = false;

            this.usp_ReceiptTableAdapter.Fill(this.shahiDBDataSet.usp_Receipt, Convert.ToInt32(tbReceipt.Text));
         
            this.reportViewer1.RefreshReport();
        }

        private void tbReceipt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
