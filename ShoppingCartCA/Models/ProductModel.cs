using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class ProductModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imagePath { get; set; }
    }
}