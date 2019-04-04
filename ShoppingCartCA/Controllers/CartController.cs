using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartCA.Classes;
using ShoppingCartCA.Models;

namespace ShoppingCartCA.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult ViewCart()
        {
            List<UserCartModel> cartList = new List<UserCartModel>();
            List<int> productList = new List<int>();
            if (Session["Cart"] != null)
            {
                productList = (List<int>)Session["Cart"];
                if (productList != null || productList.Count() > 0)
                {
                    Product product = new Product();
                    cartList = product.GetCartProductList(productList);
                }
            }
            return View(cartList);
        }
    }
}