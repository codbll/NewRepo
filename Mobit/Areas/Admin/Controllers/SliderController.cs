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
    public class SliderController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Slider
        public ActionResult Index()
        {
            var slider = db.Slider.ToList();
            return View(slider);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider Slider, HttpPostedFileBase Resim)
        {
            if (Slider.Baslik == null)
            {
                RedirectToAction("Index");
            }

            if (Resim == null)
            {
                ViewBag.hata = "Lütfen bir resim seçiniz";
                return View();
            }

            Random rnd = new Random();
            string resimAdi = Path.GetFileNameWithoutExtension(Resim.FileName) + "-" + rnd.Next(1, 10000) + Path.GetExtension(Resim.FileName);
            var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/slide/"), resimAdi);
            Resim.SaveAs(yuklemeYeri);

            string target = "_blank";
            if (Slider.Target == "False")
                target = "_self";

            Slider.Target = target;
            Slider.Resim = resimAdi;
            Slider.Tarih = DateTime.Now;
            Slider.Aktif = true;
            db.Slider.Add(Slider);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var slider = db.Slider.Find(id);

            if (slider == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Target = slider.Target;
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider Slider, HttpPostedFileBase Resim)
        {

            if (Slider.Baslik == null)
            {
                RedirectToAction("Index");
            }

            Slider sld = db.Slider.Find(Slider.Id);

            if (Resim == null)
            {
                sld.Resim = sld.Resim;
            }
            else
            {
                Random rnd = new Random();
                string resimAdi = Path.GetFileNameWithoutExtension(Resim.FileName) + "-" + rnd.Next(1, 10000) + Path.GetExtension(Resim.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload/slide/"), resimAdi);
                Resim.SaveAs(yuklemeYeri);

                sld.Resim = resimAdi;
            }

            string target = "_blank";
            if (Slider.Target == "false")
                target = "_self";

            sld.Target = target;
            sld.Baslik = Slider.Baslik;
            sld.Sira = Slider.Sira;
            sld.Url = Slider.Url;
            sld.Aktif = Slider.Aktif;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Slider slider = db.Slider.Find(id);

            if (slider == null)
            {
                return RedirectToAction("Index");
            }

             try
            {
                FileInfo dosya = new FileInfo(Server.MapPath("~/Upload/slide/" + slider.Resim));

                if (dosya != null)
                {
                    dosya.Decrypt();
                }
            }
            catch (Exception)
            {
            }
			
            db.Slider.Remove(slider);
            db.SaveChanges();


            return RedirectToAction("Index");

        }

    }
}