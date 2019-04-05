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

            if (HttpContext.Current.Session["sessionId"] == null)

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