using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartCA.Models;
using ShoppingCartCA.Classes;

namespace ShoppingCartCA.Controllers
{
    public class HomeController : Controller
    {
        Product product = new Product();
        public ActionResult Index()
        {
       
            return View(product.GetProductList(""));
        }

        public ActionResult SearchProduct(string keyword)
        {
            
            return View(product.GetProductList(""));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            //this is viewbag
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}