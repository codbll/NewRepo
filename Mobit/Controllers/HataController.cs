using Mobit.Data.Context;
using Mobit.Data.Model;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Mobit.Controllers
{

    public class HataController : Controller
    {
        Entities db = new Entities();


        // GET: 404 genel hata
        public ActionResult Index()
        {
            return View();
        }

        // mobit eski site urun url kontrolü
        //[Route("urunler/{KategoriSlug}/{urunSlug}")]
        public ActionResult Urun(string KategoriSlug, string urunSlug)
        {
            //string urun = UrunKontrol(urunSlug);

            //if (urun == "" || urun == null)
            //{
            //    return View();

            //}
            //else
            //{
            //    return RedirectPermanent(urun); // 301 yönlendir
            //}

            //Değişiklik:
            // bu yöntem ile ürünlerin %70 oranı tahmin edilebiliyordu. %100 kesin sonuç için tüm ürünleri xml formatı ile kontrol ettim

            string url = Kontrol.SayfaUrlAl(2);

            string xmlData = Server.MapPath("~/RoutesProducts.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);

            var redirect = (from rows in ds.Tables[0].AsEnumerable()
                            where rows[0].ToString() == url
                            select new RouteRecirect
                            {
                                From = rows[0].ToString(),
                                To = rows[1].ToString(),
                            }).FirstOrDefault();


            if (redirect == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectPermanent(redirect.To);

           

        }

       
        //[Route("Kategoriler/{KategoriSlug}/")]
        public ActionResult Kategori(string KategoriSlug)
        {
            string kategori = KategoriKontrol(KategoriSlug);
            if (kategori == "" || kategori == null)
            {
                return View();

            }
            else
            {
                return RedirectPermanent(kategori);
            }

        }

        public string KategoriKontrol(string search)
        {
            db.Configuration.LazyLoadingEnabled = false;


            //var kategori = (from k in db.AltKategoriler.Include("Kategoriler")
            //                where SqlFunctions.SoundCode(k.Slug) == SqlFunctions.SoundCode(search) && k.Aktif == true
            //                orderby k.Slug
            //                select new UrunGelenUrl // ürün için olan classı burada da kullandım
            //                {
            //                    urunSlug = k.Slug, // alt kategori slug anlamı taşır
            //                    kategoriSlug = k.Kategoriler.Slug
            //                }).FirstOrDefault();

            var altkategori = (from k in db.AltKategoriler.Include("Kategoriler") // alt kategoriler
                               where k.Slug.Contains(search) && k.Aktif == true
                               orderby k.Slug
                               select new UrunGelenUrl // ürün için olan classı burada da kullandım
                               {
                                   urunSlug = k.Slug, // alt kategori slug anlamı taşır
                                   kategoriSlug = k.Kategoriler.Slug
                               }).FirstOrDefault();

            string sonuc;
            if (altkategori == null)
            {
                sonuc = "";
            }
            else
            {
                sonuc = "/Kategori/" + altkategori.kategoriSlug + "/" + altkategori.urunSlug;
            }

            if (sonuc == null) //  kategoride ara- mobit sitesinde kategori ve alt kategori static olarak aynı url den yönetiliyor
            {
                var kategori = (from k in db.Kategoriler
                                where k.Slug.Contains(search) && k.Aktif == true
                                orderby k.Slug
                                select new UrunGelenUrl // ürün için olan classı burada da kullandım
                                {
                                    kategoriSlug = k.Slug
                                }).FirstOrDefault();

                if (altkategori == null)
                {
                    sonuc = "";
                }
                else
                {
                    sonuc = "/Kategori/" + kategori.kategoriSlug;
                }
            }



            return sonuc;

        }
    }
}