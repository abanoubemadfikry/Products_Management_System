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
    public partial class FRM_CUSTOMERS_LIST : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();
            dataGridCustomers.DataSource = cust.GetALLCustomers();
            dataGridCustomers.Columns[0].Visible = false;
            dataGridCustomers.Columns[5].Visible = false;
        }

        private void FRM_CUSTOMERS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void dataGridCustomers_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
