namespace Products_Management.PL
{
    partial class FRM_CUSTOMERS_LIST
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
            this.dataGridCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCustomers
            // 
            this.dataGridCustomers.AllowUserToAddRows = false;
            this.dataGridCustomers.AllowUserToDeleteRows = false;
            this.dataGridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCustomers.Location = new System.Drawing.Point(0, 0);
            this.dataGridCustomers.Name = "dataGridCustomers";
            this.dataGridCustomers.ReadOnly = true;
            this.dataGridCustomers.RowHeadersWidth = 51;
            this.dataGridCustomers.RowTemplate.Height = 24;
            this.dataGridCustomers.Size = new System.Drawing.Size(953, 450);
            this.dataGridCustomers.TabIndex = 0;
            this.dataGridCustomers.DoubleClick += new System.EventHandler(this.dataGridCustomers_DoubleClick);
            // 
            // FRM_CUSTOMERS_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.dataGridCustomers);
            this.Name = "FRM_CUSTOMERS_LIST";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لائحه العملاء";
            this.Load += new System.EventHandler(this.FRM_CUSTOMERS_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridCustomers;
    }
}