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
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        ManageWorker W = new ManageWorker();

        private void btnStockBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            W.WorkerName = tbName.Text;
            W.WContactNo = tbContact.Text;
            W.WAddress = tbAddress.Text;
            W.WGoldGiven = tbGivenGold.Text;
            W.WGoldRecieved = tbRecivedGold.Text;

            int condition = W.insertWorker();
            if (condition > 0)
            {
                Utilities._Information("Record Added Successfully");
                dgvWorker.DataSource = W.getAllWorker();
            }
            else
                Utilities._None("Try Again");
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            dgvWorker.DataSource = W.getAllWorker();
        }
    }
}
