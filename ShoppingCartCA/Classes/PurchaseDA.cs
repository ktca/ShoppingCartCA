using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Classes
{
    public class PurchaseDA
    {
        public List<PurchaseDetailModel> GetPurchaseHistory(string userId)
        {
            List<PurchaseDetailModel> purchases = new List<PurchaseDetailModel>();

            try
            {
                //string productIDs = string.Join(", ", products);

                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT header.PurchaseID,header.PurchaseDate,detail.PurchaseDetailID,detail.ProductID,detail.Quantity,detail.Price,detail.ActivationCode,product.ProductName,product.Description,product.ImagePath FROM Purchases header JOIN PurchaseDetails detail ON detail.PurchaseID = header.PurchaseID JOIN Products product ON detail.ProductID = product.ProductID WHERE UserID = {userId}";
                DataTable tbl = db.GetData(cmd);
              
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        PurchaseModel header = new PurchaseModel();
                        PurchaseDetailModel purchase = new PurchaseDetailModel();
                        ProductModel product = new ProductModel();
                        header.purchaseId = Convert.ToInt32(row[0].ToString());
                        header.purchaseDate = Convert.ToDateTime(row[1].ToString());
                        purchase.purchaseId = Convert.ToInt32(row[0].ToString());
                        purchase.purchaseDetailId = Convert.ToInt32(row[2].ToString());
                        purchase.productId = Convert.ToInt32(row[3].ToString());
                        purchase.quantity = Convert.ToInt32(row[4].ToString());
                        purchase.price = Convert.ToDecimal(row[5].ToString());
                        purchase.activationCode = row[6].ToString();
                        product.productId = Convert.ToInt32(row[3].ToString());
                        product.productName = row[7].ToString();
                        product.description = row[8].ToString();
                        product.imagePath = row[9].ToString();

                        purchase.PurchaseHeader = header;
                        purchase.Product = product;
                    
                        purchases.Add(purchase);

                    }
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return purchases;

        }

    }
}