using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    class CLS_LOGIN
    {
        public DataTable LOGIN(string ID, string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID"/*اللي جاي من ال storedprocedure*/, SqlDbType.VarChar, 50);
            param[0].Value = ID;//
            param[1] = new SqlParameter("@PWD"/*اللي جاي من ال storedprocedure*/, SqlDbType.VarChar, 50);
            param[1].Value = PWD;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SP_LOGIN", param);
            DAL.Close();
            return dt;
        }
        public void AddUsers(string user_id,string pass,string user_type,string fullname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@USER_ID", SqlDbType.NVarChar, 50);
            parameters[0].Value = user_id;

            parameters[1] = new SqlParameter("@PASSWORD", SqlDbType.NVarChar, 50);
            parameters[1].Value = pass;

            parameters[2] = new SqlParameter("@USERTYPE", SqlDbType.NVarChar, 50);
            parameters[2].Value = user_type;

            parameters[3] = new SqlParameter("@FULLNAME", SqlDbType.NVarChar, 50);
            parameters[3].Value = fullname;

            dal.ExecuteCommand("Add_User", parameters);
            dal.Close();
        }
        public DataTable SearchUsers(string criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@criterion", SqlDbType.VarChar, 50);
            param[0].Value = criterion;
            dt = DAL.SelectData("Search_Users", param);
            DAL.Close();
            return dt;
                
        }
        public void EditUsers(string user_id, string pass, string user_type, string fullname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@USER_ID", SqlDbType.NVarChar, 50);
            parameters[0].Value = user_id;

            parameters[1] = new SqlParameter("@PASSWORD", SqlDbType.NVarChar, 50);
            parameters[1].Value = pass;

            parameters[2] = new SqlParameter("@USERTYPE", SqlDbType.NVarChar, 50);
            parameters[2].Value = user_type;

            parameters[3] = new SqlParameter("@FULLNAME", SqlDbType.NVarChar, 50);
            parameters[3].Value = fullname;

            dal.ExecuteCommand("Edit_User", parameters);
            dal.Close();
        }
        public void Delete_User(string Id)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = Id;
            DAL.ExecuteCommand("Delete_User", param);
            DAL.Close();
        }
    }
}
