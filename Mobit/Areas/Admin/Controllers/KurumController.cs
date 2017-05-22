using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki]
    public class KurumController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            kategoriler();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kurumlar kurum)
        {
        
            return View();
        }

        void kategoriler()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "KategoriId", "KategoriAdi");
            ViewBag.ilId = new SelectList(db.iller.Where(i => i.ilId == 40 || i.ilId == 82).ToList(), "ilId", "ilAdi");
            ViewBag.ilceId = new SelectList(db.ilceler.Where(i => i.ilId == 40 || i.ilId == 82).ToList(), "ilceId", "ilceAdi");

        }
        public ActionResult AltKategoriGetir(int KategoriId)
        {
            var kategoriler = db.AltKategoriler.Where(k => k.KategoriId == KategoriId).Select(k=> new {k.AltKategoriAdi,k.AltKategoriId }).ToList();

            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ilceGetir(int ilId)
        {
            var kategoriler = db.ilceler.Where(k => k.ilId == ilId).Select(k => new { k.ilceAdi, k.ilceId }).ToList();

            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }
    }
}