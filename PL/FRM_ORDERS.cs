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
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS orderobj = new BL.CLS_ORDERS();
        DataTable dt = new DataTable();
        void CreateDataTable()
        {
            dt.Columns.Add("معرف المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("الثمن ");
            dt.Columns.Add("الكميه");
            dt.Columns.Add("المبلغ");
            dt.Columns.Add("نسبه الخصم (%)");
            dt.Columns.Add("المبلغ الاجمالي ");
            dataGridViewProducts.DataSource = dt;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "اختيار منتج";
            //btn.Text = "Search";
            //btn.UseColumnTextForButtonValue = true;
            ////dataGridViewProducts.Columns.Insert(dt.Columns.Count, btn);
            //dataGridViewProducts.Columns.Insert(0, btn);
        }
        void ResizeDGV()
        {
            dataGridViewProducts.RowHeadersWidth = 121;
            dataGridViewProducts.Columns[0].Width = 154;
            dataGridViewProducts.Columns[1].Width = 171;
            dataGridViewProducts.Columns[2].Width = 107;
            dataGridViewProducts.Columns[3].Width = 128;
            dataGridViewProducts.Columns[4].Width = 222;
            dataGridViewProducts.Columns[5].Width = 103;
            dataGridViewProducts.Columns[6].Width = 142;
        }
        void CalculateMoney()

        {
            if (txtprdQuantity.Text != string.Empty && txtprdPrice.Text != string.Empty)
            {
                double r = Convert.ToDouble(txtprdQuantity.Text) * Convert.ToDouble(txtprdPrice.Text);
                txtprdMoney.Text = Convert.ToString(r);
            }
        }
        void clearBoxes()
        {
            txtPrdID.Clear();
            txtprdName.Clear();
            txtprdMoney.Clear();
            txtprdPrice.Clear();
            txtprdQuantity.Clear();
            txtprdDiscount.Clear();
            txtprdTotalprice.Clear();
            button1.Focus();
        }
        void clearAllData()
        {
            txtOrderID.Clear();
            txtOrderDesc.Clear();
            txtSalesMan.Clear();
            dateTimePicker1.ResetText();
            txtCustomerID.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtEmail.Clear();
            txtTEL.Clear();
            pictureBox1.Image = null;
            btnSave.Enabled = false;
            dt.Clear();
            dataGridViewProducts.DataSource = null;
        }
            
            void CalculateTotalMoney()
        {
            if (txtprdDiscount.Text != string.Empty&& txtprdMoney.Text!=string.Empty)
            {
                double amount = Convert.ToDouble(txtprdMoney.Text);
                double discount = Convert.ToDouble(txtprdDiscount.Text);
                double t = amount - ( amount*(discount / 100));
                txtprdTotalprice.Text = t.ToString();
            }
          
        }
        public FRM_ORDERS()
        {
           
            InitializeComponent();
            
            CreateDataTable();
            txtSalesMan.Text = Program.salesMan;
            //ResizeDGV();


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
             
            txtOrderID.Text = orderobj.GetLastOrderId().Rows[0][0].ToString();
            btnNew.Enabled = false;
         

        }

        private void btnGetCustomers_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST custlist = new FRM_CUSTOMERS_LIST();
            custlist.ShowDialog();
            txtCustomerID.Text = custlist.dataGridCustomers.CurrentRow.Cells[0].Value.ToString();
            txtFname.Text = custlist.dataGridCustomers.CurrentRow.Cells[1].Value.ToString();
            txtLname.Text = custlist.dataGridCustomers.CurrentRow.Cells[2].Value.ToString();
            txtTEL.Text = custlist.dataGridCustomers.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = custlist.dataGridCustomers.CurrentRow.Cells[4].Value.ToString();
            byte[] pic = (byte[])custlist.dataGridCustomers.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(ms);




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS_LIST prdlist = new FRM_PRODUCTS_LIST();
            prdlist.ShowDialog();
            txtPrdID.Text = prdlist.dataGridViewProducts.CurrentRow.Cells[0].Value.ToString();
            txtprdName.Text = prdlist.dataGridViewProducts.CurrentRow.Cells[1].Value.ToString();
            txtprdPrice.Text = prdlist.dataGridViewProducts.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void txtprdPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtprdPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtprdPrice.Text != string.Empty)
            {
                txtprdQuantity.Focus();
            }
        }

        private void txtprdQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtprdPrice.Text != string.Empty)
            {
                txtprdDiscount.Focus();
            }
        }

        private void txtprdPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateMoney();
            CalculateTotalMoney();
        }

        private void txtprdQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            
            CalculateMoney();
            CalculateTotalMoney();
        }

        private void txtprdDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            { 
                e.Handled = true;
            }
        }

        private void txtprdDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalMoney();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void txtprdDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (orderobj.VerifyQuantity(txtPrdID.Text, Convert.ToInt32(txtprdQuantity.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكميه المدخله لهذا المنتج غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                for (int i = 0; i < dataGridViewProducts.Rows.Count - 1; i++)
                {
                    if (dataGridViewProducts.Rows[i].Cells[0].Value.ToString() == txtPrdID.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRow r = dt.NewRow();
                r[0] = txtPrdID.Text;
                r[1] = txtprdName.Text;
                r[2] = txtprdPrice.Text;
                r[3] = txtprdQuantity.Text;
                r[4] = txtprdMoney.Text;
                r[5] = txtprdDiscount.Text;
                r[6] = txtprdTotalprice.Text;
                dt.Rows.Add(r);
                //dataGridViewProducts.DataSource = dt;
                
                clearBoxes();
                //txtSum.Text = (from DataGridViewRow row in dataGridViewProducts.Rows
                //               where row.Cells[6].FormattedValue.ToString() != string.Empty
                //               select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                try
                {
                    //
                    //double[] arr = new double[dataGridViewProducts.RowCount];
                    double sum = 0;
                    for (int i = 0; i < dataGridViewProducts.Rows.Count-1; i++)
                    {

                        sum+= Convert.ToDouble(dataGridViewProducts.Rows[i].Cells[6].Value.ToString());

                    }
                    txtSum.Text = sum.ToString();

                }
                catch 
                {

                    return;
                }
                
            }
        }

        private void txtSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewProducts_DoubleClick(object sender, EventArgs e)
        {
            txtPrdID.Text = dataGridViewProducts.CurrentRow.Cells[0].Value.ToString();
            txtprdName.Text = dataGridViewProducts.CurrentRow.Cells[1].Value.ToString();
            txtprdPrice.Text = dataGridViewProducts.CurrentRow.Cells[2].Value.ToString();
            txtprdQuantity.Text = dataGridViewProducts.CurrentRow.Cells[3].Value.ToString();
            txtprdMoney.Text = dataGridViewProducts.CurrentRow.Cells[4].Value.ToString();
            txtprdDiscount.Text = dataGridViewProducts.CurrentRow.Cells[5].Value.ToString();
            txtprdTotalprice.Text = dataGridViewProducts.CurrentRow.Cells[6].Value.ToString();
            dataGridViewProducts.Rows.RemoveAt(dataGridViewProducts.CurrentRow.Index);
            txtprdQuantity.Focus();


        }

        private void dataGridViewProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtSum.Text = (from DataGridViewRow row in dataGridViewProducts.Rows
                           where row.Cells[6].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewProducts_DoubleClick(sender, e);
        }

        private void حذفالسطرالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewProducts.Rows.RemoveAt(dataGridViewProducts.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridViewProducts.Refresh();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtPrdID.Text == string.Empty || txtOrderID.Text == string.Empty || dataGridViewProducts.Rows.Count < 1  || txtOrderDesc.Text == string.Empty)
            //{
            //    MessageBox.Show("  من فضللك ادخل المعلومات الناقصه ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            orderobj.AddOrders(Convert.ToInt32(txtOrderID.Text), Convert.ToDateTime(dateTimePicker1.Text),
                Convert.ToInt32(txtCustomerID.Text), txtOrderDesc.Text, txtSalesMan.Text);


            for (int i = 0; i < dataGridViewProducts.Rows.Count-1; i++)
            {
                orderobj.AddOrdersDetails(dataGridViewProducts.Rows[i].Cells[0].Value.ToString(),
                    Convert.ToInt32(txtOrderID.Text),
                    Convert.ToInt32(dataGridViewProducts.Rows[i].Cells[3].Value),
                    dataGridViewProducts.Rows[i].Cells[2].Value.ToString(),
                   Convert.ToInt32(dataGridViewProducts.Rows[i].Cells[5].Value),
                    dataGridViewProducts.Rows[i].Cells[4].Value.ToString(),
                    dataGridViewProducts.Rows[i].Cells[6].Value.ToString());
            }

            MessageBox.Show(" تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            clearAllData();
        }

        private void txtprdDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           // Cursor = Cursors.WaitCursor;
            int order_id =Convert.ToInt32(orderobj.GetLastOrderForPrint().Rows[0][0]);
            REPORT.rpt_orders report = new REPORT.rpt_orders();
            REPORT.FRM_REPORT_PRODUCT form = new REPORT.FRM_REPORT_PRODUCT();
            report.SetDataSource(orderobj.GetOrderDetails(order_id));
            form.crystalReportViewer1.ReportSource = report;
            form.ShowDialog();
        }
    }
}
