using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class PurchaseModel
    {
        public int PurchaseID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int UserID { get; set; }
    }
}