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
    public partial class FRM_USER_LIST : Form
    {
        BL.CLS_LOGIN usersobj = new BL.CLS_LOGIN();
        public FRM_USER_LIST()
        {
            InitializeComponent();
            datgridusers.DataSource = usersobj.SearchUsers("");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.btnSave.Text = "حفظ المستخدم";
            frm.ShowDialog();
            datgridusers.DataSource = usersobj.SearchUsers("");
        }

        private void FRM_USER_LIST_Load(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            datgridusers.DataSource = usersobj.SearchUsers(txtsearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.txtID.Text = datgridusers.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullName.Text = datgridusers.CurrentRow.Cells[1].Value.ToString();
            frm.txtpass.Text = datgridusers.CurrentRow.Cells[2].Value.ToString();
            frm.txtConfirmPass.Text = datgridusers.CurrentRow.Cells[2].Value.ToString();
            frm.txtUserType.Text = datgridusers.CurrentRow.Cells[3].Value.ToString();
            frm.btnSave.Text = "تعديل المستخدم";
            frm.ShowDialog();
            datgridusers.DataSource = usersobj.SearchUsers("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" هل تريد حذف العنصر المحدد ؟", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
               usersobj.Delete_User(datgridusers.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عمليه الحذف بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                datgridusers.DataSource = usersobj.SearchUsers("");
            }
            else
            {

                MessageBox.Show("تم الغاء عمليه", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
