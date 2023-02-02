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


namespace Products_Management.PL
{
    public partial class FRM_ADD_PRODUCT : Form
    {
        BL.CLS_PRODUCTS productsobj = new BL.CLS_PRODUCTS();
        public string state = "add";
        public FRM_ADD_PRODUCT()
        {
            
            InitializeComponent();
            comboBoxCategories.DataSource = productsobj.Get_All_Categories();
            comboBoxCategories.DisplayMember = "DESCRIPTION_CAT";
            comboBoxCategories.ValueMember = "ID_CAT";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "ملفات الصور |*.JPG; *.PNG; *.GIF; *.BMB";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteimg = ms.ToArray();

                productsobj.Add_Products(Convert.ToInt32(comboBoxCategories.SelectedValue),
                    txtDescription.Text, txtRef.Text,
                    Convert.ToInt32(txtQuantity.Text), txtPrice.Text,
                    (byteimg));
                MessageBox.Show("تمت بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           
            }
            else
            {
                //FRM_MANAGE_PRODUCTS frmmanage = new FRM_MANAGE_PRODUCTS();
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteimg = ms.ToArray();

                productsobj.UpdateProducts(Convert.ToInt32(comboBoxCategories.SelectedValue), txtDescription.Text,
                    txtRef.Text, Convert.ToInt32(txtQuantity.Text), txtPrice.Text, byteimg);
                MessageBox.Show("تم التعديل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               //frmmanage.ShowDialog();
            }
            FRM_MANAGE_PRODUCTS.getMainForm.dataGridView2.DataSource = productsobj.GetAllProducts();
        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable DT = new DataTable();
                DT = productsobj.VerifyProductId(txtRef.Text);
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("Product id Already Exist,enter unique one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.Text.Length;
                }
            }
           
        }

        private void txtRef_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
