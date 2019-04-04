using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        //public IEnumerable<SelectListItem> ActivationCodes { get; set; }

        public PurchaseModel PurchaseHeader { get; set; }

        public ProductModel Product { get; set; }
    }
}