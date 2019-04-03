using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Classes
{
    public class Product
    {
        public List<ProductModel> GetProductList(string keyword)
        {


            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Products WHERE ProductName LIKE  '%"+keyword+"%' OR Description LIKE '%"+keyword+"%'";

                DataTable tbl = db.GetData(cmd);
                List<ProductModel> productModels = new List<ProductModel>();
                
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        ProductModel product = new ProductModel();
                        product.productId = Convert.ToInt32(row[0].ToString());
                        product.productName = row[1].ToString();
                        product.description = row[2].ToString();
                        product.price = Decimal.Parse(row[3].ToString());
                        product.imagePath = row[4].ToString();
                        productModels.Add(product);
                    }
                    
                }
                return productModels;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}