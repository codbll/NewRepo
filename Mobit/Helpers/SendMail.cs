using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;

namespace Mobit.Helpers
{
    public class SendMail
    {
       
        public static void Mail(string Konu, string icerik, string gidecekMailler)
        {

            ServicePointManager.ServerCertificateValidationCallback =
 delegate (object s, X509Certificate certificate,
          X509Chain chain, SslPolicyErrors sslPolicyErrors)
 { return true; };

            var config = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;


            string gonderenMail = config.Network.UserName;
            if (gidecekMailler == null || gidecekMailler == "")
            {
                gidecekMailler = gonderenMail;
            }
        
            WebMail.SmtpServer = config.Network.Host;
            WebMail.EnableSsl = config.Network.EnableSsl;
            WebMail.UserName = gonderenMail;
            WebMail.Password = config.Network.Password;
            WebMail.SmtpPort = config.Network.Port;
            WebMail.Send(gidecekMailler, Konu, icerik, gonderenMail);
          

        }
    }
}