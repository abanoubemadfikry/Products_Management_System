using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    
    class CLS_PRODUCTS
    {
        
        
        public DataTable Get_All_Categories()
        {
            DAL.DataAccessLayer DAL2 = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL2.SelectData("Get_All_Categories_Procedure", null);
            DAL2.Close();
            return dt;           
        }
        public void Add_Products(int ID_cat,string LABEL_PRODUCT, string ID_PRODUCT, int QUANTITY ,string PRICE ,byte[] IMAGE_PRD)
        {
            
            DAL.DataAccessLayer DAL3 = new DAL.DataAccessLayer();
            DAL3.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[1].Value = ID_PRODUCT;

            param[2] = new SqlParameter("@LABEL_PRODUCT", SqlDbType.NVarChar, 50);
            param[2].Value = LABEL_PRODUCT;

            param[3] = new SqlParameter("@QUANTITY", SqlDbType.Int);
            param[3].Value = QUANTITY;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar,30);
            param[4].Value = PRICE;

            param[5] = new SqlParameter("@IMAGE_PRD", SqlDbType.Image);
            param[5].Value = IMAGE_PRD;

            DAL3.ExecuteCommand("Add_Products", param);
            DAL3.Close(); 
                
        }
        public DataTable VerifyProductId(string prd_id)
        {
            DAL.DataAccessLayer DAL4 = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] paramid = new SqlParameter[1];

            paramid[0]=new SqlParameter("@ID",SqlDbType.VarChar,50);
            paramid[0].Value = prd_id;

            dt=DAL4.SelectData("VerifyProductId", paramid);
            return dt;
                
        }

         public DataTable GetAllProducts()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_ALL_Products", null);
            return dt;
        }
        public DataTable SearchProducts(string Id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param_product_id = new SqlParameter[1];
            DataTable Dt = new DataTable();
            param_product_id[0]= new SqlParameter("@ID", SqlDbType.VarChar, 30);
            param_product_id[0].Value = Id;
            Dt = DAL.SelectData("SearchProduct", param_product_id);
            DAL.Close();
            return Dt;
        }
        public void Delete_Products(string Id)
        {
           
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 30);
            param[0].Value = Id;
            DAL.ExecuteCommand("Delete_Products", param);
            DAL.Close();
        }
        public DataTable GetProductImage(string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_Product_Image", param);
            return dt;

        }
        public void UpdateProducts(int id_cat, string label_product, string id_product, int quantity, string price, byte[] image_product)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = id_cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[1].Value = id_product;

            param[2] = new SqlParameter("@LABEL_PRODUCT", SqlDbType.NVarChar, 50);
            param[2].Value = label_product;

            param[3] = new SqlParameter("@QUANTITY", SqlDbType.Int);
            param[3].Value = quantity;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 30);
            param[4].Value = price;

            param[5] = new SqlParameter("@IMAGE_PRD", SqlDbType.Image);
            param[5].Value = image_product;

            DAL.ExecuteCommand("Update_Products", param);
            DAL.Close();


        }
    }
}