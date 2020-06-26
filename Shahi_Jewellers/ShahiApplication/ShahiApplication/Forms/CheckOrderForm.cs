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

namespace ShahiApplication.Forms
{
    public partial class CheckOrderForm : Form
    {
        string ch_imgPath = null;
        public CheckOrderForm()
        {
            InitializeComponent();
        }

        private void CheckOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStockBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }

        private void tbSeacrh_ReciptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    ManageOrder order = new ManageOrder();
                    DataTable mydt = new DataTable();
                    mydt = order.checkInvoice_by_ReciptNo(Convert.ToInt32(tbSeacrh_ReciptNo.Text));
                    dgvCheckOrder.DataSource = mydt;

                    tbRecipt.Text = mydt.Rows[0][0].ToString();
                    dtCurrent.Text = mydt.Rows[0][1].ToString();
                    dtDue.Text = mydt.Rows[0][2].ToString();
                    tbName.Text = mydt.Rows[0][3].ToString();
                    tbMobile.Text = mydt.Rows[0][4].ToString();
                    tbAddress.Text = mydt.Rows[0][5].ToString();
                    tbGrandTotal.Text = mydt.Rows[0][6].ToString();
                    tbAdvance.Text = mydt.Rows[0][7].ToString();
                    tbBalance.Text = mydt.Rows[0][8].ToString();

                    DataRow dr = mydt.Rows[0];
                    ch_imgPath = dr["ItemImage"].ToString();
                    displayImage.Image = System.Drawing.Image.FromFile(ch_imgPath);
                }
                catch (Exception )
                {
                    MessageBox.Show("No Record Found!");
                    tbRecipt.Text = null;
                    dtCurrent.Text = null;
                    dtDue.Text = null;
                    tbName.Text = null;
                    tbMobile.Text = null;
                    tbAddress.Text = null;
                    tbGrandTotal.Text = null;
                    tbAdvance.Text = null;
                    tbBalance.Text = null;
                    displayImage.Text = null;
                    // dgvCheckOrder = null;
                }
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
                ManageOrder order = new ManageOrder();
                order.TotalBill = Convert.ToDouble(tbGrandTotal.Text);
                order.Advance = Convert.ToDouble(tbAdvance.Text);
                order.Balance = Convert.ToDouble(tbBalance.Text);
                order.ReciptNo = Convert.ToInt32(tbRecipt.Text);

                int condition = order.updateInvoiceCheckOrder();

                if (condition > 0)
                {
                    MessageBox.Show("Invoice Updated Successfully");
                }
                else
                    MessageBox.Show("Try Again");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Please Enter Records!" + ex);

            //}
        }

        private void tbGrandTotal_TextChanged(object sender, EventArgs e)
        {
            if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
            {
                Double total = Convert.ToDouble(tbGrandTotal.Text) - Convert.ToDouble(tbAdvance.Text);
                tbBalance.Text = total.ToString();
            }
            else
            {
                tbBalance.Text = "0";
            }
        }

        private void tbAdvance_TextChanged(object sender, EventArgs e)
        {
            if (tbGrandTotal.Text != "" && tbAdvance.Text != "")
            {
                Double total = Convert.ToDouble(tbGrandTotal.Text) - Convert.ToDouble(tbAdvance.Text);
                tbBalance.Text = total.ToString();
            }
            else
            {
                tbBalance.Text = "0";
            }
        }

        private void dgvCheckOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = null;

            try
            {
                if (e.RowIndex >= 0)
                {
                    //gets a collection that contains all the rows
                    row = this.dgvCheckOrder.Rows[e.RowIndex];
                    displayImage.Image = System.Drawing.Image.FromFile(row.Cells[13].Value.ToString());
                    displayImage.ImageLocation = row.Cells[13].Value.ToString();
                    row.Cells[13].Value = null;
                    displayImage.Image = null;

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("eException: " + ex.ToString());
            }  
        }

       
    }
}
