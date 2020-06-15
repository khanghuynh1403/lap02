using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ListBookModel", "{type}",
            new { controller = "Default", action = "ListBookModel", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type","ListBookModel"}
        },
        new[] { "Lab02.Controller" });

            routes.MapRoute("EditBook", "{type}/{EditBook}/{id}",
              new { controller = "Default", action = "EditBook", id = UrlParameter.Optional },
              new RouteValueDictionary
              {
                { "type","Book"}
          },
          new[] { "Lab02.Controller" });

            routes.MapRoute("CreateBook", "{type}",
              new { controller = "Default", action = "CreateBook", id = UrlParameter.Optional },
              new RouteValueDictionary
              {
                { "type","CreateBook"}
          },
          new[] { "Lab02.Controller" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "ListBookModel", id = UrlParameter.Optional }
            );
        }
    }
}
