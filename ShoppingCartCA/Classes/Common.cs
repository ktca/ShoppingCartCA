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
    }
}