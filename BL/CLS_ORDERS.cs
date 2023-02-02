using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Products_Management.BL
{
    class CLS_ORDERS
    {
        public DataTable GetLastOrderId()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable DT = new DataTable();
            DAL.open();
            DT = DAL.SelectData("Get_Last_Order_id", null);
            DAL.Close();
            return DT;
        }

        public void AddOrders(int ordeId, DateTime orderDate, int customerId, string orderDescription, string salesMan)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ordeId;

            param[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            param[1].Value = orderDate;

            param[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            param[2].Value = customerId;

            param[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.NVarChar, 250);
            param[3].Value = orderDescription;

            param[4] = new SqlParameter("@SALESMAN", SqlDbType.NVarChar, 75);
            param[4].Value = salesMan;

            DAL.ExecuteCommand("Add_Order", param);
            DAL.Close();
        }
        public void AddOrdersDetails(string productId, int ordeId, int quantity, string price, float discount, string amount, string totalAmount)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[0].Value = productId;

            param[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[1].Value = ordeId;

            param[2] = new SqlParameter("@QUANTITY", SqlDbType.Int);
            param[2].Value = quantity;

            param[3] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[3].Value = price;

            param[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            param[4].Value = discount;

            param[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 75);
            param[5].Value = amount;

            param[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 75);
            param[6].Value = totalAmount;

            DAL.ExecuteCommand("Add_Order_Details", param);
            DAL.Close();
        }
        public DataTable VerifyQuantity(string id_product,int quantity)
        {
            DataTable dt = new DataTable();
            DAL.DataAccessLayer DAl = new DAL.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.VarChar, 30);
            param[0].Value = id_product;

            param[1] = new SqlParameter("@Qty_entered", SqlDbType.Int);
            param[1].Value = quantity;
            dt = DAl.SelectData("Verify_Quantity", param);
            DAl.Close();
            return dt;
        }
        public DataTable GetLastOrderForPrint()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable DT = new DataTable();
            DAL.open();
            DT = DAL.SelectData("Get_Last_Order_For_Print", null);
            DAL.Close();
            return DT;
        }

        public DataTable GetOrderDetails(int id_order)
        {
            DataTable dt = new DataTable();
            DAL.DataAccessLayer DAl = new DAL.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            

            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;
            dt = DAl.SelectData("Get_Order_Details", param);
            DAl.Close();
            return dt;
        }
        public DataTable SearchOrders(string criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@criterion", SqlDbType.VarChar);
            param[0].Value = criterion;
            dt = DAL.SelectData("Search_Orders", param);
            DAL.Close();
            return dt;
        }
    }
}
