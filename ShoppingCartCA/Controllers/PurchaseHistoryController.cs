using ShoppingCartCA.Classes;
using ShoppingCartCA.Filters;
using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartCA.Controllers
{
    public class PurchaseHistoryController : Controller
    {
        // GET: Purchase
        [Authorizer]
        public ActionResult PurchaseHistory()
        {
            var purchaseList = new List<PurchaseDetailModel>();
            var purchaseDA = new PurchaseDA();

            purchaseList = purchaseDA.GetPurchaseHistory(Session["UserId"].ToString());


         
            return View(purchaseList);
        }
    }
}