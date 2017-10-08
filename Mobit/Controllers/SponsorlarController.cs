using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobit.Data.Context;
using Mobit.Models;

namespace Mobit.Controllers
{
    public class SponsorlarController : Controller
    {
        // GET: Kurum
        Entities db = new Entities();

        public ActionResult Index(string kategoriSlug, string kurumSlug)
        {
            var model = new SponsorlarDetayModel();

            model.Kurumlar = db.Kurumlar.Where(u => u.Slug == kurumSlug && u.Durum == true).FirstOrDefault();

            if (model.Kurumlar == null)
            {
                return Redirect("/");
            }
            if (model.Kurumlar.Kategoriler != null)
            {
                ViewBag.title = model.Kurumlar.KurumAdi + " - " + model.Kurumlar.Kategoriler.KategoriAdi;
                ViewBag.desc = model.Kurumlar.Kategoriler.KategoriAdi + " - " + model.Kurumlar.KurumAdi;
                ViewBag.keywords = model.Kurumlar.Kategoriler.KategoriAdi + model.Kurumlar.KurumAdi.Replace(" ", ",");
            }

            model.Slider = db.Slider.Where(s => (s.SliderId == 14 || s.SliderId == 15) && (s.Aktif == true)).OrderBy(s => s.Sira).Take(5).ToList();

            if (model.Kurumlar.Sponsorlar == "Sponsor1")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 5).OrderByDescending(u => u.Id).ToList();
            }
            else if(model.Kurumlar.Sponsorlar == "Sponsor2")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 6).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Sponsor3")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 7).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Sponsor4")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 8).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Sponsor5")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 9).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Sponsor6")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 10).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Anaokulu")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 13).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Koleji")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 14).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Üniversitesi")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 15).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Kursu")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 16).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Tedarikçisi")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 17).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "Ayın En İyi Okul Servisi")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 18).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "En İyi Okullar")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 19).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "En İyi Yöneticiler")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 20).OrderByDescending(u => u.Id).ToList();
            }
            else if (model.Kurumlar.Sponsorlar == "En İyi Eğitmenler")
            {
                model.Haberler = db.Haberler.Where(r => r.KategoriId == 21).OrderByDescending(u => u.Id).ToList();
            } 

            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s => s.Sira).Take(1).ToList();

            return View(model);

        }
    }
}