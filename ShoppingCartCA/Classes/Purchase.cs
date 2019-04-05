using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Classes
{
    public class Purchase
    {
        public bool SavePurchase(List<int> cart,string userID)
        {
            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM Purchases";

                DataTable tbl = db.GetData(cmd);
                string purchaseID = (Convert.ToInt32(tbl.Rows[0][0].ToString())+1).ToString();

                PurchaseModel purchase = this.ConstructPurchase(cart);

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("INSERT INTO Purchases VALUES ({0}, '{1}', '{2}')", purchaseID, DateTime.Now, userID);
                var rowAffected = db.SetData(cmd);

                if (rowAffected > 0)
                {
                    //insert purchase details
                    foreach (var purchaseDetail in purchase.purchaseDetails)
                    {
                        purchaseDetail.purchaseId = Convert.ToInt32(purchaseID);
                        var result = this.SavePurchaseDetails(purchaseDetail);
                        if (result==false)
                        {
                            return false;
                        }
                        
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }

        }
        public PurchaseModel ConstructPurchase(List<int> cartList)
        {
            PurchaseModel purchase = new PurchaseModel();
            purchase.purchaseDetails = new List<PurchaseDetailModel>();
            foreach (var productID in cartList)
            {
                if (purchase.purchaseDetails.Where(x => x.productId == productID).ToList().Count <= 0)
                {
                    PurchaseDetailModel purchaseDetail = new PurchaseDetailModel();
                    purchaseDetail.purchaseDetailId = purchase.purchaseDetails.Count + 1;
                    purchaseDetail.productId = productID;
                    purchaseDetail.quantity = cartList.Count(c => c == productID);
                    string[] activationCode = new string[purchaseDetail.quantity];
                    for (int i = 0; i < purchaseDetail.quantity; i++)
                    {
                        activationCode[i] = Guid.NewGuid().ToString();
                    }
                    purchaseDetail.activationCode= string.Join(", ", activationCode);
                    purchase.purchaseDetails.Add(purchaseDetail);
                }

            }

            return purchase;
        }
        public bool SavePurchaseDetails(PurchaseDetailModel purchaseDetail)
        {
            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM PurchaseDetails";

                DataTable tbl = db.GetData(cmd);
                string purchaseDetailID = (Convert.ToInt32(tbl.Rows[0][0].ToString())+1).ToString();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("INSERT INTO PurchaseDetails VALUES({0},{1},{2},{3},{4},'{5}')", purchaseDetailID, purchaseDetail.purchaseId, purchaseDetail.productId, purchaseDetail.quantity, purchaseDetail.price,purchaseDetail.activationCode);

                var rowAffected = db.SetData(cmd);

                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}