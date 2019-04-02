using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Classes
{
    public class LoginHelper
    {
        //public UserModel LoginValidation(string username, string password)
        public UserModel GetLoginUser(string username)
        {

            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Users WHERE Username='" + username + "'";

                DataTable tbl = db.GetData(cmd);
                UserModel userModel = new UserModel();
                if (tbl != null)
                {
                    userModel.UserID = (int)tbl.Rows[0][0];
                    userModel.UserName = tbl.Rows[0][1].ToString();
                    userModel.Password = tbl.Rows[0][2].ToString();
                    return userModel;
                }
                return null;

            }
            catch (Exception me)
            {
                return null;
            }

        }
    }
}