using Mobit.Data.Context;
using Mobit.Models;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Controllers
{
    public class iletisimController : Controller
    {
        Entities db = new Entities();
        // GET: iletisim

        public ActionResult Index()
        {
            var iletisim = db.iletisim.FirstOrDefault();

            return View(iletisim);
        }



        [Route("iletisim/MailGonder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MailGonder(string adSoyad, string mail, string telefon, string konu, string mesaj, string url)
        {

            if (adSoyad != null && mail != null && mesaj != null && Kontrol.mailValidation(mail) == true)
            {

                var mailler = db.iletisim.Select(m => new { m.Mailler }).FirstOrDefault();

                string icerik = "<b>Mobit iletişim formu mesajı.</b> <br/> <b>Gönderen:</b>  " + adSoyad + "<br/> <b>Konu: </b>" + konu + "<br/> <b>Telefon: </b>" + telefon + "<br/> <b>Mail: </b>" + mail + "<br/> <b>Mesaj: </b>" + mesaj + " <br/> <b>Kaynak Url: </b> " + url;

                Helpers.SendMail.Mail(konu, icerik, mailler.Mailler);



                return Json(new { success = true, responseText = "Mesajınız başarıyla gönderildi." });


            }
            else
            {
                return Json(new { success = false, responseText = "Lütfen bilgilerinizi kontrol edip tekrar deneyiniz." });
            }

        }

        [Route("insan-kaynaklari")]
        public ActionResult ikCv()
        {
            return View();
        }

        [Route("insan-kaynaklari")]
        [HttpPost]
        public ActionResult ikCv(cvModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var config = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

                    using (MailMessage mail = new MailMessage(config.Network.UserName, "ik@mobit.com.tr"))
                    {

                        mail.Subject = "Mobit İK Başvuru Formu";
                        string body = "Ad Soyad: " + model.AdSoyad + " <br></br> Email: " + model.Email;
                        mail.Body = body;

                        if (model.File != null)
                        {
                            string fileName = Path.GetFileName(model.File.FileName);
                            mail.Attachments.Add(new Attachment(model.File.InputStream, fileName));
                        }
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = config.Network.Host;
                        smtp.EnableSsl = false;
                        NetworkCredential networkCredential = new NetworkCredential(config.Network.UserName, config.Network.Password);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = config.Network.Port;
                        smtp.Send(mail);

                        TempData["Bilgi"] = "Başvurunuz  gönderildi.";

                        return View();
                    }
                }
                catch (System.Exception)
                {
                    TempData["Hata"] = "Başvurunuz gönderilemedi lütfen tekrar deneyin.";

                }



            }


            return View();
        }
    }
}