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


            routes.MapRoute(
           "yuklemeIndir",
           "Yuklemeler/{Slug}",
            new { controller = "Destek", action = "YuklemeIndir", },
            new[] { "Mobit.Controllers" }
            );

            routes.MapRoute(
            name: "Hakkimizda",
             url: "Sayfa/{Slug}",
             defaults: new { controller = "Sayfalar", action = "Sayfalar", Slug = "" }

          );

            routes.MapRoute(
             name: "cozumler",
              url: "Cozumler/{Slug}",
              defaults: new { controller = "Sayfalar", action = "Cozumler", Slug = "" }


          );

            routes.MapRoute(
           name: "haberkategori",
            url: "Haberler/{Slug}",
            defaults: new { controller = "Sayfalar", action = "Haberler", Slug = "" }

           );
            routes.MapRoute(
           name: "haberDetay",
            url: "Haber/{Slug}",
            defaults: new { controller = "Sayfalar", action = "HaberDetay", Slug = "" }


          );


            routes.MapRoute(
              "Kategori",
               "Kategori/{Slug}",
               new { controller = "Kategori", action = "Index", },
               new[] { "Mobit.Controllers" }
            );

            routes.MapRoute(
              "altKategori",
               "Kategori/{slugKategori}/{slugAltKategori}",
               new { controller = "Kategori", action = "AltKategori", },
               new[] { "Mobit.Controllers" }
                );

            routes.MapRoute(
             "markaurunleri",
              "Markalar/{Slug}",
              new { controller = "Markalar", action = "Index", },
              new[] { "Mobit.Controllers" }
               );

            routes.MapRoute(
           "urunDetay",
            "{Slug}/{urunSlug}",
            new { controller = "Urun", action = "Index", },
            new[] { "Mobit.Controllers" }
          );

            routes.MapRoute(
          "yuklemeler",
           "Yuklemeler",
           new { controller = "Destek", action = "Yuklemeler", },
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
