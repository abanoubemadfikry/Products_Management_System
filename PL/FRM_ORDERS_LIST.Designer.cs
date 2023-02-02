namespace Products_Management.PL
{
    partial class FRM_ORDERS_LIST
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
            this.datgridorders = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datgridorders)).BeginInit();
            this.SuspendLayout();
            // 
            // datgridorders
            // 
            this.datgridorders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datgridorders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datgridorders.Location = new System.Drawing.Point(117, 111);
            this.datgridorders.Name = "datgridorders";
            this.datgridorders.RowHeadersWidth = 51;
            this.datgridorders.RowTemplate.Height = 24;
            this.datgridorders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datgridorders.Size = new System.Drawing.Size(922, 409);
            this.datgridorders.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(106, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 444);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لائحه المبيعات";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(409, 45);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(509, 22);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ادخل الكلمه التي تريد البحث عنها";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(312, 561);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(239, 40);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "طباعه";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(634, 561);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "الخروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRM_ORDERS_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 613);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.datgridorders);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.Name = "FRM_ORDERS_LIST";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اداره المبيعات";
            this.Load += new System.EventHandler(this.FRM_ORDERS_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datgridorders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView datgridorders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}