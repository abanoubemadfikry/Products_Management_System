using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management.PL
{
    public partial class FRM_ORDERS_LIST : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        public FRM_ORDERS_LIST()
        {
            InitializeComponent();
            datgridorders.DataSource = order.SearchOrders("");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_ORDERS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                datgridorders.DataSource = order.SearchOrders(txtsearch.Text);
            }
            catch
            {

                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            REPORT.FRM_REPORT_PRODUCT myform = new REPORT.FRM_REPORT_PRODUCT();
            REPORT.rpt_orders myreport = new REPORT.rpt_orders();
            int order_id = Convert.ToInt32(datgridorders.CurrentRow.Cells[0].Value);
            myreport.SetDataSource(order.GetOrderDetails(order_id));
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
