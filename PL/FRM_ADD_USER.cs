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
    public partial class FRM_ADD_USER : Form
    {
        BL.CLS_LOGIN userobj = new BL.CLS_LOGIN();
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "حفظ المستخدم")
            {
                if (txtID.Text != string.Empty && txtpass.Text != string.Empty && txtFullName.Text != string.Empty
                    && txtConfirmPass.Text != string.Empty)
                {
                    userobj.AddUsers(txtID.Text, txtpass.Text, txtUserType.Text, txtFullName.Text);
                    MessageBox.Show("تم اضافه المستحدم بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(" من فضلك ادخل كل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtpass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show(" من فضلك ادخل كلمه سر متطابقه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "تعديل المستخدم")
            {
                if (txtID.Text != string.Empty && txtpass.Text != string.Empty && txtFullName.Text != string.Empty
                    && txtConfirmPass.Text != string.Empty)
                {
                    userobj.EditUsers(txtID.Text, txtpass.Text, txtUserType.Text, txtFullName.Text);
                    MessageBox.Show("تم تعديل المستحدم بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(" من فضلك ادخل كل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtpass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show(" من فضلك ادخل كلمه سر متطابقه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtConfirmPass.Clear();
            txtFullName.Clear();
            txtID.Clear();
            txtpass.Clear();
            txtUserType.Text = null;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtConfirmPass_Validated(object sender, EventArgs e)
        {
            if( txtpass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show(" من فضلك ادخل كلمه سر متطابقه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
