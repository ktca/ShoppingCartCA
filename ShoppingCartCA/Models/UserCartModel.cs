using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class UserCartModel
    {
        public int cartID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public decimal productTotalPrice { get; set; }
        public ProductModel product { get; set; }
    }
}