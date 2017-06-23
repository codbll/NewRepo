using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobit.Data.Context;
using Mobit.Models;

namespace Mobit.Controllers
{
    public class KurumController : Controller
    {
        // GET: Kurum
        Entities db = new Entities();

        public ActionResult Index(string kategoriSlug, string kurumSlug)
        {
            var model = new KurumDetayModel();

            model.Kurumlar = db.Kurumlar.Where(u => u.Slug == kurumSlug && u.Durum == true).FirstOrDefault();

            if (model.Kurumlar == null)
            {
                return Redirect("/");
            }

            ViewBag.title = model.Kurumlar.KurumAdi + " - " + model.Kurumlar.Kategoriler.KategoriAdi;
            ViewBag.desc = model.Kurumlar.Kategoriler.KategoriAdi + " - " + model.Kurumlar.KurumAdi;
            ViewBag.keywords = model.Kurumlar.Kategoriler.KategoriAdi + model.Kurumlar.KurumAdi.Replace(" ", ",");


            model.Slider = db.Slider.Where(s => (s.SliderId == 14 || s.SliderId == 15) && (s.Aktif == true)).OrderBy(s => s.Sira).Take(5).ToList();

            var reklam = db.Slider.Where(s => s.SliderId == 13 || s.SliderId == 16).OrderBy(s => s.Sira).ToList();
            ViewData["detayReklam"] = reklam.Where(r => r.SliderId == 13).Take(5).ToList();
            ViewData["ustTekReklam"] = reklam.Where(r => r.SliderId == 16).OrderBy(s => s.Sira).Take(1).ToList();

            return View(model);

        }
    }
}