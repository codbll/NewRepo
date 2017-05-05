using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki(Roles = "Admin")]
    public class SolutionController : Controller
    {
        Entities db = new Entities();

        // GET: Admin/Solution
        public ActionResult Index()
        {
            var cozumler = db.Cozumler.ToList();
            return View(cozumler);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Cozumler cozum)
        {
            if (cozum == null)
            {
                HttpNotFound();
            }
            cozum.Slug = GetSlug(Kontrol.ToSlug(cozum.Ad));
            cozum.Aktif = true;
            db.Cozumler.Add(cozum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var cozum = db.Cozumler.Find(id);

            return View(cozum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Cozumler cozum)
        {
            if (cozum == null)
            {
                return RedirectToAction("Index");
            }

            Cozumler cozumGuncelle = db.Cozumler.Find(cozum.Id);

            cozumGuncelle.KategoriId = cozum.KategoriId;
            cozumGuncelle.Ad = cozum.Ad;
            cozumGuncelle.Detay = cozum.Detay;
            cozumGuncelle.Aktif = cozum.Aktif;
            cozumGuncelle.Url = cozum.Url;
            cozumGuncelle.Slug = GetSlugUpdate(Kontrol.ToSlug(cozum.Slug), cozum.Id);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Cozumler cozum = db.Cozumler.Find(id);

            if (cozum == null)
            {
                return RedirectToAction("Index");
            }
            db.Cozumler.Remove(cozum);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public string GetSlug(string slug)
        {
            int count = 0;
            string orgSlug = slug;
            while (db.Cozumler.Where(k => k.Slug == slug).SingleOrDefault() != null)
            {
                count++;
                var result = db.Cozumler.Where(k => k.Slug == slug).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }
        public string GetSlugUpdate(string slug, int cozumId)
        {
            int count = 0;
            string orgSlug = slug;
            while (db.Cozumler.Where(k => k.Slug == slug && k.Id != cozumId).SingleOrDefault() != null)
            {
                count++;
                var result = db.Cozumler.Where(k => k.Slug == slug && k.Id != cozumId).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }

    }
}