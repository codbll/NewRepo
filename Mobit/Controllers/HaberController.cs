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

            if (haber.Id != null)
            {
                ViewData["HaberlerResim"] = db.HaberlerResim.Where(g => g.HaberlerId == haber.Id).ToList();
            }


            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
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


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 4).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Haberler bulunamadı";
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

            string title = "Biyografiler";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId==3).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Biyografi bulunamadı";
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
        [Route("HaberPopupEniyiAnaokulu")]
        public ActionResult HaberPopupEniyiAnaokulu(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "En iyi Anaokulu";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 13).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "HaberPopupEniyiAnaokulu bulunamadı";
            }
            return View(haberler);

        }

        [Route("HaberPopupEniyiKoleji")]
        public ActionResult HaberPopupEniyiKoleji(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ayın En İyi Koleji";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 14).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ayın En İyi Koleji bulunamadı";
            }
            return View(haberler);

        }


        [Route("HaberPopupEniyiUniversitesi")]
        public ActionResult HaberPopupEniyiUniversitesi(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ayın En İyi Üniversitesi";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 15).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ayın En İyi Üniversitesi bulunamadı";
            }
            return View(haberler);

        }

        [Route("HaberPopupEniyiKursu")]
        public ActionResult HaberPopupEniyiKursu(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ayın En İyi Kursu";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 16).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ayın En İyi Kursu bulunamadı";
            }
            return View(haberler);

        }

        [Route("HaberPopupEniyiTedarikcisi")]
        public ActionResult HaberPopupEniyiTedarikcisi(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ayın En İyi Tedarikçisi";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 17).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ayın En İyi Tedarikçisi bulunamadı";
            }
            return View(haberler);

        }

        [Route("HaberPopupEniyiOkulServisi")]
        public ActionResult HaberPopupEniyiOkulServisi(int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;

            string title = "Ayın En İyi Okul Servisi";
            ViewBag.title = title;
            ViewBag.desc = title;
            ViewBag.keywords = title;
            ViewBag.bilgi = title;


            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 18).OrderByDescending(h => h.Tarih).ToPagedList<Haberler>(_sayfaNo, 10);

            if (haberler.Count <= 0)
            {
                ViewBag.bilgi = "Ayın En İyi Okul Servisi bulunamadı";
            }
            return View(haberler);

        } 
        public PartialViewResult SonHaberler()// son 10 haber
        {
            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 4).OrderByDescending(h => h.Tarih).Take(5).ToList();

            return PartialView("~/Views/_Partial/_SonHaberler.cshtml", haberler);
        }
        public PartialViewResult SonHaberlerRoportajlar()// son 10 haber
        {
            var haberler = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 3).OrderByDescending(h => h.Tarih).Take(5).ToList();

            return PartialView("~/Views/_Partial/_SonHaberlerRoportajlar.cshtml", haberler);
        }
    }
}