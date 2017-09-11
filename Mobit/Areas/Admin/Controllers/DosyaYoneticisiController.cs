using Mobit.Data.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    public class DosyaYoneticisiController : Controller
    {
        // GET: Admin/DosyaYoneticisi
        Entities db = new Entities();
        [_Yetki(Roles = "Admin")]
        public ActionResult Index(int? Sayfa, string ara)
        {
            int _sayfaNo = Sayfa ?? 1;

            if (ara == null)
            {
                var dosyalar = db.DosyaYoneticisi.OrderByDescending(u => u.DosyaId).ToPagedList<DosyaYoneticisi>(_sayfaNo, 18);
                return View(dosyalar);
            }
            else
            {
                ara = Kontrol.AramaKontrol(ara);

                var dosyalar = db.DosyaYoneticisi.Where(d => d.DosyaAdi.Contains(ara)).OrderByDescending(u => u.DosyaId).ToPagedList<DosyaYoneticisi>(_sayfaNo, 18);
                return View(dosyalar);

            }

        }

        public ActionResult FileUploadHandler()
        {
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                string name = Kontrol.fileNameCreator(file.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/files/"), name);
                file.SaveAs(yuklemeYeri);

                DosyaYoneticisi dosya = new DosyaYoneticisi();
                dosya.DosyaAdi = Path.GetFileName(file.FileName);
                dosya.Url = name;
                dosya.Uzanti = Path.GetExtension(file.FileName);
                dosya.Boyut = file.ContentLength.ToString();
                dosya.Tarih = DateTime.Now;

                db.DosyaYoneticisi.Add(dosya);
                db.SaveChanges();
            }
            return Json(new { Message = string.Empty });

        }

        public ActionResult bilgiGetir(int DosyaId)
        {
            if (DosyaId == null)
            {
                return RedirectToAction("Index");
            }
            var bilgi = db.DosyaYoneticisi.Where(d => d.DosyaId == DosyaId).FirstOrDefault();
            return Json(bilgi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sil(int id, string returnUrl)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var bilgi = db.DosyaYoneticisi.Find(id);

            FileInfo sil = new FileInfo(Server.MapPath("/Upload/files/" + bilgi.Url));
            if (sil.Exists == true)
            {
                //sil.Delete();
            }

            db.DosyaYoneticisi.Remove(bilgi);
            db.SaveChanges();

            return Redirect(returnUrl);
        }
    }
}