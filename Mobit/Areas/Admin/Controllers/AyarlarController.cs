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
    public class AyarlarController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Ayarlar
        public ActionResult iletisim()
        {
            iletisim iletisim = db.iletisim.FirstOrDefault();

            if (iletisim == null)
            {
                return View();
            }
            else
            {
                return View(iletisim);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult iletisim(iletisim ilt)
        {

            var iletisim = db.iletisim.Where(i => i.Id == ilt.Id).FirstOrDefault();

            if (iletisim == null)
            {

                db.iletisim.Add(ilt);
                db.SaveChanges();
            }
            else
            {
                iletisim.Telefon = ilt.Telefon;
                iletisim.Faks = ilt.Faks;
                iletisim.Mail = ilt.Mail;
                iletisim.Harita = ilt.Harita;
                iletisim.Mailler = ilt.Mailler;
                iletisim.DestekMailler = ilt.DestekMailler;
                iletisim.Adres = ilt.Adres;
                iletisim.SmtpPort = ilt.SmtpPort;
                iletisim.SmtpMail = ilt.SmtpMail;
                iletisim.SmtpAdres = ilt.SmtpAdres;
                iletisim.Sifre = ilt.Sifre;
                iletisim.Harita = ilt.Harita;
                db.SaveChanges();

            }
            return View();
        }


        public ActionResult Meta()
        {
            MetaTag meta = db.MetaTag.FirstOrDefault();

            if (meta == null)
            {
                return View();
            }
            else
            {
                return View(meta);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Meta(MetaTag metaTag, HttpPostedFileBase yuklenecekDosya)
        {
            var meta = db.MetaTag.Where(m => m.Id == m.Id).FirstOrDefault();

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = yuklenecekDosya.FileName;
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/images"), dosyaAdi);
                yuklenecekDosya.SaveAs(yuklemeYeri);

                metaTag.SiteLogo = dosyaAdi;
            }
            else
            {
                metaTag.SiteLogo = meta.SiteLogo;
            }

            if (meta == null)
            {
                db.MetaTag.Add(metaTag);
                db.SaveChanges();
            }
            else
            {
                meta.Title = metaTag.Title;
                meta.Description = metaTag.Description;
                meta.Keywords = metaTag.Keywords;
                meta.Facebook = metaTag.Facebook;
                meta.Twitter = metaTag.Twitter;
                meta.GooglePlus = metaTag.GooglePlus;
                meta.Linkedin = metaTag.Linkedin;
                meta.Youtube = metaTag.Youtube;
                meta.Diger = metaTag.Diger;
                meta.SiteLogo = metaTag.SiteLogo;
                db.SaveChanges();

            }

            return RedirectToAction("Meta");
        }

        public ActionResult Bulten()
        {
            var bulten = db.Bulten.OrderByDescending(b => b.Id).ToList();
            return View(bulten);
        }
        public ActionResult BultenSil(int id)
        {
            Bulten bulten = db.Bulten.Find(id);

            if (bulten != null)
            {
                db.Bulten.Remove(bulten);
                db.SaveChanges();
            }

            return RedirectToAction("Bulten");
        }

        public ActionResult Popup()
        {
            var popup = db.Popup.FirstOrDefault();
            return View(popup);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Popup(Popup popup)
        {
            Popup popupEdit = db.Popup.Find(popup.Id);
            popupEdit.Baslik = popup.Baslik;
            popupEdit.Aciklama = popup.Aciklama;
            popupEdit.AcilisSekli = popup.AcilisSekli;
            popupEdit.Durum = popup.Durum;

            db.SaveChanges();
            return RedirectToAction("Popup");
        }

    }
}