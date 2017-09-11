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
    public class GalleryController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            var galeri = db.Galeri.OrderByDescending(g=> g.GaleriId).ToList();
            return View(galeri);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Galeri galeri)
        {
            if (galeri.GaleriAdi == null)
            {
                return View();
            }

            string folderName = Kontrol.ToSlug(galeri.GaleriAdi);
            var folder = Server.MapPath("~/Upload/galeri/" + folderName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            galeri.GaleriYolu = folderName;
            db.Galeri.Add(galeri);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var galeri = db.Galeri.Find(id);
            return View(galeri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Galeri galeri)
        {
            Galeri galeriBilgi = db.Galeri.Where(g => g.GaleriId == galeri.GaleriId).FirstOrDefault();

            galeriBilgi.GaleriAdi = galeri.GaleriAdi;
            galeriBilgi.Aktif = galeri.Aktif;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult images(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var galeri = db.GaleriResim.Where(r => r.GaleriId == id).ToList();
            if (galeri == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.GaleriId = id;
            return View(galeri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult images(List<HttpPostedFileBase> galeriResim, int galeriId)
        {
            if (galeriResim == null)
            {
                return Redirect("/Admin/Gallery/images/" + galeriId);
            }

            Galeri galeri = db.Galeri.Find(galeriId);
            List<GaleriResim> gResimler = new List<GaleriResim>();

            foreach (var file in galeriResim)
            {
                if (file.ContentLength > 0)
                {
                    Random rnd = new Random();
                    string dosyaAdi = Path.GetFileNameWithoutExtension(file.FileName) + "-" + rnd.Next(1, 10000) + Path.GetExtension(file.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/galeri/" + galeri.GaleriYolu + "/"), dosyaAdi);
                    file.SaveAs(yuklemeYeri);

                    GaleriResim resimler = new GaleriResim()
                    {
                        GaleriId = galeriId,
                        Resim = dosyaAdi,

                    };

                    gResimler.Add(resimler);
                }
            }

            galeri.GaleriResim = gResimler;
            db.SaveChanges();

            return Redirect("/Admin/Gallery/images/" + galeriId);
        }

        public ActionResult DeleteFile(int id, int galeri)
        {
            if (id == null || galeri == null)
            {
                return Redirect("/Admin/Gallery/");
            }
            GaleriResim res = db.GaleriResim.Where(r => r.ResimId == id).FirstOrDefault();

            Galeri galeriBilgi = db.Galeri.Find(galeri);

            if (res == null)
            {
                return Redirect("/Admin/Gallery/images/" + galeri);
            }

            FileInfo fi = new FileInfo(Server.MapPath("~/Upload/galeri/" + galeriBilgi.GaleriYolu + "/" + res.Resim));

            db.GaleriResim.Remove(res);
            db.SaveChanges();
            if (System.IO.File.Exists(fi.ToString()))
            {
                //fi.Delete();
            }

            return Redirect("/Admin/Gallery/images/" + galeri);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Galeri galeri = db.Galeri.Find(id);

            if (galeri == null)
            {
                return RedirectToAction("Index");
            }

            db.Galeri.Remove(galeri);
            db.SaveChanges();

            try
            {
                var folder = Server.MapPath("~/Upload/galeri/" + galeri.GaleriYolu);

                if (Directory.Exists(folder))
                {
                    //Directory.Delete(folder);

                }

            }
            catch (Exception)
            {

            }



            return RedirectToAction("Index");
        }

        public string GetSlug(string slug)
        {
            int count = 0;
            string orgSlug = slug;
            while (db.Galeri.Where(u => u.GaleriYolu == slug).SingleOrDefault() != null)
            {
                count++;
                var result = db.Galeri.Where(u => u.GaleriYolu == slug).SingleOrDefault();
                slug = orgSlug + "-" + count;
            }
            return slug;
        }
    }
}