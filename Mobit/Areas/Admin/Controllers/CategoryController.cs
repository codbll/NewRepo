using Mobit.Data.Context;
using Mobit.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki(Roles = "Admin")]
    public class CategoryController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();

            return View(kategoriler);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategoriler kategori, HttpPostedFileBase yuklenecekDosya)
        {
            if (kategori.KategoriAdi == null)
            {
                return View();
            }

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Path.GetFileName(Kontrol.SayiOlustur() + "-" + yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/icon"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                kategori.Ikon = dosyaAdi;
            }

            kategori.Slug = Kontrol.ToSlug(kategori.KategoriAdi);
            db.Kategoriler.Add(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var kategoriler = db.Kategoriler.Where(k => k.KategoriId == id).FirstOrDefault();

            if (kategoriler == null)
            {
                return RedirectToAction("Index");
            }

            return View(kategoriler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategoriler kategori, HttpPostedFileBase yuklenecekDosya, bool cbSlug)
        {

            if (kategori.KategoriId == null)
            {
                return RedirectToAction("Index");
            }

            Kategoriler kat = db.Kategoriler.Where(k => k.KategoriId == kategori.KategoriId).FirstOrDefault();

            if (kat == null)
            {
                return RedirectToAction("Index");
            }

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Path.GetFileName(Kontrol.SayiOlustur() + "-" + yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/icon"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                kat.Ikon = dosyaAdi;
            }
            if (cbSlug == true)
            {
                kat.Slug = Kontrol.ToSlug(kategori.Slug);
            }


            kat.KategoriAdi = kategori.KategoriAdi;
            kat.Aktif = kategori.Aktif;
            kat.Depart = kategori.Depart;
            kat.Area = kategori.Area;
            kat.Sira = kategori.Sira;
            kat.Url = kategori.Url;


            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SubCategory(int? id)
        {
            var altKategori = new List<AltKategoriler>();

            if (id == null)
            {
                altKategori = db.AltKategoriler.ToList();
                return View(altKategori);
            }

            altKategori = db.AltKategoriler.Where(alt => alt.KategoriId == id).ToList();
            return View(altKategori);
        }

        public ActionResult AddSubCategory()
        {
            ViewBag.kategoriler = new SelectList(db.Kategoriler.ToList(), "KategoriId", "KategoriAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubCategory(AltKategoriler altKategori, HttpPostedFileBase yuklenecekDosya)
        {
            if (altKategori.AltKategoriAdi == null)
            {
                return View();
            }

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Path.GetFileName(Kontrol.SayiOlustur() + "-" + yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/icon"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                altKategori.Ikon = dosyaAdi;
            }

            altKategori.Slug = Kontrol.ToSlug(altKategori.AltKategoriAdi);
            db.AltKategoriler.Add(altKategori);
            db.SaveChanges();

            return RedirectToAction("SubCategory");
        }


        public ActionResult EditSubCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SubCategory");
            }
            var altKategoriler = db.AltKategoriler.Where(k => k.AltKategoriId == id).FirstOrDefault();

            if (altKategoriler == null)
            {
                return RedirectToAction("SubCategory");
            }

            ViewBag.kategoriler = new SelectList(db.Kategoriler.ToList(), "KategoriId", "KategoriAdi", altKategoriler.KategoriId);
            return View(altKategoriler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubCategory(AltKategoriler altKategori, HttpPostedFileBase yuklenecekDosya, bool cbSlug)
        {
            if (altKategori.KategoriId == null)
            {
                return RedirectToAction("SubCategory");
            }

            AltKategoriler kat = db.AltKategoriler.Where(k => k.AltKategoriId == altKategori.AltKategoriId).FirstOrDefault();

            if (kat == null)
            {
                return RedirectToAction("SubCategory");
            }

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Path.GetFileName(Kontrol.SayiOlustur() + "-" + yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/icon"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                kat.Ikon = dosyaAdi;
            }
            if (cbSlug == true)
            {
                kat.Slug = Kontrol.ToSlug(altKategori.Slug);
            }

            kat.KategoriId = altKategori.KategoriId;
            kat.AltKategoriAdi = altKategori.AltKategoriAdi;
            kat.Aktif = altKategori.Aktif;
            kat.Depart = altKategori.Depart;
            kat.Area = altKategori.Area;
            kat.Sira = altKategori.Sira;
            kat.Url = altKategori.Url;


            db.SaveChanges();
            return RedirectToAction("SubCategory");

        }

        public ActionResult DeleteCategory(int id, string returnUrl)
        {
            Kategoriler kategori = db.Kategoriler.Where(k => k.KategoriId == id).FirstOrDefault();

            if (kategori == null)
            {
                return RedirectToAction("Category");
            }

            try
            {
                db.Kategoriler.Remove(kategori);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["hata"] = "Uyarı: Bu kategoriye bağlı Alt Kategori veya Ürün olduğu için, Kategoriyi silmenize izin verilmedi.";

                return Redirect(returnUrl);

            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSubCategory(int id, string returnUrl)
        {
            AltKategoriler kategori = db.AltKategoriler.Where(k => k.AltKategoriId == id).FirstOrDefault();

            if (kategori == null)
            {
                return RedirectToAction("SubCategory");
            }


            try
            {

                db.AltKategoriler.Remove(kategori);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                TempData["hata"] = "Uyarı: Bu kategoriye Ürün olduğu için, Kategoriyi silmenize izin verilmedi.";

                return Redirect(returnUrl);

            }

            return RedirectToAction("SubCategory");
        }
        public string GetSlug(string slug)
        {
            int count = 0;
            string orgSlug = slug;
            while (db.Kategoriler.Where(k => k.Slug == slug).SingleOrDefault() != null)
            {
                count++;
                var result = db.Kategoriler.Where(k => k.Slug == slug).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }
        public string GetSlugSubCategory(string slug)
        {
            int count = 0;
            string orgSlug = slug;
            while (db.AltKategoriler.Where(k => k.Slug == slug).SingleOrDefault() != null)
            {
                count++;
                var result = db.AltKategoriler.Where(k => k.Slug == slug).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }
    }
}