using System;
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
            routes.MapRoute(
           name: "haberDetay",
            url: "Haber/{Slug}",
            defaults: new { controller = "Haber", action = "Index" }


          );

            routes.MapRoute(
           "kategori",
            "Kategori/{kategori}/{AltKategori}/{illerKategori}",
            new { controller = "AltKategori", action = "Index", },
            new[] { "Mobit.Controllers" }
             );

            routes.MapRoute(
            "kategori2",
            "Kategori/{kategori}/{AltKategori}",
            new { controller = "AltKategori", action = "Index", },
            new[] { "Mobit.Controllers" }
             );

            routes.MapRoute(
           "kategori3",
           "Kategori/{kategori}",
           new { controller = "AltKategori", action = "Index", },
           new[] { "Mobit.Controllers" }
            );


            routes.MapRoute(
              "kurumDetay",
               "{kategoriSlug}/{kurumSlug}/{Id}",
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
