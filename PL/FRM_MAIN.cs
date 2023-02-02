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
    public partial class FRM_MAIN : Form
    {
        //single instance
        private static FRM_MAIN frm_main;
        static void frm_FormClose(object sender,FormClosedEventArgs e)
        {
            frm_main = null;
        }
        public static FRM_MAIN getMainForm
        {
            get
            {
                if (frm_main == null)
                {
                    frm_main = new FRM_MAIN();
                    frm_main.FormClosed += new FormClosedEventHandler(frm_FormClose);
                }
                return frm_main;
            }
        }
        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm_main == null)
                frm_main = this;

            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.انشاءنسخهاحتياطيهToolStripMenuItem.Enabled = false;
            this.استعادهنسخهمحفوظهToolStripMenuItem.Enabled = false;
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN loginfrm = new FRM_LOGIN();
            loginfrm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void اضافهمنتوججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT addProductfrm = new FRM_ADD_PRODUCT();
            addProductfrm.ShowDialog();
        }

        private void ادارهالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_MANAGE_PRODUCTS manageprdform = new FRM_MANAGE_PRODUCTS();
            manageprdform.ShowDialog();
        }

        private void ادارهالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frmCategories = new FRM_CATEGORIES();
            frmCategories.ShowDialog();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ادارهالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS frmcustomer = new FRM_CUSTOMERS();
            frmcustomer.ShowDialog();
        }

        private void اضافهبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void ادارهالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS_LIST frm = new FRM_ORDERS_LIST();
            frm.ShowDialog();
        }

        private void اضافهمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void ادارهالمستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_LIST frm = new FRM_USER_LIST();
            frm.ShowDialog();
        }

        private void اضافهعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
