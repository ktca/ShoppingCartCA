using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;


namespace ShoppingCartCA.Filters
{
    public class Authorizer : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext ac)
        {
            //string sessionId = HttpContext.Current.Request["sessionId"];
            var session = HttpContext.Current.Session;
            var  sessionId = session["UserID"];
            //Session["UserID"]
            //string sessionId = ["UserID"];

            if (sessionId == null)

            {
                ac.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Login" }
                    });
            }
           
        }

    }
}