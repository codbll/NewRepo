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
            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(4).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s => s.Sira).Take(1).ToList();
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
            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s => s.Sira).Take(1).ToList();
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
            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s => s.Sira).Take(1).ToList();
            return View(haberler);

        }

        [Route("Sponsor1")]
        public ActionResult Sponsor1(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 1";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 5).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-1 bulunamadı";
            }
            return View(haberler);

        }

        [Route("Sponsor2")]
        public ActionResult Sponsor2(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 2";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 6).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-2 bulunamadı";
            }
            return View(haberler);

        }
        [Route("Sponsor3")]
        public ActionResult Sponsor3(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 3";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 7).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-3 bulunamadı";
            }
            return View(haberler);

        }
        [Route("Sponsor4")]
        public ActionResult Sponsor4(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 4";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 8).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-4 bulunamadı";
            }
            return View(haberler);

        }
        [Route("Sponsor5")]
        public ActionResult Sponsor5(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 5";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 9).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-5 bulunamadı";
            }
            return View(haberler);

        }
        [Route("Sponsor6")]
        public ActionResult Sponsor6(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Sponsor 6";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 10).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Sponsor-6 bulunamadı";
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