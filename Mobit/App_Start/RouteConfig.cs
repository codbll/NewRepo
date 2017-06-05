﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mobit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //  routes.MapRoute(
            // name: "haberkategori",
            //  url: "Haberler/{Slug}",
            //  defaults: new { controller = "Sayfalar", action = "Haberler", Slug = "" }

            // );
            //  routes.MapRoute(
            // name: "haberDetay",
            //  url: "Haber/{Slug}",
            //  defaults: new { controller = "Sayfalar", action = "HaberDetay", Slug = "" }


            //);

            routes.MapRoute(
           "kategori",
            "Kategori/{kategori}/{AltKategori}",
            new { controller = "AltKategori", action = "Index", },
            new[] { "Mobit.Controllers" }
             );

            routes.MapRoute(
              "kurumDetay",
               "{kategoriSlug}/{kurumSlug}",
               new { controller = "Kurum", action = "Index", },
               new[] { "Mobit.Controllers" }
            );

         

            routes.MapRoute(
               "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Mobit.Controllers" }
            );


        }
    }
}
