using Mobit.Data.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Controllers
{
    public class HaberController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index(string slug)
        {
            var haber = db.Haberler.FirstOrDefault(h => h.Slug == slug);

            if (haber == null)
            {
                return Redirect("/");
            }

            string title = haber.Ad;
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;

            if (haber.GaleriId != null)
            {
                ViewData["GaleriResim"] = db.GaleriResim.Where(g => g.GaleriId == haber.GaleriId && g.Galeri.Aktif == true).ToList();
            }

            return View(haber);
        }


        [Route("Haberler")]
        public ActionResult Haberler(int? Sayfa)
        {
         
            int _sayfaNo = Sayfa ?? 1;

            string title = "Haberler";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h =>  h.Aktif == true && h.KategoriId == 4).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Haber bulunamadı";
            }
            return View(haberler);

        }

        [Route("Roportajlar")]
        public ActionResult Roportajlar(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ropörtajlar";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId==3).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ropörtaj bulunamadı";
            }
            return View(haberler);

        }


        public PartialViewResult SonHaberler()// son 10 haber
        {
            var haberler = db.Haberler.Where(h => h.Aktif == true).OrderByDescending(h => h.Tarih).Take(10).ToList();

            return PartialView("~/Views/_Partial/_SonHaberler.cshtml", haberler);
        }

    }
}