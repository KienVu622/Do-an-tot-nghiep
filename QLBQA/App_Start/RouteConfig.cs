﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLBQA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "ProductDetails_Edit",
            url: "Admin/ProductDetails/Edit/{ids}",
            defaults: new { controller = "ProductDetails", action = "Edit", ids = UrlParameter.Optional },
            namespaces: new[] { "QLBQA.Areas.Admin.Controllers" }
        );
            routes.MapRoute(
                name: "Admin",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { area = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLBQA.Areas.Admin.Controllers" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLBQA.Controllers" }
            );
          
            //routes.MapRoute(
            //name: "ProductDetails",
            //url: "Admin/ProductDetails/{action}/{id}",
            //defaults: new { controller = "ProductDetails", action = "Index", id = UrlParameter.Optional }
            //    );

        }
    }
}
