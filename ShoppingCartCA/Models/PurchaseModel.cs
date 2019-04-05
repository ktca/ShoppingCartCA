using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartCA.Models
{
    public class PurchaseModel
    {
        public int purchaseId { get; set; }
        public DateTime purchaseDate { get; set; }
        public int userID { get; set; }
        public List<PurchaseDetailModel> purchaseDetails { get; set; }
        
    }
}