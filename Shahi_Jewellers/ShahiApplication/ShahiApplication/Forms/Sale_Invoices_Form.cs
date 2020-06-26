using ShahiApplication.Classes;
using ShahiApplication.Forms;
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
    public partial class Sale_Invoices_Form : Form
    {
        List<ManageOrderDetails> mylist = new List<ManageOrderDetails>();
        ManageOrderDetails orderDetails = new ManageOrderDetails();
        DataTable dt = new DataTable();
        string imgPath;
       public static string passingText;
        public Sale_Invoices_Form()
        {
            InitializeComponent();
        }

        ManageCategory category = new ManageCategory();
        ManageItems item = new ManageItems();
           
       

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }


        private void btnAddCart_Click(object sender, EventArgs e)
        {
            try
            {
                
                ManageOrderDetails mobj = new ManageOrderDetails();

                mobj.TagNo = tbTagNo.Text;
                mobj.Category_ID = Convert.ToInt32(cbInvoiceCategory.SelectedValue);
                mobj.Item_ID = Convert.ToInt32(cbInvoiceItem.SelectedValue);
                mobj.Polish = Convert.ToDouble(tbPolish.Text);
                mobj.Kaat = Convert.ToDouble(tbKaat.Text);
                mobj.Grams = Convert.ToDouble(tbGrams.Text);
                mobj.Tola = Convert.ToDouble(tbTola.Text);
                mobj.Masha = Convert.ToDouble(tbMasha.Text);
                mobj.Ratti = Convert.ToDouble(tbRatti.Text);
                mobj.GoldRate = Convert.ToDouble(tbGoldRate.Text);
                mobj.SubTotal = Convert.ToDouble(tbSubTotal.Text);
                mobj.Labour = Convert.ToDouble(tbLabour.Text);
                mobj.TotalPrice = Convert.ToDouble(tbTotalPrice.Text);
                mobj.CategoryName = cbInvoiceCategory.Text;
                mobj.ItemName = cbInvoiceItem.Text;
                mobj.Issue_Qty = Convert.ToInt32(tbIssueQty.Text);


                mylist.Add(mobj);

                
                dgvDisplayOrder.DataSource = null;
                dgvDisplayOrder.DataSource = mylist;

                tbTagNo.Text = null;
                cbInvoiceCategory.Text = "Select Category";
                cbInvoiceItem.Text = "Select Item";
                tbPolish.Text = null;
                tbKaat.Text = null;
                tbGrams.Text = null;
                tbTola.Text = null;
                tbMasha.Text = null;
                tbRatti.Text = null;
                //tbGoldRate.Text = null;
                tbSubTotal.Text = null;
                tbLabour.Text = null;
                tbTotalPrice.Text = null;
                cbCarat.Text = "Select Carat";
                


                double sum = 0;
                for (int i = 0; i < dgvDisplayOrder.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[12].Value);

                }

                tbGrandTotal.Text = sum.ToString();
                tbAdvance.Text = "0";
            }

            catch (Exception)
            {
                MessageBox.Show("Some fields are missing in Product Details!",
                     "Warning",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
            }
        }
        

        private void tbTagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    string abv = tbTagNo.Text.Substring(0, 2);

                    int num = Convert.ToInt32(tbTagNo.Text.Substring(2));


                    int itemid = orderDetails.SearchItemIDThroughAbv(abv);

                     
                     cbInvoiceCategory.DataSource = orderDetails.GetStockbyItemIDandTagNo(itemid, num);

                     cbInvoiceCategory.ValueMember = "CategoryID";
                    cbInvoiceCategory.DisplayMember = "CategoryName";
                    

                    cbInvoiceItem.DataSource = orderDetails.GetStockbyItemIDandTagNo(itemid, num);

                    cbInvoiceItem.ValueMember = "ItemID";
                    cbInvoiceItem.DisplayMember = "ItemName";
                    

                    cbCarat.DataSource = orderDetails.GetStockbyItemIDandTagNo(itemid, num);

                    cbCarat.DisplayMember = "Carat";

                    dt = orderDetails.GetStockbyItemIDandTagNo(itemid, num);
                    DataRow dr = dt.Rows[0];
                     imgPath = dr["StockImage"].ToString();

                    displayImage.Image = System.Drawing.Image.FromFile(imgPath);
                    tbGrams.Focus();
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Please Enter Tag No");
            }
            
        }

        private void tbGrams_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbGrams.Text != "")
                {
                    Double total = Convert.ToDouble(tbGrams.Text) / 12.5;
                    //tbTola.Text = total.ToString();
                    tbTola.Text = String.Format("{0:F3}", total); // Show 4 Decimel Points
                    
                }
                else 
                {
                    tbTola.Text = "0";
                    
                }
                if (tbGrams.Text != "")
                {
                    Double total = Convert.ToDouble(tbGrams.Text) / 1.041;
                    tbMasha.Text = String.Format("{0:F3}", total); 

                }
                else
                {
                    tbMasha.Text = "0";

                }
                if (tbGrams.Text != "")
                {
                    Double total = Convert.ToDouble(tbGrams.Text) / .13;
                    tbRatti.Text = String.Format("{0:F3}", total);

                }
                else
                {
                    tbRatti.Text = "0";

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
            }
        }

        private void tbGoldRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbGoldRate.Text != "")
                {
                    Double total = Convert.ToDouble(tbTola.Text) * Convert.ToDouble(tbGoldRate.Text);
                    //tbTola.Text = total.ToString();
                    tbSubTotal.Text = String.Format("{0:F2}", total); // Show 2 Decimel Points

                }
                else
                {
                    tbSubTotal.Text = "0";

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
            }
        }

        private void tbLabour_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbLabour.Text != "")
                {
                    Double total = Convert.ToDouble(tbLabour.Text) + Convert.ToDouble(tbSubTotal.Text);
                    //tbTola.Text = total.ToString();
                    tbTotalPrice.Text = String.Format("{0:F2}", total); // Show 2 Decimel Points

                }
                
                else
                {
                    tbTotalPrice.Text = "0";

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Enter Digits!");
            }
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbMobile.Focus();
            }
        }

        private void tbMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAddress.Focus();
            }
        }

        private void tbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTagNo.Focus();
            }
        }

        private void tbGrams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPolish.Focus();
            }
        }

        private void tbPolish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbKaat.Focus();
            }
        }

        private void tbKaat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbGoldRate.Focus();
            }
        }

        private void tbGoldRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbLabour.Focus();
            }
        }

        private void tbLabour_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddCart.Focus();
            }
        }

        private void btnAddCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTagNo.Focus();
            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
              try
            {
            int cid = 0;
            ManageCustomer costumer = new ManageCustomer();
            costumer.CostumerName = tbName.Text;
            costumer.MobileNo = tbMobile.Text;
            costumer.CAddress = tbAddress.Text;
            cid = costumer.addCostumer();

            int oid = 0;
            ManageOrder order = new ManageOrder();
            order.CurrentDate = dtCurrentDate.Value;
            order.DueDate = dtDueDate.Value;
            order.ReciptNo = Convert.ToInt32(tbReceipt.Text);
            order.TotalBill = Convert.ToDouble(tbGrandTotal.Text);
            order.Advance = Convert.ToDouble(tbAdvance.Text);
            order.Balance = Convert.ToDouble(tbBalance.Text);
            order.Costumer_ID = cid;
            oid = order.addOrder();


            ManageOrderDetails orderDetails = new ManageOrderDetails();
            for (int i = 0; i < dgvDisplayOrder.Rows.Count; i++)
            {
                orderDetails.TagNo = dgvDisplayOrder.Rows[i].Cells[1].Value.ToString();
                orderDetails.Grams = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[3].Value);
                orderDetails.Polish = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[4].Value);
                orderDetails.Kaat = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[5].Value);
                orderDetails.Tola = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[6].Value);
                orderDetails.Masha = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[7].Value);
                orderDetails.Ratti = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[8].Value);
                orderDetails.GoldRate = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[9].Value);
                orderDetails.SubTotal = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[10].Value);
                orderDetails.Labour = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[11].Value);
                orderDetails.TotalPrice = Convert.ToDouble(dgvDisplayOrder.Rows[i].Cells[12].Value);
                orderDetails.Item_ID = Convert.ToInt32(dgvDisplayOrder.Rows[i].Cells[14].Value);
                orderDetails.Category_ID    = Convert.ToInt32(dgvDisplayOrder.Rows[i].Cells[15].Value);
                orderDetails.Issue_Qty = Convert.ToInt32(tbIssueQty.Text);
                orderDetails.ItemImage = imgPath;
                
                orderDetails.Order_ID = oid;
                orderDetails.addOrderDetails();
               



            }
            passingText = tbReceipt.Text;
             Utilities._Information("Submited");
             ReceiptPrint rf = new ReceiptPrint();
             rf.Show();
             ManageOrder mo = new ManageOrder();
             tbReceipt.Text = Convert.ToInt32(mo.gettOrder_by_RecpitNo()).ToString();
            //tbReceipt.Text = null;
            tbName.Text = null;
            tbMobile.Text = null;
            tbAddress.Text = null;
            tbGrandTotal.Text = null;
            tbAdvance.Text = null;
            tbBalance.Text = null;
            dgvDisplayOrder.DataSource = null;
            mylist.Clear();

            }
              catch (Exception)
              {
                  MessageBox.Show("Some fields are missing in Customer Details!",
                       "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
              }
        }

        private void Sale_Invoices_Form_Load(object sender, EventArgs e)
        {
            ManageOrder mo = new ManageOrder();
            tbReceipt.Text = Convert.ToInt32(mo.gettOrder_by_RecpitNo()).ToString();
        }

        private void btnRemoveCart_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDisplayOrder.SelectedRows)
            {
                mylist.RemoveAt(row.Index);
                dgvDisplayOrder.DataSource = mylist.ToList();
            }

            int sum = 0;
            for (int i = 0; i < dgvDisplayOrder.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dgvDisplayOrder.Rows[i].Cells[7].Value);

            }

            tbGrandTotal.Text = sum.ToString();
        }

        private void btnRecp_Click(object sender, EventArgs e)
        {
            ReceiptPrint rf = new ReceiptPrint();
            rf.Show();
        }

        private void tbTagNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
