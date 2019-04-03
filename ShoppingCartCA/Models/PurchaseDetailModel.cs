using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class PurchaseDetailModel
    {
        public int purchaseDetailId { get; set; }
        public int purchaseId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string activationCode { get; set; }
    }
}