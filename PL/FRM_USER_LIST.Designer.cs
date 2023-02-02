namespace Products_Management.PL
{
    partial class FRM_USER_LIST
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.datgridusers = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datgridusers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(787, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "الخروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(134, 535);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(151, 40);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "اضافه مستخدم جديد";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // datgridusers
            // 
            this.datgridusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datgridusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datgridusers.Location = new System.Drawing.Point(117, 96);
            this.datgridusers.Name = "datgridusers";
            this.datgridusers.RowHeadersWidth = 51;
            this.datgridusers.RowTemplate.Height = 24;
            this.datgridusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datgridusers.Size = new System.Drawing.Size(922, 409);
            this.datgridusers.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(106, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 444);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لائحه المستخدمين";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(409, 30);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(509, 22);
            this.txtsearch.TabIndex = 11;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "ادخل الكلمه التي تريد البحث عنها";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "تعديل المستخدم المحدد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(504, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = "حذف المستخدم المحدد";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FRM_USER_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 606);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.datgridusers);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.Name = "FRM_USER_LIST";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اداره المستخدمين";
            this.Load += new System.EventHandler(this.FRM_USER_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datgridusers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.DataGridView datgridusers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}