using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Products_Management.PL;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;


namespace Products_Management.PL
{
    public partial class FRM_CATEGORIES : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Server=DESKTOP-KRE083V;Database=Product2_DB;Integrated Security=true");
        DataTable dt=new DataTable();
        SqlDataAdapter dataAdapter;
        BindingManagerBase BMB;
        SqlCommandBuilder cmdbuilder;
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter("select id_cat,[DESCRIPTION_CAT] from categories", sqlcon);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt; 
            txtid.DataBindings.Add("text",dt, "id_cat");
            txtdescr.DataBindings.Add("text", dt, "DESCRIPTION_CAT");
            BMB = BindingContext[dt];
            labelposition.Text = (BMB.Position+1) + "/" + BMB.Count;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            BMB.Position -= 1;
            labelposition.Text = (BMB.Position + 1) + "/" + BMB.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BMB.Position += 1;
            labelposition.Text = (BMB.Position + 1) + "/" + BMB.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            BMB.Position = BMB.Count;
            labelposition.Text = (BMB.Position + 1) + "/" + BMB.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            BMB.Position = 0;
            labelposition.Text = (BMB.Position + 1) + "/" + BMB.Count;
        }

        private void labelposition_Click(object sender, EventArgs e)
        {
            labelposition.Text = (BMB.Position + 1) + "/" + BMB.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BMB.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            int id =Convert.ToInt32( dt.Rows[dt.Rows.Count-1][0])+1;
            txtid.Text = Convert.ToString(id);
            txtdescr.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BMB.EndCurrentEdit();
            cmdbuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dt);
            MessageBox.Show($"{txtdescr.Text} Added Successfully", "Add", MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            labelposition.Text = (BMB.Position + 1) + " / " + BMB.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BMB.RemoveAt(BMB.Position);
            BMB.EndCurrentEdit();
            cmdbuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dt);
            MessageBox.Show($"(Removed Successfully", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labelposition.Text=(BMB.Position+1) + " / "  + BMB.Count;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BMB.EndCurrentEdit();
            cmdbuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dt);
            MessageBox.Show($"Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labelposition.Text = (BMB.Position + 1) + " / " + BMB.Count;
        }

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {
            REPORT.FRM_REPORT_PRODUCT myForm = new REPORT.FRM_REPORT_PRODUCT();
            REPORT.rpt_single_category myReport = new REPORT.rpt_single_category();
            myReport.SetParameterValue("@ID", Convert.ToInt32(txtid.Text));
            myForm.crystalReportViewer1.ReportSource = myReport;
            myForm.ShowDialog();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            REPORT.FRM_REPORT_PRODUCT myform = new REPORT.FRM_REPORT_PRODUCT();
            REPORT.rpt_all_catego rpt = new REPORT.rpt_all_catego();
            rpt.Refresh();
            myform.crystalReportViewer1.ReportSource = rpt;
            myform.ShowDialog();

        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            REPORT.rpt_all_catego myReport = new REPORT.rpt_all_catego();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            dfoptions.DiskFileName = "A:\\All_Categories.pdf";
            export = myReport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            export.ExportFormatOptions = pdfformat;
            export.ExportDestinationOptions = dfoptions;
            myReport.Refresh();
            myReport.Export();
            MessageBox.Show("Done,,Exported successfully");
        }

        private void btnExportcurrent_Click(object sender, EventArgs e)
        {
            REPORT.rpt_single_category myReport = new REPORT.rpt_single_category();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            dfoptions.DiskFileName = "A:\\Category_Details.pdf";
            export = myReport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            export.ExportFormatOptions = pdfformat;
            export.ExportDestinationOptions = dfoptions;
            myReport.SetParameterValue("@ID", Convert.ToInt32(txtid.Text));
            myReport.Export();
            MessageBox.Show("Done,,Exported successfully");
        }
    }
}
