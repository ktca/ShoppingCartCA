using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class PurchaseDetailModel
    {
        public int purchaseDetailID { get; set; }
        public int purchaseID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string activationCode { get; set; }
    }
}