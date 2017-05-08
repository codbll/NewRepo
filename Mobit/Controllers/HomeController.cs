﻿using Mobit.Data.Context;
using Mobit.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace Mobit.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            TitleGetir();
            Slider();
            Markalar();
            return View();

        }


        public PartialViewResult Menu()
        {
            // kategoriler
            db.Configuration.LazyLoadingEnabled = false;
            var kategoriler = db.Kategoriler.Where(k => k.Aktif == true).OrderBy(k => k.Sira).ToList();
            var altKategoriler = db.AltKategoriler.Where(k => k.Aktif == true).OrderBy(k => k.Sira).ToList();
            // çözümler
            var cozumler = db.Cozumler.Where(czm => czm.Aktif == true).ToList();
            var haberKategori = db.HaberKategorileri.Where(h => h.Aktif == true).ToList();

            List<Sayfalar> hakkimizda = db.Sayfalar.Where(s => s.Aktif == true && s.Menu == true && s.KategoriId == 1).ToList();
            ViewBag.hakkimizda = hakkimizda;

            List<Sayfalar> iletisim = db.Sayfalar.Where(s => s.Aktif == true && s.Menu == true && s.KategoriId == 2).ToList();
            ViewBag.iletisim = iletisim;

            return PartialView("~/Views/_Partial/_Menu.cshtml", Tuple.Create(kategoriler, altKategoriler, cozumler, haberKategori));

        }

        void Slider()
        {
            //slider
            var slider = db.Slider.Where(sld => sld.Aktif == true).OrderBy(sld => sld.Sira).ToList();
            TempData["slider"] = slider;

        }

        void Markalar()
        {
            var markalar = db.Markalar.Where(m => m.Aktif == true).OrderBy(m=>m.Sira).ToList();
            TempData["markalar"] = markalar;
        }

        public void TitleGetir()
        {
            var meta = db.MetaTag.OrderBy(m => new { m.Title, m.Description, m.Keywords }).FirstOrDefault();

            ViewBag.title = meta.Title;
            ViewBag.desc = meta.Description;
            ViewBag.keywords = meta.Keywords;
        }

        public PartialViewResult footerBilgi()
        {
            var bilgi = db.iletisim.OrderBy(b => new { b.Mail, b.Telefon, b.Faks }).FirstOrDefault();
            var meta = db.MetaTag.FirstOrDefault();

            ViewBag.Faks = bilgi.Faks;
            ViewBag.Mail = bilgi.Mail;
            ViewBag.Telefon = bilgi.Telefon;
            ViewBag.Facebook = meta.Facebook;
            ViewBag.Twitter = meta.Twitter;
            ViewBag.GooglePlus = meta.GooglePlus;
            ViewBag.Linkedin = meta.Linkedin;
            ViewBag.Youtube = meta.Youtube;
            ViewBag.Diger = meta.Diger;

            return PartialView("~/Views/_Partial/_Footer.cshtml");
        }


        public PartialViewResult headerBilgi()
        {

            var bilgi = db.iletisim.OrderBy(b => new { b.Telefon }).FirstOrDefault();
            var meta = db.MetaTag.OrderBy(m => m.SiteLogo).FirstOrDefault();

            ViewBag.Telefon = bilgi.Telefon;
            ViewBag.Logo = meta.SiteLogo;

            return PartialView("~/Views/_Partial/_Header.cshtml");

        }

        [Route("Home/BultenKayit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BultenKayit(string mail)
        {
            int result;
            if (mail == null)
            {
                result = 0;
            }

            if (Kontrol.mailValidation(mail) == true)
            {
                Bulten blt = db.Bulten.Where(b => b.Mail == mail).FirstOrDefault();

                if (blt == null)
                {
                    Bulten bulten = new Bulten();
                    result = 1;
                    bulten.Mail = mail;
                    bulten.Tarih = DateTime.Now;
                    bulten.Ip = Kontrol.IpAdresi();
                    db.Bulten.Add(bulten);
                    db.SaveChanges();

                    string icerik = "<b>Mobit Email Bültenine yeni bir kayıt eklendi</b> " + "<br/> <b>Mail: </b>" + bulten.Mail + "<br/> <b>Ip Adresi: </b>" + bulten.Ip;

                    var gidecekMailler = db.iletisim.Select(m => m.Mailler).FirstOrDefault();
                    Helpers.SendMail.Mail("Bültene Yeni Kayıt Eklendi", icerik, gidecekMailler.ToString());
                }
                else
                {
                    // bültene daha önce kayıt yaptırılmış
                    result = 2;
                }
            }
            else
            {
                result = 0; // mail formatı uygun değil
            }



            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult Popup()
        {

            var popup = db.Popup.FirstOrDefault();

            if (popup.Durum == true)
            {

                if (popup.AcilisSekli == 3)// her sayfa yenilendiğinde açılacaksa
                {
                    if (Request.Cookies["mPopup"] == null)
                    {
                        // eğer daha önce günlük veya saatlik cookie varsa ve popup sonradan anlık gösterim olarak değiştirilmişse cookie varsa sil
                        Request.Cookies.Remove("mPopup");
                    }

                    return PartialView("~/Views/_Partial/_Popup.cshtml", popup);
                }
                else
                {


                    if (Request.Cookies["mPopup"] == null) // cookie boşsa ilk defa giriyordur.
                    {

                        HttpCookie Cookie = new HttpCookie("mPopup", DateTime.Now.ToString());

                        if (popup.AcilisSekli == 1) //1 - saatte bir göster
                        {
                            Cookie.Expires = DateTime.Now.AddHours(1);
                        }
                        else if (popup.AcilisSekli == 2)//  günde bir kez göster
                        {
                            Cookie.Expires = DateTime.Now.AddDays(1);
                        }

                        Response.Cookies.Add(Cookie);

                        return PartialView("~/Views/_Partial/_Popup.cshtml", popup);

                    }
                    else // cokie boş değilse görmüştür, cookie bitene kadar gösterme
                    {
                        return PartialView("~/Views/_Partial/_Popup.cshtml", null);
                    }


                }

            }
            else
            {
                return PartialView("~/Views/_Partial/_Popup.cshtml", null);
            }

        }

       

    }
}