using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki(Roles = "Admin")]
    public class NewsController : Controller
    {
        Entities db = new Entities();

        // GET: Admin/News
        public ActionResult Index()
        {
            var haberler = db.Haberler.ToList();
            return View(haberler);
        }

        public ActionResult Create()
        {
            kategorileriGetir();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Haberler haberler, HttpPostedFileBase yuklenecekDosya)
        {
            kategorileriGetir();

            if (haberler.Ad == null)
            {
                return View();
            }

            // resim seçmeden haber eklenebilsin
            if (yuklenecekDosya == null)
            {
                //TempData["bilgi"] = "Haber resmi seçilmedi";
                //return View();
            }
            else
            {
                string dosyaAdi = Kontrol.fileNameCreator(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/haber"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                haberler.Resim = dosyaAdi;
            }


            haberler.Hit = 1;
            try
            {
                haberler.Slug = Kontrol.ToSlug(haberler.Ad);
            }
            catch (Exception)
            {
                haberler.Slug = haberler.Ad;
            }
            
            haberler.Tarih = DateTime.Now;
            db.Haberler.Add(haberler);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                HttpNotFound();
            }

            Haberler haber = db.Haberler.Find(id);

            if (haber == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.HaberKategorileri.ToList(), "KategoriId", "Ad", haber.KategoriId);
            ViewBag.GaleriId = new SelectList(db.Galeri.ToList(), "GaleriId", "GaleriAdi", haber.GaleriId);

            return View(haber);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Haberler haberler, HttpPostedFileBase yuklenecekDosya)
        {

            if (haberler.Ad == null)
            {
                return View();
            }

            Haberler haber = db.Haberler.Find(haberler.Id);

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Kontrol.fileNameCreator(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/haber"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);
                haber.Resim = dosyaAdi;
            }

            haber.Ad = haberler.Ad;
            haber.Slug = Kontrol.ToSlug(haberler.Slug);
            haber.KategoriId = haberler.KategoriId;
            haber.GaleriId = haberler.GaleriId;
            haber.Detay = haberler.Detay;
            haber.Aktif = haberler.Aktif;
            haber.Tarih = haberler.Tarih;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public string GetSlug(string slug, int? id)
        {
            if (id == null)
            {
                int count = 0;
                string orgSlug = slug;
                while (db.Haberler.Where(u => u.Slug == slug).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.Haberler.Where(u => u.Slug == slug).SingleOrDefault();
                    slug = orgSlug + "-" + count;
                }
            }
            else
            {
                int count = 0;
                string orgSlug = slug;
                while (db.Haberler.Where(u => u.Slug == slug && u.Id != id).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.Haberler.Where(u => u.Slug == slug && u.Id != id).SingleOrDefault();
                    slug = orgSlug + "-" + count;
                }
            }
            return slug;
        }

        void kategorileriGetir()
        {
            ViewBag.KategoriId = new SelectList(db.HaberKategorileri.ToList(), "KategoriId", "Ad");
            ViewBag.GaleriId = new SelectList(db.Galeri.OrderByDescending(g => g.GaleriId).ToList(), "GaleriId", "GaleriAdi");
        }

        public ActionResult Category()
        {
            var haberKategorileri = db.HaberKategorileri.ToList();
            return View(haberKategorileri);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(HaberKategorileri haber)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            haber.Slug = GetKategoriSlug(Kontrol.ToSlug(haber.Ad), null);
            db.HaberKategorileri.Add(haber);
            db.SaveChanges();

            return RedirectToAction("Category");
        }

        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Category");
            }

            HaberKategorileri haber = db.HaberKategorileri.Find(id);


            if (haber == null)
            {
                return RedirectToAction("Category");

            }


            return View(haber);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(HaberKategorileri haberkategori)
        {
            if (haberkategori.KategoriId == null)
            {
                return RedirectToAction("Category");
            }

            HaberKategorileri haber = db.HaberKategorileri.Find(haberkategori.KategoriId);

            if (haber == null)
            {
                return RedirectToAction("Category");

            }

            haber.Ad = haberkategori.Ad;
            haber.Slug = GetKategoriSlug(Kontrol.ToSlug(haberkategori.Slug), haberkategori.KategoriId);
            haber.Url = haberkategori.Url;
            haber.Aktif = haberkategori.Aktif;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public string GetKategoriSlug(string slug, int? id)
        {
            if (id == null)
            {
                int count = 0;
                string orgSlug = slug;
                while (db.HaberKategorileri.Where(u => u.Slug == slug).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.HaberKategorileri.Where(u => u.Slug == slug).SingleOrDefault();
                    slug = orgSlug + "-" + count;
                }
            }
            else
            {
                int count = 0;
                string orgSlug = slug;
                while (db.HaberKategorileri.Where(u => u.Slug == slug && u.KategoriId != id).SingleOrDefault() != null)
                {
                    count++;
                    var result = db.HaberKategorileri.Where(u => u.Slug == slug && u.KategoriId != id).SingleOrDefault();
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

            Haberler haber = db.Haberler.Find(id);

            if (haber == null)
            {
                return RedirectToAction("Index");
            }

            FileInfo dosya = new FileInfo(Server.MapPath("~/Upload/haber/" + haber.Resim));

            try
            {
                if (dosya != null)
                {
                    //dosya.Decrypt();
                }
            }
            catch (Exception)
            {


            }

            db.Haberler.Remove(haber);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Category");
            }

            HaberKategorileri haber = db.HaberKategorileri.Find(id);

            if (haber == null)
            {
                return RedirectToAction("Category");
            }

            try
            {
                db.HaberKategorileri.Remove(haber);
                db.SaveChanges();
                // ilgili haber varsa ana sayfaya dön
            }
            catch (Exception)
            {


            }


            return RedirectToAction("Category");

        }

        public ActionResult images(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var galeri = db.HaberlerResim.Where(r => r.HaberlerId == id).ToList();
            if (galeri == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.HaberlerId = id;
            return View(galeri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult images(List<HttpPostedFileBase> HaberlerResim, int haberlerId)
        {
            if (HaberlerResim == null)
            {
                return Redirect("/Admin/News/images/" + haberlerId);
            }

            Haberler galeri = db.Haberler.Find(haberlerId);
            List<HaberlerResim> gResimler = new List<HaberlerResim>();

            foreach (var file in HaberlerResim)
            {
                if (file.ContentLength > 0)
                {
                    Random rnd = new Random();
                    string dosyaAdi = Path.GetFileNameWithoutExtension(file.FileName) + "-" + rnd.Next(1, 10000) + Path.GetExtension(file.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/galeri/"), dosyaAdi);
                    file.SaveAs(yuklemeYeri);

                    HaberlerResim resimler = new HaberlerResim()
                    {
                        HaberlerId = haberlerId,
                        Resim = dosyaAdi,

                    };

                    gResimler.Add(resimler);
                }
            }

            galeri.HaberlerResim = gResimler;
            db.SaveChanges();

            return Redirect("/Admin/News/images");
        }

        public ActionResult DeleteFile(int id, int galeri)
        {
            if (id == null || galeri == null)
            {
                return Redirect("/Admin/News/");
            }
            HaberlerResim res = db.HaberlerResim.Where(r => r.ResimId == id).FirstOrDefault();

            Haberler galeriBilgi = db.Haberler.Find(galeri);

            if (res == null)
            {
                return Redirect("/Admin/News/images/" + galeri);
            }

            FileInfo fi = new FileInfo(Server.MapPath("~/Upload/galeri/" + res.Resim));

            db.HaberlerResim.Remove(res);
            db.SaveChanges();
            if (System.IO.File.Exists(fi.ToString()))
            {
                //fi.Delete();
            }

            return Redirect("/Admin/News/images/" + galeri);
        }

    }
}