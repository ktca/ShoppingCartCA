using ShoppingCartCA.Models;
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
       
            return View(product.GetProductList("water"));
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

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string pwd)
        {
            LoginHelper login = new LoginHelper();
            UserModel um = login.LoginValidation(username, pwd);


            if (um != null)
            {
                if (Session[username] == null)
                {
                    string sessionId = Guid.NewGuid().ToString();
                    Session["UserID"] = sessionId;
                }


                return RedirectToAction("Index");
            }

            return View(um);

        }


    }
}