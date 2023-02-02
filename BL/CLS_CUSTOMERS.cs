using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    class CLS_CUSTOMERS
    {
        public void AddCustomers(string fname, string lname, string tel, string email, byte[] image)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@FNAME", SqlDbType.NVarChar, 30);
            param[0].Value = fname;

            param[1] = new SqlParameter("@LNAME", SqlDbType.NVarChar, 30);
            param[1].Value = lname;

            param[2] = new SqlParameter("@TEL", SqlDbType.NChar,15);
            param[2].Value = tel;

            param[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 25);
            param[3].Value = email;

            param[4] = new SqlParameter("@PICTURE", SqlDbType.Image);
            param[4].Value = image;

            DAL.ExecuteCommand("ADD_CUSTOMERS",param);
            DAL.Close();

        }
        public DataTable GetALLCustomers()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable DT = new DataTable();
;            DT = DAL.SelectData("Get_All_Customers", null);
            DAL.Close();
            return DT;

        }
        public void EditCustomers(string fname, string lname, string tel, string email, byte[] image,int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@FNAME", SqlDbType.NVarChar, 30);
            param[0].Value = fname;

            param[1] = new SqlParameter("@LNAME", SqlDbType.NVarChar, 30);
            param[1].Value = lname;

            param[2] = new SqlParameter("@TEL", SqlDbType.NChar, 15);
            param[2].Value = tel;

            param[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 25);
            param[3].Value = email;

            param[4] = new SqlParameter("@PICTURE", SqlDbType.Image);
            param[4].Value = image;

            param[5] = new SqlParameter("@ID", SqlDbType.Int);
            param[5].Value = id;

            DAL.ExecuteCommand("Edit_Customers", param);
            DAL.Close();
        }
        public void DeleteCustomer(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;

            DAL.ExecuteCommand("Delete_Customer", param);
            DAL.Close();

        }
        public DataTable SearcCustomers(string criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable DT = new DataTable();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@criterion", SqlDbType.NVarChar);
            param[0].Value = criterion;

            DT = DAL.SelectData("Search_Customers", param);
            DAL.Close();
            return DT;
        }
    }
}
