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


        public ActionResult Index(int? Sayfa, string kategori, string altkategori, int illerkategori=0)
        {
            db.Configuration.LazyLoadingEnabled = false;

            int _sayfaNo = Sayfa ?? 1;

            //if (altkategori == null || altkategori == "")
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            //}
            var ilceler = db.ilceler.Where(i => i.ilId == 40 || i.ilId == 82).ToList();

            int ilceId = 0;
            foreach (var item in ilceler)
            {
                if (Kontrol.ToSlug(item.ilceAdi) == altkategori)
                {
                    ilceId = item.ilceId;
                    break;
                }
            }

            IPagedList<Kurumlar> kurumlar;

            var altKategori = db.AltKategoriler.FirstOrDefault(a => a.Slug == altkategori);

            // kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.AltKategoriler.Slug == altKategori.Slug && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 18);

            if (altKategori == null && illerkategori==0)
            {
                kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 15);
            }
            else if(altKategori == null)
            {
                kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.ilceId == ilceId && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 15);
            }
            else if (illerkategori != 0)
            {
                kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.AltKategoriler.Slug == altkategori && u.Kategoriler.Slug == kategori && u.ilId == illerkategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 15);
            }
            else
            {
                kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.AltKategoriler.Slug == altkategori && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 15);
            }

            //kurumlar = db.Kurumlar.Include("Kategoriler").Where(u => u.Durum == true && u.Kategoriler.Slug == kategori).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 15);

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

            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s=>s.Sira).Take(1).ToList();

            return View(kurumlar);
        }
    }
}