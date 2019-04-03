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
using ShoppingCartCA.Filters;

namespace ShoppingCartCA.Controllers
{
    public class HomeController : Controller
    {
        private readonly string KEY = "Secured";

        Product product = new Product();

        //Gallery Page
        public ActionResult Index()
        {
            return View(product.GetProductList(null));
        }
        //Gallery Search
        public ActionResult SearchProduct(string keyword)
        {
            string partialViewData;
            partialViewData = RenderPartialViewToString("_GalleryPartial", product.GetProductList(keyword));
            return Json(partialViewData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddToCart(int id)
        {
            List<int> productsInCart = new List<int>();
            if (Session["Cart"]!=null)   productsInCart = (List<int>)Session["Cart"];
            productsInCart.Add(id);

            Session["Cart"] = productsInCart;
            return Json(productsInCart.Count(), JsonRequestBehavior.AllowGet);
        
    }

        public string RenderPartialViewToString(string viewName, object model)
        {
            this.ViewData.Model = model;
            try
            {
                using (StringWriter stringWriter = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);
                    ViewContext viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, stringWriter);
                    viewResult.View.Render(viewContext, stringWriter);

                    return stringWriter.GetStringBuilder().ToString();
                }
            }
            catch (System.Exception ex)
            {
                return ex.ToString();
            }
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
            return RedirectToAction("Index");
        }



        [Authorizer]
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if (ModelState.IsValid)

            {

                LoginHelper login = new LoginHelper();
                UserModel um = login.GetLoginUser(userModel.UserName);


                if (um != null)
                {
                    var decryptedPwd = Cipher.Decrypt(um.Password, KEY);

                    if (decryptedPwd.Equals(userModel.Password))
                    {
                        if (Session["UserID"] == null)
                        {
                            string sessionId = Guid.NewGuid().ToString();
                            Session["UserID"] = sessionId;
                        }

                        return RedirectToAction("Index");
                    }
                }
                return View(um);
            }
            else
            {

                return View();
            }

        }
        
    }
    
}






















































































































































