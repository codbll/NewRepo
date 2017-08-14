using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki(Roles = "Admin")]
    public class PagesController : Controller
    {
        Entities db = new Entities();

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var sayfalar = db.Sayfalar.ToList();
            return View(sayfalar);
        }

        public ActionResult Create()
        {
            ViewBag.GaleriId = new SelectList(db.Galeri.ToList(), "GaleriId", "GaleriAdi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Sayfalar sayfa)
        {
            ViewBag.GaleriId = new SelectList(db.Galeri.ToList(), "GaleriId", "GaleriAdi");

            if (sayfa.Ad==null)
            {
                return RedirectToAction("Index");
            }

            sayfa.Slug = Kontrol.ToSlug(sayfa.Ad);

            db.Sayfalar.Add(sayfa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var sayfa = db.Sayfalar.Find(id);

            ViewBag.GaleriId = new SelectList(db.Galeri.ToList(), "GaleriId", "GaleriAdi",sayfa.GaleriId);

            return View(sayfa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Sayfalar sayfa)
        {
            if (sayfa == null)
            {
                return RedirectToAction("Index");
            }

            Sayfalar sayfaGuncelle= db.Sayfalar.Find(sayfa.Id);

            sayfaGuncelle.KategoriId = sayfa.KategoriId;
            sayfaGuncelle.GaleriId = sayfa.GaleriId;
            sayfaGuncelle.Ad = sayfa.Ad;
            sayfaGuncelle.Detay = sayfa.Detay;
            sayfaGuncelle.Aktif = sayfa.Aktif;
            sayfaGuncelle.Menu = sayfa.Menu;
            sayfaGuncelle.Url = sayfa.Url;
            sayfaGuncelle.iletisimFormu = sayfa.iletisimFormu;
            sayfaGuncelle.Slug = Kontrol.ToSlug(sayfa.Slug);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string GetSlug(string slug, int? id)
        {
            if (id == null)
            {
                int count = 0;
                string orgSlug = slug;
                while (db.Sayfalar.Where(u => u.Slug == slug).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.Sayfalar.Where(u => u.Slug == slug).SingleOrDefault();
                    slug = orgSlug + "-" + count;
                }
            }
            else
            {
                int count = 0;
                string orgSlug = slug;
                while (db.Sayfalar.Where(u => u.Slug == slug && u.Id != id).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.Sayfalar.Where(u => u.Slug == slug && u.Id != id).SingleOrDefault();
                    slug = orgSlug + "-" + count;
                }
            }
            return slug;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Sayfalar sayfa = db.Sayfalar.Find(id);

            if (sayfa == null)
            {
                return RedirectToAction("Index");
            }
            db.Sayfalar.Remove(sayfa);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}