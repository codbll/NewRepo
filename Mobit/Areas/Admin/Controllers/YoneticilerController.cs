using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki(Roles = "Admin")]
    public class YoneticilerController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Yoneticiler
        public ActionResult Index()
        {
            int adminId = Convert.ToInt32(Session["AdminId"]);
            var yoneticiler = db.Adminler.Where(a => a.AdminId != adminId).ToList();
            return View(yoneticiler);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var admin = db.Adminler.Find(id);

            if (admin == null)
            {
                return RedirectToAction("Index");

            }

            var rol = db.AdminRolIliski.Where(r => r.AdminId == admin.AdminId).Select(r => r.RolId).FirstOrDefault();
            ViewBag.RolId = new SelectList(db.AdminRolleri.ToList(), "RolId", "RolAdi", rol);

            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Adminler adminler, int RolId)
        {
            if (adminler == null)
            {
                return RedirectToAction("Index");
            }

            var admin = db.Adminler.Find(adminler.AdminId);

            if (adminler.Sifre == null)
            {
                admin.Sifre = admin.Sifre;
            }
            else
            {
                admin.Sifre = Kontrol.Base64Encrypt(adminler.Sifre);
            }

            admin.AdSoyad = adminler.AdSoyad;
            admin.Mail = adminler.Mail;
            admin.Aktif = adminler.Aktif;
            db.SaveChanges();

            AdminRolIliski roller = new AdminRolIliski();

            //yönetici role bağlı değilse ekle bağlıysa rol değişmişse değiştir.
            var rol = db.AdminRolIliski.Where(adm => adm.AdminId == adminler.AdminId).FirstOrDefault();
            if (rol == null)
            {
                roller.AdminId = adminler.AdminId;
                roller.RolId = RolId;
                db.AdminRolIliski.Add(roller);
                db.SaveChanges();
            }
            else
            {

                rol.RolId = RolId;
                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Adminler admin = db.Adminler.Find(id);

            if (admin == null)
            {
                return RedirectToAction("Index");
            }

            AdminRolIliski roller = db.AdminRolIliski.Where(rol => rol.AdminId == admin.AdminId).FirstOrDefault();

            if (roller == null)
            {
                db.AdminRolIliski.Remove(roller);
            }

            db.Adminler.Remove(admin);
            db.SaveChanges();


            return RedirectToAction("Index");

        }



    }
}