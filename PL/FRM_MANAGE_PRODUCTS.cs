using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
 

namespace Products_Management.PL
{

    public partial class FRM_MANAGE_PRODUCTS : Form
    {
        private static FRM_MANAGE_PRODUCTS frmproduct;

        static void frm_FormClose(object sender, FormClosedEventArgs e)
        {
            frmproduct = null;
        }
        public static FRM_MANAGE_PRODUCTS getMainForm
        {
            get
            {
                if (frmproduct == null)
                {
                    frmproduct = new FRM_MANAGE_PRODUCTS();
                    frmproduct.FormClosed += new FormClosedEventHandler(frm_FormClose);
                }
                return frmproduct;
            }
        }
        BL.CLS_PRODUCTS prodobj= new BL.CLS_PRODUCTS();
        
        public FRM_MANAGE_PRODUCTS()
        {
            InitializeComponent();
            if (frmproduct == null)
                frmproduct = this;
            dataGridView2.DataSource = prodobj.GetAllProducts();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = prodobj.SearchProducts(txtsearch.Text);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frmadd = new FRM_ADD_PRODUCT();
          
            frmadd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
           if( MessageBox.Show(" هل تريد حذف العنصر المحدد ؟","عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prodobj.Delete_Products(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عمليه الحذف بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dataGridView2.DataSource = prodobj.GetAllProducts();
            }
            else
            {

                MessageBox.Show("تم الغاء عمليه", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.txtRef.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
   
            frm.txtDescription.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm.txtQuantity.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            frm.comboBoxCategories.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "تحديث المنتج " + dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm.btnOk.Text = "تحديث";
            frm.state = "update";
            byte[] image = (byte[])prodobj.GetProductImage(dataGridView2.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_PREVIES frmp = new FRM_PREVIES();
            byte[] img = (byte[])prodobj.GetProductImage(dataGridView2.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            frmp.pictureBox1.Image = Image.FromStream(ms);
            frmp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            REPORT.rpt_all_products myReport = new REPORT.rpt_all_products();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            ExcelFormatOptions excelformat = new ExcelFormatOptions();
            dfoptions.DiskFileName = "A:\\ProductList4.xls";
            export = myReport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.Excel;
            export.ExportFormatOptions = excelformat;
            export.ExportDestinationOptions = dfoptions;
            myReport.Export();
            MessageBox.Show("Done,,Exported successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            REPORT.FRM_REPORT_PRODUCT frmRpt = new REPORT.FRM_REPORT_PRODUCT();
            REPORT.rpt_report_single rptprod = new REPORT.rpt_report_single();
            rptprod.SetParameterValue("@ID", dataGridView2.CurrentRow.Cells[0].Value.ToString());
            frmRpt.crystalReportViewer1.ReportSource = rptprod;
            frmRpt.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            REPORT.FRM_REPORT_PRODUCT form_rpt = new REPORT.FRM_REPORT_PRODUCT();
            REPORT.rpt_all_products report_all = new REPORT.rpt_all_products();
            form_rpt.crystalReportViewer1.ReportSource = report_all;
            form_rpt.ShowDialog();
            
        }
    }
}
