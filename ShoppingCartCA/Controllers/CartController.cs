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
        Product product = new Product();
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

                    cartList = product.GetCartProductList(productList);
                }
            }
            return View(cartList);
        }
        public ActionResult ChangeQuantity(int Qty, int PID)
        {
            List<int> cart = new List<int>();

            if (Session["Cart"] != null)
            {
                cart = (List<int>)Session["Cart"];
                while (cart.Contains(PID))
                {
                    cart.Remove(PID);
                }
            }
            for (int i = 0; i < Qty; i++)
            {
                cart.Add(PID);
            }
            Session["Cart"] = cart;
            var cartModel = product.GetCartProductList(cart);
            
            decimal totalPrice = cartModel != null ? cartModel.Sum(x => x.productTotalPrice) : 0;
            return Json(totalPrice, JsonRequestBehavior.AllowGet);

        }
    }
}