using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Products_Management.PL
{
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_CUSTOMERS customer = new BL.CLS_CUSTOMERS();
        int position;
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            dataGridView1.DataSource = customer.GetALLCustomers();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] pic = ms.ToArray();
                customer.AddCustomers(txtFname.Text, txtLname.Text, txtTEL.Text, txtEmail.Text, pic);
                MessageBox.Show("تمت بنجاح", "الاضافه ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = customer.GetALLCustomers();
            }
            catch 
            {

                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter= "ملفات الصور |*.JPG; *.PNG; *.GIF; *.BMB";
            if (openfile.ShowDialog() == DialogResult.OK)
            { 
                pictureBox1.Image = Image.FromFile(openfile.FileName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFname.Clear();
            txtLname.Clear();
            txtTEL.Clear();
            txtEmail.Clear();
            txtFname.Focus();
        }

        private void txtFname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLname.Focus();
            }
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtLname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTEL.Focus();
            }
        }

        private void txtTEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            byte[] picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(picture);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txtFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTEL.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            byte[] picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(picture);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();  
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] pic = ms.ToArray();  
            customer.EditCustomers(txtFname.Text, txtLname.Text, txtTEL.Text,
                txtEmail.Text, pic,Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            MessageBox.Show("تم التعديل بنجاح", "التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = customer.GetALLCustomers();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف العنصر المحدد؟", "الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                customer.DeleteCustomer(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                MessageBox.Show("تم الحذف بنجاح", "الحذف ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = customer.GetALLCustomers();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customer.SearcCustomers(txtSearch.Text);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = customer.GetALLCustomers().Rows.Count - 1;
            Navigate(position);
        }
        void Navigate (int index)
        {
            
            try
            {
                pictureBox1.Image = null;
                DataRowCollection drc = customer.GetALLCustomers().Rows;
                txtFname.Text = drc[index][1].ToString();
                txtLname.Text = drc[index][2].ToString();
                txtTEL.Text = drc[index][3].ToString();
                txtEmail.Text = drc[index][4].ToString();
                byte[] picture = (byte[])drc[index][5];
                MemoryStream ms = new MemoryStream(picture);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch 
            {

                return;
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (position == customer.GetALLCustomers().Rows.Count-1)
            {
                MessageBox.Show("last item");
            }
           
            position += 1;
            Navigate(position);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
            if (position == 0)
            {
                MessageBox.Show("first item");
                return;
            }

            position -= 1;
            Navigate(position);
        }

        private void labelposition_Click(object sender, EventArgs e)
        {

        }
    }
}
