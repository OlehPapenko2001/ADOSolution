using ADOModelsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODALLibrary
{
    public class ProductDAL
    {
        SqlConnection conn;
        public ProductDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public List<Product> GetAllProducts()
        {
            SqlCommand cmdGetAllProducts = new SqlCommand();
            List<Product> productList = new List<Product>();
            cmdGetAllProducts.Connection = conn;
            cmdGetAllProducts.CommandText = "proc_GetAllProducts";
            cmdGetAllProducts.CommandType = CommandType.StoredProcedure;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            SqlDataReader dr = cmdGetAllProducts.ExecuteReader();
            while (dr.Read())
            {
                productList.Add(new Product());
                productList.Last().Id = Convert.ToInt32(dr[0]);
                productList.Last().Name = dr[1].ToString();
                productList.Last().QuantityPerUnit = dr[2].ToString();
                productList.Last().UnitPrice = Convert.ToSingle(dr[3]);
                productList.Last().Stock = Convert.ToInt32(dr[4]);
            }
            conn.Close();
            return productList;
        }
    }    
}
