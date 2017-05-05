using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    //[_SessionController]

    [_Yetki]
    public class HomeController : Controller
    {
        Entities db = new Entities();

        // GET: Admin/Home

        public ActionResult Index()
        {
            //var urunler = db.Urunler.Where(u => u.Sil == false).ToList();
            //ViewData["urunler"] = urunler;

            return View();
        }
        public ActionResult YetkiYok()
        {
            return View();
        }
      
    }
}