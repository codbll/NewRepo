using Mobit.Data.Context;
using Mobit.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    public class UyeController : Controller
    {
        Entities db = new Entities();

        // GET: Admin/Uye
        public ActionResult Index()
        {
            uyeGirdiMi();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Adminler admin)
        {
            admin.Sifre = Kontrol.Base64Encrypt(admin.Sifre);
            var adminGetir = db.Adminler.Where(adm => adm.Mail == admin.Mail && adm.Sifre == admin.Sifre && adm.Aktif == true).FirstOrDefault();

            if (adminGetir != null)
            {
                if (adminGetir.Aktif.ToString() == "False")
                {
                    // ViewBag.msg = "Sayın " + adminGetir.AdSoyad + " üyeliğiniz henüz onaylı değil.";
                    return View();
                }
                else
                {
                    Session["AdminId"] = adminGetir.AdminId;
                    Session["AdSoyad"] = adminGetir.AdSoyad;

                    Session["Yetki"] = db.AdminRolIliski.Where(adm => adm.AdminId == adminGetir.AdminId).Select(adm => adm.AdminRolleri.RolAdi).FirstOrDefault();

                    return Redirect("Home");
                }


            }

            ViewBag.msg = "Lütfen kullanıcı bilgilerinizi kontrol edin.";
            return View();

        }


        [_Yetki]
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index");
        }

        public ActionResult SifremiUnuttum()
        {
            uyeGirdiMi();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SifremiUnuttum(string Mail)
        {
            

            if (Mail == null)
            {
                TempData["bilgi"] = "Lütfen mail adresinizi giriniz";
                TempData["class"] = "info";
                return View();
            }

            var personel = db.Adminler.Where(p => p.Mail == Mail).FirstOrDefault();

            if (personel == null)
            {
                TempData["bilgi"] = "Bu mail adresinde kayıtlı kullanıcı bulunamadı.";
                TempData["class"] = "danger";

                return View();
            }

            string yeniSifre = Kontrol.SifreOlustur();
            personel.Sifre = Kontrol.Base64Encrypt(yeniSifre);

            db.SaveChanges();

            TempData["bilgi"] = "Sayın " + personel.AdSoyad + " yeni şifreniz mail adresinize gönderildi.";
            TempData["class"] = "success";

            Helpers.SendMail.Mail("Yeni Şifreniz", "Yeni şifreniz: " + yeniSifre + " <br/>" + Kontrol.SayfaUrlAl(1), personel.Mail);
            return View();
        }

        [_Yetki]
        public ActionResult Profil()
        {
            int AdminId = Convert.ToInt32(Session["AdminId"]);
            var admin = db.Adminler.Where(adm => adm.AdminId == AdminId).FirstOrDefault();

            if (admin == null)
            {
                HttpNotFound();
            }

            return View(admin);
        }

        [_Yetki]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profil(Adminler admin, string Sifre)
        {

            var adminler = db.Adminler.Where(adm => adm.AdminId == admin.AdminId).FirstOrDefault();

            if (adminler == null)
            {
                HttpNotFound();
            }
            adminler.AdSoyad = admin.AdSoyad;
            adminler.Mail = admin.Mail;


            db.SaveChanges();

            return View();
        }

        [_Yetki]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SifreDegistir(Adminler admin)
        {

            var adminler = db.Adminler.Where(adm => adm.AdminId == admin.AdminId).FirstOrDefault();

            if (adminler == null)
            {
                HttpNotFound();
            }
            adminler.AdSoyad = adminler.AdSoyad;
            adminler.Mail = adminler.Mail;
            adminler.Sifre = Kontrol.Base64Encrypt(admin.Sifre);
            db.SaveChanges();

            return RedirectToAction("Profil");
        }

        void uyeGirdiMi()
        {
            if (Session["AdminId"] != null)
            {
                Response.Redirect("/Admin/Home");
            }
        }

    }
}