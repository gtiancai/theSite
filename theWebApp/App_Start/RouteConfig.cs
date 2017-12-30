using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace theWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // With below map, we can contole the URL format.
            // http://localhost:29850/       // load ATest.Index() by default
            // http://localhost:29850/welcome
            // routes.MapRoute(name: "Default", url: "{action}", defaults: new { controller = "ATest", action = "Index", id = UrlParameter.Optional });


            routes.MapRoute(name: "TestName", url: "{action}", defaults: new { controller = "ATest", action = "Index", id = UrlParameter.Optional });
        }
    }
}
