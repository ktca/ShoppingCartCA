using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class ActivationCodeModel
    {
        public Guid activationCode { get; set; }
        public int purchaseDetailID { get; set; }
    }
}