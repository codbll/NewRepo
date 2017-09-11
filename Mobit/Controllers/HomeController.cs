using Mobit.Data.Context;
using Mobit.Data.Model;
using Mobit.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            GelismisAramaBilgi();

            ViewData["HaberlerPopup"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 4).ToList();
            ViewData["RoportajlarPopup"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 3).ToList();

            ViewData["HaberPopupEniyiAnaokulu"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 13).ToList();
            ViewData["HaberPopupEniyiKoleji"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 14).ToList();
            ViewData["HaberPopupEniyiUniversitesi"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 15).ToList();
            ViewData["HaberPopupEniyiKursu"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 16).ToList();
            ViewData["HaberPopupEniyiTedarikcisi"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 17).ToList();
            ViewData["HaberPopupEniyiOkulServisi"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 18).ToList();


            ViewData["PopupEniyiOkullar"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 19).ToList();
            ViewData["PopupEniyiYoneticiler"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 20).ToList();
            ViewData["PopupEniyiEgitmenler"] = db.Haberler.Where(h => h.Aktif == true && h.KategoriId == 21).ToList();

            return View();

        }
        //[Route("Anketler")]
        public PartialViewResult Anketler()
        {
            ViewBag.KurumId = new SelectList(db.Kurumlar.ToList(), "KurumId", "KurumAdi");
            ViewBag.EnSevdiginizOgretmenveBransi = new SelectList(db.KurumEgitimciler.Where(h => h.Tip == 1).OrderBy(h => h.Aciklama).ToList(), "EgitimciId", "Aciklama");//Eğitimci
            ViewBag.EnSevdiginizYonetici = new SelectList(db.KurumEgitimciler.Where(h => h.Tip == 2).OrderBy(h => h.Aciklama).ToList(), "EgitimciId", "Aciklama");//Yönetici

            return PartialView("~/Views/_Partial/_Anketler.cshtml");

        }


        public PartialViewResult Menu()
        {
            var model = new MenuModel();
            // kategoriler
            model.Kategoriler = db.Kategoriler.Where(k => k.Aktif == true).OrderBy(k => k.Sira).ToList();
            model.iller = db.iller.Where(i => i.ilId == 40 || i.ilId == 82).ToList();

            var meta = db.MetaTag.FirstOrDefault();

            ViewBag.Facebook = meta.Facebook;
            ViewBag.Twitter = meta.Twitter;
            ViewBag.GooglePlus = meta.GooglePlus;
            ViewBag.Linkedin = meta.Linkedin;
            ViewBag.Youtube = meta.Youtube;
            ViewBag.Diger = meta.Diger;

            return PartialView("~/Views/_Partial/_Menu.cshtml", model);

        }
        public PartialViewResult HeaderReklam()
        {
            var model = new HeaderModel();
            model.Slider = db.Slider.Where(s => s.Aktif == true).ToList();
            model.Haberler = db.Haberler.Where(h => h.Aktif == true).OrderByDescending(h => h.Id).Take(20).ToList();
            return PartialView("~/Views/_Partial/_headerReklam.cshtml", model);

        }
        public PartialViewResult Body1()
        {

            var model = new BodyModel();

            //slider
            model.Slider = db.Slider.Where(sld => sld.Aktif == true).OrderBy(sld => sld.Sira).ToList();

            return PartialView("~/Views/_Partial/_Body1.cshtml", model);

        }
        public PartialViewResult Body2()
        {

            var model = new BodyModel();
            // haberler
            model.Haberler = db.HaberKategorileri.Where(h => h.Slug.Contains("haberler") || h.Slug.Contains("roportajlar")).OrderByDescending(h => h.KategoriId).ToList();
            model.Slider = db.Slider.Where(s => s.Aktif == true).ToList();

            return PartialView("~/Views/_Partial/_Body2.cshtml", model);

        }
        void Slider()
        {
            //slider
            var slider = db.Slider.Where(sld => sld.Aktif == true).OrderBy(sld => sld.Sira).ToList();
            TempData["slider"] = slider;

            var popup = db.Slider.Where(sld => sld.Aktif == true && sld.SliderId == 18).OrderBy(sld => sld.Sira).ToList();
            TempData["popup"] = popup;

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
        public PartialViewResult AltMenu()
        {

            var bilgi = db.iletisim.OrderBy(b => new { b.Telefon }).FirstOrDefault();
            var meta = db.MetaTag.OrderBy(m => m.SiteLogo).FirstOrDefault();

            ViewBag.Telefon = bilgi.Telefon;
            ViewBag.Logo = meta.SiteLogo;

            return PartialView("~/Views/_Partial/_AltMenu.cshtml");

        }

        //[Route("Home/Arama")]
        [HttpPost]
        public async Task<PartialViewResult> Arama(string searchKey)
        {
            AramaModel viewModel = null;

            var tasks = new Task[2];
            int i = 0;
            viewModel = new AramaModel();
            viewModel.SearchKey = Kontrol.AramaKontrol(searchKey);
            List<Task> TaskList = AramaSonucGetir(searchKey, viewModel);
            foreach (Task tsk in TaskList)
            {
                tasks[i] = tsk;
                i++;
            }
            await Task.WhenAll(tasks);

            return PartialView("~/Views/_Partial/_AramaSonuc.cshtml", viewModel);
        }

        private List<Task> AramaSonucGetir(string search, AramaModel model)
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<Task> Tasks = new List<Task>();
            var taskCustomer = Task.Factory.StartNew(() =>
            {
                using (Entities dbContext = new Entities())
                {
                    model.Kurumlar = dbContext.Kurumlar.Include("Kategoriler").Where(ur => ur.KurumAdi.Contains(search) && ur.Durum == true).Take(10).ToList();
                    if (model.Kurumlar.Count < 1)
                    {
                        try
                        {


                            var urun = db.Kurumlar.Where(k => SqlFunctions.SoundCode(k.KurumAdi) == SqlFunctions.SoundCode(search) && k.Durum == true).Select(k => new { k.KurumAdi }).FirstOrDefault();

                            if (urun != null)
                            {
                                model.DidYouMean = urun.KurumAdi;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            });
            Tasks.Add(taskCustomer);
            var taskSupplier = Task.Factory.StartNew(() =>
            {
                using (Entities dbContext = new Entities())
                {
                    model.Kategoriler = dbContext.Kategoriler.Where(k => k.KategoriAdi.Contains(search) && k.Aktif == true).ToList();

                    if (model.Kategoriler.Count < 1)
                    {
                        try
                        {
                            var kat = db.Kategoriler.Where(k => SqlFunctions.SoundCode(k.KategoriAdi) == SqlFunctions.SoundCode(search) && k.Aktif == true).Select(k => new { k.KategoriAdi }).FirstOrDefault();

                            if (kat != null)
                            {
                                model.DidYouMean = kat.KategoriAdi;
                            }
                        }
                        catch (Exception)
                        {


                        }

                    }
                }
            });
            Tasks.Add(taskSupplier);

            return Tasks;
        }

        //[Route("Home/HaberAra")]
        [HttpPost]
        public async Task<PartialViewResult> HaberAra(string searchKey)
        {
            HaberAramaModel viewModel = null;

            var tasks = new Task[1];
            int i = 0;
            viewModel = new HaberAramaModel();
            viewModel.SearchKey = Kontrol.AramaKontrol(searchKey);
            List<Task> TaskList = GetSeachResult(searchKey, viewModel);
            foreach (Task tsk in TaskList)
            {
                tasks[i] = tsk;
                i++;
            }
            await Task.WhenAll(tasks);

            return PartialView("~/Views/_Partial/_HaberAramaSonuc.cshtml", viewModel);
        }

        private List<Task> GetSeachResult(string search, HaberAramaModel model)
        {
            db.Configuration.LazyLoadingEnabled = false;

            List<Task> Tasks = new List<Task>();
            var taskNews = Task.Factory.StartNew(() =>
            {
                using (Entities dbContext = new Entities())
                {
                    model.Haberler = dbContext.Haberler.Where(ur => ur.Ad.Contains(search) && ur.Aktif == true).ToList();
                    if (model.Haberler.Count < 1)
                    {
                        try
                        {


                            var urun = db.Haberler.Where(k => SqlFunctions.SoundCode(k.Ad) == SqlFunctions.SoundCode(search) && k.Aktif == true).Select(k => new { k.Ad }).FirstOrDefault();

                            if (urun != null)
                            {
                                model.DidYouMean = urun.Ad;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            });
            Tasks.Add(taskNews);


            return Tasks;
        }

        public void GelismisAramaBilgi()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.Where(k => k.Aktif == true).OrderBy(k => k.Sira).ToList(), "KategoriId", "KategoriAdi");
            ViewBag.ilId = new SelectList(db.iller.Where(i => i.ilId == 40 || i.ilId == 82).ToList(), "ilId", "ilAdi");
            // ViewBag.ilceId = new SelectList(db.ilceler.Where(i => i.ilId == 40 || i.ilId == 82), "ilceId", "ilceAdi");

        }

        public void AnketlerBilgi()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.Where(k => k.Aktif == true).OrderBy(k => k.Sira).ToList(), "KategoriId", "KategoriAdi");

        }

        //[Route("Home/ilceGetir")]
        public ActionResult ilceGetir(int ilId)
        {
            var kategoriler = db.ilceler.Where(k => k.ilId == ilId).Select(k => new { k.ilceAdi, k.ilceId }).ToList();

            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }

        //[Route("Home/AltKategoriGetir")]
        public ActionResult AltKategoriGetir(int KategoriId)
        {
            var kategoriler = db.AltKategoriler.Where(k => k.KategoriId == KategoriId).Select(k => new { k.AltKategoriAdi, k.AltKategoriId }).ToList();

            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }

        //[Route("Home/EnSevdiginizOgretmenveBransiGetir")]
        public ActionResult EnSevdiginizOgretmenveBransiGetir(int KurumId)
        {
            var kurumEgitimciler = db.KurumEgitimciler.Where(k => k.KurumId == KurumId && k.Tip == 1).Select(k => new { k.Aciklama, k.EgitimciId }).ToList();

            return Json(kurumEgitimciler, JsonRequestBehavior.AllowGet);
        }

        //[Route("Home/EnSevdiginizYoneticiGetir")]
        public ActionResult EnSevdiginizYoneticiGetir(int KurumId)
        {
            var kurumEgitimciler2 = db.KurumEgitimciler.Where(k => k.KurumId == KurumId && k.Tip == 2).Select(k => new { k.Aciklama, k.EgitimciId }).ToList();

            return Json(kurumEgitimciler2, JsonRequestBehavior.AllowGet);
        }


        //[Route("Home/KategoriGetir")]
        public ActionResult KategoriGetir(int KategoriId)
        {
            var kategoriler = db.Kategoriler.Select(k => new { k.KategoriAdi, k.KategoriId }).ToList();

            return Json(kategoriler, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("Arama")]
        public ActionResult Arama(GelismisAramaModel arama, int? Sayfa)
        {

            int _sayfaNo = Sayfa ?? 1;
            IPagedList<Kurumlar> kurumlar;

            if (arama.KategoriId != 0 && arama.AltKategoriId != 0 && arama.ilId != 0 && arama.ilceId != 0 && string.IsNullOrEmpty(arama.SearchKey))
            {
                kurumlar = db.Kurumlar.Where(k => k.KategoriId == arama.KategoriId && k.AltKategoriId == arama.AltKategoriId && k.ilId == arama.ilId && k.ilceId == arama.ilceId && k.Durum == true).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }
            else if (arama.KategoriId != 0 && arama.ilId != 0 && arama.ilceId != 0 && string.IsNullOrEmpty(arama.SearchKey))
            {
                kurumlar = db.Kurumlar.Where(k => k.KategoriId == arama.KategoriId && k.ilId == arama.ilId && k.ilceId == arama.ilceId && k.Durum == true).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }
            else if (arama.KategoriId != 0 && arama.ilId != 0 && string.IsNullOrEmpty(arama.SearchKey))
            {
                kurumlar = db.Kurumlar.Where(k => k.KategoriId == arama.KategoriId && k.ilId == arama.ilId && k.Durum == true).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }
            else if (arama.KategoriId != 0 && string.IsNullOrEmpty(arama.SearchKey))
            {
                kurumlar = db.Kurumlar.Where(k => k.KategoriId == arama.KategoriId && k.Durum == true).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }
            else if (string.IsNullOrEmpty(arama.SearchKey) == true)
            {
                kurumlar = db.Kurumlar.OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }
            else
            {
                kurumlar = db.Kurumlar.Where(k => k.KurumAdi.Contains(arama.SearchKey) && k.Durum == true).OrderByDescending(u => u.KurumId).ToPagedList<Kurumlar>(_sayfaNo, 20);
            }

            if (kurumlar.Count == 0)
            {
                ViewBag.bilgi = "Arama kriterlernize uygun sonuç bulunamadı.";

            }
            return View(kurumlar);
        }
        //[Route("AnketGonder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnketGonder(string KurumId, string OgrencininAdi, string OgrencininSinifi, string EnSevdiginizOgretmenveBransi, string EnSevdiginizOgretmenvNedeni, string EnSevdiginizYonetici, string EnSevdiginizYoneticiNedeni)
        {
            string IpAdresi = Kontrol.IpAdresi();
            Int32 KurumIdKontol = Convert.ToInt32(KurumId);
            Int32 IpAdresiCheck = db.Anketler.Where(b => b.Ay == DateTime.Now.Month && b.Yil == DateTime.Now.Year && b.ip == IpAdresi && b.KurumId == KurumIdKontol).Count();

            if (IpAdresiCheck == 0)
            {
                if (KurumId != "" && OgrencininAdi != "" && OgrencininSinifi != "" && OgrencininSinifi != "" && EnSevdiginizOgretmenveBransi != "" && EnSevdiginizOgretmenvNedeni != "" && EnSevdiginizYonetici != "" && EnSevdiginizYoneticiNedeni != "")
                {
                    Anketler anketler = new Anketler();
                    anketler.Ay = DateTime.Now.Month;
                    anketler.Yil = DateTime.Now.Year;
                    anketler.KurumId = Convert.ToInt32(KurumId);
                    anketler.OgrencininAdi = OgrencininAdi;
                    anketler.OgrencininSinifi = OgrencininSinifi;
                    anketler.EnSevdiginizOgretmenveBransi = Convert.ToInt32(EnSevdiginizOgretmenveBransi);
                    anketler.EnSevdiginizOgretmenvNedeni = EnSevdiginizOgretmenvNedeni;
                    anketler.EnSevdiginizYonetici = Convert.ToInt32(EnSevdiginizYonetici);
                    anketler.EnSevdiginizYoneticiNedeni = EnSevdiginizYoneticiNedeni;
                    anketler.Tarih = DateTime.Now;
                    anketler.ip = Kontrol.IpAdresi();
                    db.Anketler.Add(anketler);
                    db.SaveChanges();

                    return Json(new { success = true, responseText = "Anketiniz başarıyla gönderildi." });
                }
                else
                {
                    return Json(new { success = false, responseText = "Lütfen bilgilerinizi kontrol edip tekrar deneyiniz." });
                }
            }
            else
            {
                return Json(new { success = false, responseText = "HER ÖĞRENCİNİN VELİNİN AYNI IP DEN TEK KATILIM HAKKI VARDIR." });
            }


        }


        //[Route("Home/AnketGonder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnketGonder(string adSoyad, string mail, string telefon, int kurum, string mesaj, string url)
        {

            if (adSoyad != null && mail != null && mesaj != null && kurum > 0 && Kontrol.mailValidation(mail) == true)
            {



                return Json(new { success = true, responseText = "Anketiniz başarıyla gönderildi." });

            }
            else
            {
                return Json(new { success = false, responseText = "Lütfen bilgilerinizi kontrol edip tekrar deneyiniz." });
            }

        }

        //[Route("Home/MesajGonder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MesajGonder(string adSoyad, string mail, string telefon, int kurum, string mesaj, string url)
        {

            if (adSoyad != null && mail != null && mesaj != null && kurum > 0 && Kontrol.mailValidation(mail) == true)
            {

                var kurumMail = db.Kurumlar.Where(k => k.KurumId == kurum).Select(k => k.Email).FirstOrDefault();

                string icerik = "<b>Kurum detay sayfanızdan bir mesaj aldınız.</b> <br/> <b>Gönderen:</b>  " + adSoyad + "<br/>" + " <b>Telefon: </b>" + telefon + "<br/> <b>Mail: </b>" + mail + "<br/> <b>Mesaj: </b>" + mesaj + " <br/> <b>Kaynak Url: </b> " + url;

                Helpers.SendMail.Mail("İletişim Formu Mesajı", icerik, kurumMail);



                return Json(new { success = true, responseText = "Mesajınız başarıyla gönderildi." });

            }
            else
            {
                return Json(new { success = false, responseText = "Lütfen bilgilerinizi kontrol edip tekrar deneyiniz." });
            }

        }
        //[Route("Home/BultenKayit")]
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

                    string icerik = "<b>Email Bültenine yeni bir kayıt eklendi</b> " + "<br/> <b>Mail: </b>" + bulten.Mail + "<br/> <b>Ip Adresi: </b>" + bulten.Ip;

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