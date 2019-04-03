using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class UserCartModel
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}