using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Classes
{
    public class Common
    {
        public UserModel GetUserByUsername(string username)
        {
            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Users WHERE Username='"+username+"'";
                
                DataTable tbl = db.GetData(cmd);
                UserModel userModel = new UserModel();
                if (tbl != null)
                {
                    userModel.userId= Convert.ToInt32(tbl.Rows[0][0].ToString());
                    userModel.username = tbl.Rows[0][1].ToString();
                    userModel.password = tbl.Rows[0][2].ToString();
                    return userModel;
                }
                return null;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<UserCartModel> GetProductList(List<int> products)
        {
            try
            {
                string productIDs= string.Join(", ", products);

                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Products WHERE ProductID in ("+productIDs+")";

                DataTable tbl = db.GetData(cmd);
                List<UserCartModel> userCartModels = new List<UserCartModel>();
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        UserCartModel userCartModel = new UserCartModel();
                        ProductModel product = new ProductModel();
                        product.productID= Convert.ToInt32(row[0].ToString());
                        product.productName = row[1].ToString();
                        product.description= row[2].ToString();
                        product.price = Convert.ToDecimal(row[3].ToString());
                        product.imagePath= row[4].ToString();

                        userCartModel.product = product;
                        userCartModel.quantity= products.Count(x => x == product.productID);

                        userCartModels.Add(userCartModel);
                        
                    }
                }
                return userCartModels;
                
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}