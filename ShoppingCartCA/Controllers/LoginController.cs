using ShoppingCartCA.Classes;
using ShoppingCartCA.Filters;
using ShoppingCartCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ShoppingCartCA.Controllers
{
    public class LoginController : Controller
    {
        private readonly string KEY = "Secured";
        public ActionResult Login()
        {
            //var encrypt = Cipher.Encrypt("123", KEY);
            return View();
        }

        //[Authorizer]
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if (ModelState.IsValid)

            {
                LoginHelper login = new LoginHelper();
                UserModel um = login.GetLoginUser(userModel.username);


                if (um != null)
                {
                    var decryptedPwd = Cipher.Decrypt(um.password, KEY);

                    if (decryptedPwd.Equals(userModel.password))
                    {
                        if (Session["UserID"] == null)
                        {
                            string sessionId = Guid.NewGuid().ToString();
                            Session["UserID"] = sessionId;

                        }
                        return RedirectToAction("Index", new RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));
                    }
                }
                return View(um);
            }
            else
            {

                return View();
            }

        }


        public ActionResult Logout()
        {
            Session["UserID"] = null;
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}