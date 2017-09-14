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
            var slider = db.Slider.OrderBy(s=>s.SliderKategori.SliderId).OrderBy(k => k.SliderId).ToList();
            return View(slider);
        }

        public ActionResult Create()
        {
            ViewBag.SliderId = new SelectList(db.SliderKategori.ToList(), "SliderId", "SliderAdi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider Slider, HttpPostedFileBase Resim)
        {
            ViewBag.SliderId = new SelectList(db.SliderKategori.ToList(), "SliderId", "SliderAdi");

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
            ViewBag.SliderId = new SelectList(db.SliderKategori.ToList(), "SliderId", "SliderAdi", slider.SliderId);

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider Slider, HttpPostedFileBase Resim)
        {
            ViewBag.SliderId = new SelectList(db.SliderKategori.ToList(), "SliderId", "SliderAdi", Slider.SliderId);

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
            sld.SliderId = Slider.SliderId;
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
                    //dosya.Decrypt();
                }
            }
            catch (Exception)
            {
            }

            db.Slider.Remove(slider);
            db.SaveChanges();


            return RedirectToAction("Index");

        }

        public ActionResult RowChange(int id, int? fromPosition, int? toPosition, string direction)
        {
            //if (direction == "back")
            //{
            //    var slides = db.Slider.Where(s => (toPosition <= s.Sira && s.Sira <= fromPosition)).ToList();

            //    if (slides != null)
            //    {
            //        var sld = slides.FirstOrDefault(s => s.Id == id);
            //        sld.Sira = Convert.ToInt32(toPosition);
            //        foreach (var item in slides)
            //        {
            //            if (item.Id != sld.Id)
            //            {
            //                item.Sira++;
            //            }
            //        }
            //    }
            //}
            //else// forward
            //{
            //    var slides = db.Slider.Where(s => (fromPosition <= s.Sira && s.Sira <= toPosition)).ToList();

            //    if (slides != null)
            //    {
            //        var sld = slides.FirstOrDefault(s => s.Id == id);
            //        sld.Sira = Convert.ToInt32(toPosition);
            //        foreach (var item in slides)
            //        {
            //            if (item.Id != sld.Id)
            //            {
            //                item.Sira--;
            //            }
            //        }
            //    }
            //}


            //db.SaveChanges();
            return null;
        }

    }
}