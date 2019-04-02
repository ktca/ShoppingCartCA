using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class ActivationCodeModel
    {
        public Guid ActivationCode { get; set; }
        public int PurchaseDetailID { get; set; }
    }
}