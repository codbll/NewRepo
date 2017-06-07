﻿using System;
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


            model.Slider = db.Slider.Where(s => s.SliderId == 14 && s.Aktif == true).OrderBy(s => s.Sira).Take(5).ToList();
            return View(model);

        }
    }
}