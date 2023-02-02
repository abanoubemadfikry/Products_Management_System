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
    public partial class FRM_PRODUCTS_LIST : Form
    {
        BL.CLS_PRODUCTS productsobj = new BL.CLS_PRODUCTS();
        public FRM_PRODUCTS_LIST()
        {
            InitializeComponent();
            dataGridViewProducts.DataSource = productsobj.GetAllProducts();

        }

        private void FRM_PRODUCTS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewProducts_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
