using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobit.Data.Context;

namespace Mobit.Controllers
{
    public class KurumController : Controller
    {
        // GET: Kurum
        Entities db = new Entities();

        public ActionResult Index(string kategoriSlug, string kurumSlug)
        {

            var kurum = db.Kurumlar.Where(u => u.Slug == kurumSlug && u.Durum == true).FirstOrDefault();

            if (kurum == null)
            {
                return Redirect("/");
            }

            ViewBag.title = kurum.KurumAdi + " - " + kurum.Kategoriler.KategoriAdi;
            ViewBag.desc = kurum.Kategoriler.KategoriAdi + " - " + kurum.KurumAdi;
            ViewBag.keywords = kurum.Kategoriler.KategoriAdi + kurum.KurumAdi.Replace(" ", ",");

            return View(kurum);

        }
    }
}