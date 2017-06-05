using Mobit.Data.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Controllers
{
    public class AltKategoriController : Controller
    {
        Entities db = new Entities();


        public ActionResult Index(int? Sayfa, string kategori, string Altkategori)
        {
            db.Configuration.LazyLoadingEnabled = false;

            int _sayfaNo = Sayfa ?? 1;

            //if (ilce == null || ilce == "")
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            //}
            //var ilceler = db.ilceler.Where(i => i.ilId == 40 || i.ilId == 82).ToList();

            //int ilceId = 0;
            //foreach (var item in ilceler)
            //{
            //    if (Kontrol.ToSlug(item.ilceAdi) == ilce)
            //    {
            //        ilceId = item.ilceId;
            //        break;
            //    }
            //}

            IPagedList<Kurumlar> kurumlar;

            var altKategori = db.AltKategoriler.FirstOrDefault(a => a.Slug == Altkategori);

            kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.AltKategoriler.Slug == altKategori.Slug && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 18);



            //kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);

            var kat = db.Kategoriler.Where(k => k.Slug == kategori && k.Aktif == true).Select(k => new { k.KategoriId, k.KategoriAdi }).FirstOrDefault();

            ViewBag.title = kat.KategoriAdi;
            ViewBag.desc = kat.KategoriAdi + " kategorisine bağlı tüm kurumlar";
            ViewBag.keywords = kat.KategoriAdi + " kategoriler,kurum,kurum kategorileri";
            ViewBag.bilgi = kat.KategoriAdi;
            db.Configuration.LazyLoadingEnabled = false;
            ViewBag.kurumsayi = "Bu kategoride " + kurumlar.Count() + " kurum var";

            if (kurumlar.Count() < 1)
            {
                ViewBag.title = kat.KategoriAdi;
                ViewBag.bilgi = kat.KategoriAdi;
                ViewBag.kurumsayi = "Bu kategoriye ait kurum bulunamadı.";
            }

            var reklam = db.Slider.Where(s => s.SliderId == 13).ToList();
            ViewData["detayReklam"] = reklam;
            return View(kurumlar);
        }
    }
}