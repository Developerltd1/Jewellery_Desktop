namespace ShahiApplication.Forms
{
    partial class ReceiptPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uspReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shahiDBDataSet = new ShahiApplication.ShahiDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_ReceiptTableAdapter = new ShahiApplication.ShahiDBDataSetTableAdapters.usp_ReceiptTableAdapter();
            this.label12 = new System.Windows.Forms.Label();
            this.tbReceipt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uspReceiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shahiDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // uspReceiptBindingSource
            // 
            this.uspReceiptBindingSource.DataMember = "usp_Receipt";
            this.uspReceiptBindingSource.DataSource = this.shahiDBDataSet;
            // 
            // shahiDBDataSet
            // 
            this.shahiDBDataSet.DataSetName = "ShahiDBDataSet";
            this.shahiDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 6;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uspReceiptBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ShahiApplication.Reports.Receipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(696, 535);
            this.reportViewer1.TabIndex = 0;
            // 
            // usp_ReceiptTableAdapter
            // 
            this.usp_ReceiptTableAdapter.ClearBeforeFill = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 504);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 18);
            this.label12.TabIndex = 35;
            this.label12.Text = "Recipt No :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Visible = false;
            // 
            // tbReceipt
            // 
            this.tbReceipt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReceipt.Enabled = false;
            this.tbReceipt.Location = new System.Drawing.Point(32, 505);
            this.tbReceipt.Name = "tbReceipt";
            this.tbReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbReceipt.Size = new System.Drawing.Size(69, 20);
            this.tbReceipt.TabIndex = 36;
            this.tbReceipt.TabStop = false;
            this.tbReceipt.Visible = false;
            // 
            // ReceiptPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 538);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbReceipt);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReceiptPrint";
            this.Text = "ReceiptPrint";
            this.Load += new System.EventHandler(this.ReceiptPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspReceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shahiDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uspReceiptBindingSource;
        private ShahiDBDataSet shahiDBDataSet;
        private ShahiDBDataSetTableAdapters.usp_ReceiptTableAdapter usp_ReceiptTableAdapter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbReceipt;
    }
}