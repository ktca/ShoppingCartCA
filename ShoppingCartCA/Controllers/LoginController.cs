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
           //var encrypt = Cipher.Encrypt("12345", KEY);
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
                        //if (Session["sessionId"] == null)
                        //{
                        //    string sessionId = Guid.NewGuid().ToString();
                        //    Session["sessionId"] = sessionId;
                        //    Session["UserID"] = um.userId;

                        //}
                        if (Session["UserID"] == null)
                        {
                            Session["UserID"] = um.userId;
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
            //Session["sessionId"] = null;
            Session["UserID"] = null;
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}