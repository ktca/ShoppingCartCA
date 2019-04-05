using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartCA.Classes;
using ShoppingCartCA.Filters;
using ShoppingCartCA.Models;

namespace ShoppingCartCA.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorizer]
        public ActionResult ViewCart()
        {
            List<UserCartModel> cartList = new List<UserCartModel>();
            List<int> productList = (List<int>)Session["Cart"];
            if (productList.Count() > 0)
            {
                Common common = new Common();
                cartList = common.GetProductList(productList);
            }
            return View(cartList);
        }
    }
}