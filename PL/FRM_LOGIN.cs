using System;
using System.Windows.Forms;
using System.Data;

namespace Products_Management.PL
{
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                FRM_MAIN.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.المستخدمونToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.انشاءنسخهاحتياطيهToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.استعادهنسخهمحفوظهToolStripMenuItem.Enabled = true;
                Program.salesMan = dt.Rows[0]["FullName"].ToString();
                Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

            
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPWD.Focus();
            }
        }

        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }
    }
}
