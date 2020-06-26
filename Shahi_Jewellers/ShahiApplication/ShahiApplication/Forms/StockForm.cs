using ShahiApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }
        StringBuilder sb = new StringBuilder();
        ManageCategory category = new ManageCategory();
        ManageItems items = new ManageItems();
        ManageStock stock = new ManageStock();
        SqlDataReader dr;
        SqlCommand cmd;
        string imgpath;
        string ch_imgPath;

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            category.CategoryName = tbName.Text;
            int condition = category.insertCategory();

            if (condition > 0)
            {
                MessageBox.Show("Record Added Successfully");
            }
            else
                MessageBox.Show("Try Again");
             tbName.Text = "";
            dataGridView3.DataSource = category.getAllCategory();
         }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            category.CategoryName = tbName.Text;
            category.CategoryID = Convert.ToInt32(tbID.Text);
            int condition = category.UpdateCategory();
              if (condition > 0)
            {
                MessageBox.Show("Record Updated Successfully");
            }
            else
                MessageBox.Show("Try Again");
            tbID.Text = "";
            tbName.Text = "";
            dataGridView3.DataSource = category.getAllCategory();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            category.CategoryName = tbName.Text;
            category.CategoryID = Convert.ToInt32(tbID.Text);
            int Condition = category.deleteCategory();
            if (Condition > 0)
            {
                MessageBox.Show("Record Deleted Successfully");
            }
            else
                MessageBox.Show("Try Again");
            tbID.Text = "";
            tbName.Text = "";
            dataGridView3.DataSource = category.getAllCategory();

        }
        private void StockForm_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = category.getAllCategory();
            dgvItem.DataSource = items.getAllItems();
            dgvStock.DataSource = stock.getAllStock();

            cbCategory.DataSource = category.getAllCategory();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

            cbStockCategory.DataSource = category.getAllCategory();
            cbStockCategory.DisplayMember = "CategoryName";
            cbStockCategory.ValueMember = "CategoryID";

        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                tbID.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
            }
        }
        private void btnSaveItem_Click(object sender, EventArgs e)
        {    
            items.ItemName = tbItem.Text;
            items.Category_ID = Convert.ToInt32(cbCategory.SelectedValue);
            items.Abrivation = tbTag.Text;
            int condition = items.insertItem();
            if(condition > 0)
            {
                MessageBox.Show("Record Added Successfully");
                dgvItem.DataSource = items.getAllItems();
            }
            else
                MessageBox.Show("Try Again");
            tbItem.Text = "";
            cbCategory.Text = "";
            tbTag.Text = "";
            dgvItem.DataSource = items.getAllItems();
        }
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            items.ItemName = tbItem.Text;
            items.Category_ID = Convert.ToInt32(cbCategory.SelectedValue);
            items.ItemID = Convert.ToInt32(tbItemID.Text);
            items.Abrivation = tbTag.Text;
            int condition = items.UpdateItem();
            if (condition > 0)
            {
                MessageBox.Show("Record Updated Successfully");
                dgvItem.DataSource = items.UpdateItem();
            }
            else
                MessageBox.Show("Try Again");
            tbItem.Text = "";
            cbCategory.Text = "";
            tbTag.Text = "";
            dgvItem.DataSource = items.getAllItems();
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            items.ItemID = Convert.ToInt32(tbItemID.Text);
            int condition = items.deleteItem();
            if (condition > 0)
            {
                MessageBox.Show("Record Deleted Successfully");
                dgvItem.DataSource = items.UpdateItem();
            }
            else
                MessageBox.Show("Try Again");
            tbItem.Text = "";
            cbCategory.Text = "";
            tbTag.Text = "";
            dgvItem.DataSource = items.getAllItems();
        }   
        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvItem.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                tbItemID.Text = row.Cells[0].Value.ToString();
                tbItem.Text = row.Cells[1].Value.ToString();
                tbTag.Text = row.Cells[2].Value.ToString();
                cbCategory.Text = row.Cells[3].Value.ToString();
            }
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            //TAB Available_Stock
            cbAvCategory.DataSource = category.getAllCategory();
            cbAvCategory.DisplayMember = "CategoryName";
            cbAvCategory.ValueMember = "CategoryID";

            //TAB Add_Stock
            cbCategory.DataSource = category.getAllCategory();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

            //Stock Status
            ManageStock stock = new ManageStock();
            dgvAvailableStock.DataSource = stock.AllItems_StockStatus();

        }
        private void cbStockCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ManageItems item = new ManageItems();
            cbStockItem.DataSource = item.getItemOfCategory(Convert.ToInt32(cbStockCategory.SelectedValue));
            cbStockItem.ValueMember = "ItemID";
            cbStockItem.DisplayMember = "ItemName";
        }
        private void btnSaveStock_Click(object sender, EventArgs e)
        {
            try
            {
                stock.Category_ID = Convert.ToInt32(cbStockCategory.SelectedValue);
                stock.Item_ID = Convert.ToInt32(cbStockItem.SelectedValue);
               // stock.TagNo = Convert.ToInt32(lblTagNo.Text);             
               
                stock.TagNo = Convert.ToInt32(tbTagNo.Text.Substring(2));
                stock.EntryDate = dtStock.Value;
                stock.Carat = cbCarat.SelectedItem.ToString();
                stock.StockQty = Convert.ToInt32(tbQty.Text);
                stock.StockImage = imgpath;

                int condition = stock.insertStock();
                if (condition > 0)
                {
                    Utilities._Information("Record Added Successfully");
                    dgvStock.DataSource = stock.getAllStock();
                }
                else
                {
                    Utilities._Exclamation("Try Again");
                   
                              }
                dgvStock.DataSource = stock.getAllStock();
                cbStockCategory.Text = "";
                cbStockItem.Text = "";
                tbTagNo.Text = "";
                dtStock.Text = "";
                cbCarat.Text = "";
                tbQty.Text = "";
                imgSelect.Image = null;
                imgpath = null;
            }
            catch (Exception ex)
           {
                Utilities._Error("Fill all fields then save ");
            }
   
            }
        private void cbStockItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ManageStock stock = new ManageStock();
            tbTagNo.Text = stock.GetAbvofItem(Convert.ToInt32(cbStockItem.SelectedValue)).ToString();
             tbTagNo.Text += stock.getTagNoOfItem(Convert.ToInt32(cbStockItem.SelectedValue)).ToString();
             //lblTagNo.Text = stock.getTagNoOfItem(Convert.ToInt32(cbStockItem.SelectedValue)).ToString();         
        }
    
        private void btnStockBack_Click(object sender, EventArgs e)
        {         
            this.Visible = false;        
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.pdf;)|*.jpg; *.jpeg; *.gif; *.bmp; *.pdf;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //Showing in PictureBox
                    imgSelect.Image = new Bitmap(open.FileName);
                    //Storeing ImagePath in Database
                    imgpath = open.FileName;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void dgvAvailableStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
         


            // int itemid = Select itemid from itemid where abv = abv  

           //  Select * from stock where item_id = tbItemID and tagno= num 

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnStockSearch_Click(object sender, EventArgs e)
        {
            string abv = tbSearchTagNo.Text.Substring(0, 2);

            int num = Convert.ToInt32(tbSearchTagNo.Text.Substring(2));





            int itemid = stock.SearchItemIDThroughAbv(abv);


           // dgvCheckStock.DataSource = stock.GetStockbyItemIDandTagNo(itemid, num);
        }

        private void cbAvCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ManageItems item = new ManageItems();
            cbAvItem.DataSource = item.getItemOfCategory(Convert.ToInt32(cbAvCategory.SelectedValue));
            cbAvItem.ValueMember = "ItemID";
            cbAvItem.DisplayMember = "ItemName";
        }

       

        private void cbAvItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ITEMS
            //    MngStock st = new MngStock();
            //    tbAvailableQty.Text = st.checkAvailableStockQtyofProduct(Convert.ToInt32(cbProduct.SelectedValue)).ToString();
            dgvAvailableStock.DataSource = stock.CheckItems_fromStock(Convert.ToInt32(cbAvCategory.SelectedValue), Convert.ToInt32(cbAvItem.SelectedValue));
        }

        private void btnStockSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                string abv = tbSearchTagNo.Text.Substring(0, 2);
                int num = Convert.ToInt32(tbSearchTagNo.Text.Substring(2));
                int itemid = stock.SearchItemIDThroughAbv(abv);
                //AQIB
                DataTable mydt = new DataTable();
                mydt = stock.GetStockbyItemIDandTagNo(itemid, num);
                ch_tbCategory.Text = mydt.Rows[0][1].ToString();
                ch_tbItem.Text = mydt.Rows[0][2].ToString();
                ch_tbTag.Text = mydt.Rows[0][3].ToString();
                ch_tbDate.Text = mydt.Rows[0][4].ToString();
                ch_tbCart.Text = mydt.Rows[0][5].ToString();
                ch_tbStockQty.Text = mydt.Rows[0][6].ToString();
                DataRow dr = mydt.Rows[0];
                ch_imgPath = dr["StockImage"].ToString();
                ch_DisplayImage.Image = System.Drawing.Image.FromFile(ch_imgPath);
            }
            catch (Exception)
            {
                Utilities._Warning("No Record Found!");
            }
        }

        private void btnCleaar_Click(object sender, EventArgs e)
        {
            tbSearchTagNo.Text = "";
            ch_tbCategory.Text = "";
            ch_tbItem.Text = "";
            ch_tbTag.Text = "";
            ch_tbDate.Text = "";
            ch_tbCart.Text = "";
            ch_tbStockQty.Text = "";
            ch_imgPath = null;
            ch_DisplayImage.Image = null;
        }

        private void tbSearchTagNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    string abv = tbSearchTagNo.Text.Substring(0, 2);
                    int num = Convert.ToInt32(tbSearchTagNo.Text.Substring(2));
                    int itemid = stock.SearchItemIDThroughAbv(abv);
                    //AQIB
                    DataTable mydt = new DataTable();
                    mydt = stock.GetStockbyItemIDandTagNo(itemid, num);
                    ch_tbCategory.Text = mydt.Rows[0][2].ToString();
                    ch_tbItem.Text = mydt.Rows[0][3].ToString();
                    ch_tbTag.Text = mydt.Rows[0][4].ToString();
                    ch_tbDate.Text = mydt.Rows[0][5].ToString();
                    ch_tbCart.Text = mydt.Rows[0][6].ToString();
                    ch_tbStockQty.Text = mydt.Rows[0][7].ToString();
                    DataRow dr = mydt.Rows[0];
                    ch_imgPath = dr["StockImage"].ToString();
                    ch_DisplayImage.Image = System.Drawing.Image.FromFile(ch_imgPath);
                }
                catch (Exception)
                {
                    Utilities._Warning("No Record Found!");
                }
                e.Handled = true;
            }
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvStock.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                cbCategory.Text = row.Cells[0].Value.ToString();
                cbStockItem.Text = row.Cells[1].Value.ToString();
                tbTagNo.Text = row.Cells[2].Value.ToString();
                dtStock.Text = row.Cells[3].Value.ToString();
                cbCarat.Text = row.Cells[4].Value.ToString();
                tbQty.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {

        }



    }
}