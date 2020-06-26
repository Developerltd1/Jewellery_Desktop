using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShahiApplication.SMSForm
{
    public partial class SMSAlertForm : Form
    {
        public SMSAlertForm()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
    
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
     
        }

        private void button11_Click(object sender, EventArgs e)
        {
         
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void SMSAlertForm_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnStockBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;   
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked = true)
            {
                checkedListBox1.SetItemChecked(0, true);
                checkedListBox1.SetItemChecked(1, true);
                checkedListBox1.SetItemChecked(2, true);
                checkedListBox1.SetItemChecked(3, true);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Message Sended Successfully");
        }
    }
}
