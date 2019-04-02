using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartCA.Models;
using ShoppingCartCA.Classes;
using System.IO;

namespace ShoppingCartCA.Controllers
{
    public class HomeController : Controller
    {
        Product product = new Product();

        //Gallery Page
        public ActionResult Index()
        {
            return View(product.GetProductList(null));
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

        //Gallery Search
        public ActionResult SearchProduct(string keyword)
        {
            string partialViewData;
            partialViewData = RenderPartialViewToString("_GalleryPartial", product.GetProductList(keyword));
            return Json(partialViewData, JsonRequestBehavior.AllowGet);
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
    }
}