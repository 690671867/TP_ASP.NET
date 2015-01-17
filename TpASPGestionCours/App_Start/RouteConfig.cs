using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TpASPGestionCours
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default1",
                url: "Home/DettailsPlus",
                defaults: new { controller = "Home", action = "DettailsPlus" }
            );
            routes.MapRoute(
                name: "Default2",
                url: "Home/Service",
                defaults: new { controller = "Home", action = "Service", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default3",
                url: "Home/Contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Default4",
               url: "Professeur/Index",
               defaults: new { controller = "Professeur", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}