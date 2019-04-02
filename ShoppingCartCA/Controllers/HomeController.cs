using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartCA.Models;
using ShoppingCartCA.Classes;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ShoppingCartCA.Controllers
{
    public class HomeController : Controller
    {
        private readonly string KEY = "Secured";

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
            ViewBag.Message = "Your contact page.";
       return View();
        }

        public ActionResult Login()
        {
            //var encrypt = Cipher.Encrypt("123", KEY);
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            FormsAuthentication.SignOut();
            //ViewBag.LogInOut = "Logout";
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            LoginHelper login = new LoginHelper();
            UserModel um = login.GetLoginUser(username);
                      

            if (um != null)
            {
                var decryptedPwd = Cipher.Decrypt(um.Password, KEY);

                if(decryptedPwd.Equals(password))
                {
                    if (Session["UserID"] == null)
                    {
                        string sessionId = Guid.NewGuid().ToString();
                        Session["UserID"] = sessionId;
                        FormsAuthentication.SetAuthCookie(um.UserName, false);

                    }
                    //ViewBag.LogInOut = "Login";
                    return RedirectToAction("Index");
                }
            }
            return View(um);
        }

       
    }

  

}






















































































































































