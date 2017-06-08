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
            var kurumlar = db.Kurumlar.Where(u => u.Durum == true).ToList();


            var haberler = db.Haberler.ToList();
            ViewData["urunler"] = haberler;

            ViewBag.kategoriSayi = db.Kategoriler.Count();
            ViewBag.altKategoriSayi = db.AltKategoriler.Count();
            ViewBag.kurumSayi = db.Kurumlar.Count();
            ViewBag.haberler = db.Haberler.Count();

            return View(kurumlar);
        }
        public ActionResult YetkiYok()
        {
            return View();
        }

    }
}