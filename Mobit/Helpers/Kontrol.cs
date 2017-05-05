using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Mvc;

/// <summary>
/// Summary description for Kontrol
/// </summary>
public class Kontrol
{
    public Kontrol()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public static string Excel(string metin)
    {
        string deger = metin;

        deger = deger.Replace("&#199;", "Ç");
        deger = deger.Replace("&#252;", "ü");
        deger = deger.Replace("&#246;", "ö");
        deger = deger.Replace("&#231;", "ç");
        deger = deger.Replace("&#220;", "Ü");
        deger = deger.Replace("&#214;", "Ö");
        deger = deger.Replace("&nbsp;", "");
        deger = deger.Replace("Ä±", "ı");



        return deger;
    }
    public static string EmailGirisTemizle(string metin)
    {
        string deger = metin;
        // mailler bu karakterlerden oluşmazlar.
        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("*", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("select", "");
        deger = deger.Replace("insert", "");
        deger = deger.Replace("update", "");
        deger = deger.Replace("delete", "");
        deger = deger.Replace("truncate ", "");
        deger = deger.Replace("char", "");
        deger = deger.Replace("union ", "");
        deger = deger.Replace("script ", "");

        return deger;
    }

    public static string AramaKontrol(string metin)
    {
        string deger = metin;

        deger = deger.Replace("&", "");
        //deger = deger.Replace("-", ""); stok kodunda olabilir diye kaldırdım
        deger = deger.Replace("'", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        //deger = deger.Replace(".", ""); para değerinde var diye kaldırdım
        deger = deger.Replace("“", "");
        // deger = deger.Replace("’", ""); ""      ""
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "");
        deger = deger.Replace("/", "");
        deger = deger.Replace("<>", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("!", "");
        deger = deger.Replace("<s", "");
        deger = deger.Replace("<S", "");
        deger = deger.Replace("<Script>", "");
        deger = deger.Replace("<Alert>", "");
        deger = deger.Replace("</Script>", "");
        deger = deger.Replace("<script>", "");
        deger = deger.Replace("<script", "");
        deger = deger.Replace("</<script>", "");
        deger = deger.Replace("<alert>", "");
        deger = deger.Replace("\\", "");



        return deger;
    }

    public static string Yonlendirme(string metin)
    {
        string deger = metin;

        deger = deger.Replace("<meta", "*meta");
        deger = deger.Replace("<META", "*META");
        deger = deger.Replace("http-equiv=\"refresh\"", "*");
        deger = deger.Replace("HTTP-EQUIV=\"Refresh\"", "*");
        deger = deger.Replace("CONTENT=\"", "");
        deger = deger.Replace("<script", "*");
        deger = deger.Replace("<SCRIPT", "*");
        deger = deger.Replace("document.location", "*");
        deger = deger.Replace("window.location", "window . location");
        deger = deger.Replace("</script>", "");
        deger = deger.Replace("</SCRIPT>", "");


        return deger;
    }
    public static string Temizle(string metin)
    {
        string deger = metin;

        deger = deger.Replace("'", "");
        deger = deger.Replace("<>", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("-", "-");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        //deger = deger.Replace(".", "");  upload  uzantısı için kaldırdım
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("“", "");
        deger = deger.Replace("’", "");
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace(" ", "-");
        deger = deger.Replace(",", "-");
        deger = deger.Replace(":", "-");
        deger = deger.Replace("?", "-");
        deger = deger.Replace("/", "-");
        deger = deger.Replace("\\", "-");
        deger = deger.Replace("!", "-");
        deger = deger.Replace(",", "");
        deger = deger.Replace("?", "");




        return deger;
    }

    public static string UrlSeo(string metin)
    {
        string deger = metin;
        deger = deger.Replace(",", "");
        deger = deger.Replace("!", "");
        deger = deger.Replace(" ", "-");
        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("ı", "i"); // türkçe karakterleri ing karışılı karakterelrde değiştir.
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("I", "i");// BÜYÜK türkçe karakterlerin ing karışılı karakterelrde değiştir.
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace(":", "");
        deger = deger.Replace("İ", "i");
        deger = deger.Replace("-", "-");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace(".", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("/", "");
        deger = deger.Replace("\\", "");
        deger = deger.Replace("“", "");
        deger = deger.Replace("’", "");
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "");





        string deger1 = "";

        deger = deger.Replace("" + '"' + deger1 + '"', "-");
        return deger;
    }

    public static string UrlTemizle(string metin)
    {
        string deger = metin;

        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("A'", "");
        deger = deger.Replace("ı", "i"); // türkçe karakterleri ing karışılı karakterelrde değiştir.
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("I", "i");// BÜYÜK türkçe karakterlerin ing karışılı karakterelrde değiştir.
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace(" ", "-");
        deger = deger.Replace(",", "-");
        deger = deger.Replace(".", "-");
        deger = deger.Replace(":", "-");
        deger = deger.Replace("?", "-");
        deger = deger.Replace("/", "-");
        deger = deger.Replace("\\", "-");
        deger = deger.Replace("!", "-");
        deger = deger.Replace(",", "");
        deger = deger.Replace("?", "");
        string deger1 = "";

        deger = deger.Replace("" + '"' + deger1 + '"', "-");
        return deger;
    }
    public static string UrlQuery(string metin)
    {
        string deger = metin;

        deger = deger.Replace("'", "-");
        deger = deger.Replace("<", "-");
        deger = deger.Replace(">", "-");
        deger = deger.Replace("&", "-");
        deger = deger.Replace("[", "-");
        deger = deger.Replace("]", "-");
        deger = deger.Replace("'a", "-");
        deger = deger.Replace(" ", "-");
        deger = deger.Replace(",", "-");
        deger = deger.Replace(".", "-");
        deger = deger.Replace(":", "-");
        deger = deger.Replace("?", "-");
        deger = deger.Replace("/", "-");
        deger = deger.Replace("\\", "-");
        deger = deger.Replace("!", "-");
        deger = deger.Replace(",", "-");
        deger = deger.Replace("?", "-");
        string deger1 = "";

        deger = deger.Replace("" + '"' + deger1 + '"', "-");
        return deger;
    }
    public static string SayiKontrol(string text)
    {
        try
        {
            int x = Convert.ToInt32(text);

        }
        catch
        {
            text = "0";
        }
        return text;
    }

    public static string OzetCek(string metin, int karakter)
    {
        if (metin.Length >= karakter)
        {
            metin = metin.Substring(0, karakter);
        }
        return metin;
    }

    public static string Md5Sifrele(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static string SifreOlustur()
    {
        int length = 10;
        string chars = "aBcDeFgHiJkLmNoPrStUvUzWxQ1234567890+-*\"";

        StringBuilder Password = new StringBuilder();
        Random Rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            Password = Password.Append(chars[Rnd.Next(0, chars.Length)]);
        }

        return Password.ToString();
    }

    public static void MailGonder(string MailSmtp, int MailPort, string MailSifre, string Gonderen, string Giden, string MesajBaslik, string Mesajicerigi)
    {
        try
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = MailPort;
            smtp.Host = MailSmtp;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(Gonderen, MailSifre);
            MailAddress mSender = new MailAddress(Gonderen);
            MailAddress mTo = new MailAddress(Giden);

            MailMessage mesaj = new MailMessage(mSender, mTo);
            mesaj.IsBodyHtml = true;
            mesaj.Subject = HttpContext.Current.Request.Url.Host.ToString() + " " + MesajBaslik;

            // mesaj.Body = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).ToString(); full site urlsi


            mesaj.Body = Mesajicerigi;
            mesaj.Bcc.Add(Giden);

            smtp.Send(mesaj);


        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public static void Yonlendir(string mesaj, string UrlAdres)
    {
        HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "'); window.location.href ='" + UrlAdres + "';</script>");

    }

    public static void GeldigiSayfayaGit()
    {
        try
        {
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.UrlReferrer.ToString());

        }
        catch (Exception)
        {


        }
    }

    public static string SayfaUrlAl(int Tip)
    {
        string deger = "";
        if (Tip == 1) // sadece domain adı al 
        {
            deger = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).ToString();

        }
        else if (Tip == 2) // sadece sayfa ismi
        {
            deger = HttpContext.Current.Request.RawUrl.ToString();

        }
        else if (Tip == 3) // full sayfa adresi al
        {
            deger = HttpContext.Current.Request.Url.ToString();

        }

        else if (Tip == 4) // geldiği sayfa url
        {
            deger = HttpContext.Current.Request.UrlReferrer.ToString();

        }
        return deger.ToString();
    }

    public static string Zaman(DateTime dt)
    {

        if (dt > DateTime.Now)
            //return "bir kaç dakika önce";
            return dt.ToString("dd.MM.yyyy"); //hataya karşı henüz gelmemiş bugünden ileri bir tarihte olduğu gibi gönder.
        TimeSpan span = DateTime.Now - dt;

        if (span.Days > 365)
        {
            int years = (span.Days / 365);
            if (span.Days % 365 != 0)
                years += 1;
            return String.Format("{0} {1} önce", years, years == 1 ? "yıl" : "yıl");
        }

        if (span.Days > 30)
        {
            int months = (span.Days / 30);
            if (span.Days % 31 != 0)
                months += 1;
            return String.Format("{0} {1} önce", months, months == 1 ? "ay" : "ay");
        }

        if (span.Days > 0)
            return String.Format("{0} {1} önce", span.Days, span.Days == 1 ? "gün" : "gün");

        if (span.Hours > 0)
            return String.Format("{0} {1} önce", span.Hours, span.Hours == 1 ? "saat" : "saat");

        if (span.Minutes > 0)
            return String.Format("{0} {1} önce", span.Minutes, span.Minutes == 1 ? "dk" : "dk");

        if (span.Seconds > 5)
            return String.Format("{0} saniye önce", span.Seconds);

        if (span.Seconds <= 5)
            return "şimdi";

        return string.Empty;
    }

    public static string FirmaId()
    {
        // HttpContext.Current.Session.Add("FirmaId", 8);

        string FirmaId = "";
        try
        {
            FirmaId = HttpContext.Current.Session["FirmaId"].ToString();
        }
        catch (Exception)
        {
            HttpContext.Current.Response.Redirect("/Kurumsal/Uyelik/Giris.aspx");
        }

        return FirmaId;
    }
    public static string UyeId()
    {
        //HttpContext.Current.Session.Add("AdminId", 1);

        string UyeId = "";
        try
        {
            UyeId = HttpContext.Current.Session["AdminId"].ToString();
        }
        catch (Exception)
        {
            HttpContext.Current.Response.Redirect("~/Admin/Uye");
        }

        return UyeId;
    }
    public static string LogUyeId()
    {

        string UyeId = "0";
        try
        { // hata varsa uyeid yerine 0 gönder ziyaretçidir veya session düşmüştür.
            UyeId = HttpContext.Current.Session["UyeId"].ToString();
        }
        catch (Exception)
        {

        }

        return UyeId;
    }

    public static string IpAdresi()
    {

        string IpAdres = "";
        if (HttpContext.Current.Request.ServerVariables["HTTP-X-FORWARDED-FOR"] != null)
        {
            IpAdres = HttpContext.Current.Request.ServerVariables["HTTP-X-FORWARDED-FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            IpAdres = HttpContext.Current.Request.UserHostAddress;
        }


        //try
        //{
        //    ip = HttpContext.Current.Request.UserHostAddress.ToString();

        //}
        //catch (Exception)
        //{

        //    ip = "0";
        //}

        return IpAdres;
    }

    public static string BytesToString(long byteCount)
    {
        string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        long bytes = Math.Abs(byteCount);
        int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
        double num = Math.Round(bytes / Math.Pow(1024, place), 1);
        return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
    }

    public static string SayiOlustur()
    {
        string sayi;
        Random harf = new Random();
        Random rakam = new Random();

        int ascii = harf.Next(65, 91);
        char karakter = Convert.ToChar(ascii);

        sayi = karakter + "-" + rakam.Next(10000, 99990);

        return sayi;
    }

    public static string Base64Encrypt(string data)
    {
        try
        {
            byte[] dataByteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
            string encryptedData = System.Convert.ToBase64String(dataByteArray);
            return encryptedData;
        }
        catch (Exception)
        {
            return data;
        }
    }

    public static string Base64Decrypt(string descryptData)
    {
        try
        {
            byte[] descryptDataArray = System.Convert.FromBase64String(descryptData);
            string originalData = System.Text.ASCIIEncoding.ASCII.GetString(descryptDataArray);
            return originalData;
        }
        catch (Exception)
        {
            return descryptData;
        }
    }

    public static string ToSlug(string incomingText)
    {
        incomingText = incomingText.Replace("ş", "s");
        incomingText = incomingText.Replace("Ş", "s");
        incomingText = incomingText.Replace("İ", "i");
        incomingText = incomingText.Replace("I", "i");
        incomingText = incomingText.Replace("ı", "i");
        incomingText = incomingText.Replace("ö", "o");
        incomingText = incomingText.Replace("Ö", "o");
        incomingText = incomingText.Replace("ü", "u");
        incomingText = incomingText.Replace("Ü", "u");
        incomingText = incomingText.Replace("Ç", "c");
        incomingText = incomingText.Replace("ç", "c");
        incomingText = incomingText.Replace("ğ", "g");
        incomingText = incomingText.Replace("Ğ", "g");
        incomingText = incomingText.Replace(" ", "-");
        incomingText = incomingText.Replace("---", "-");
        incomingText = incomingText.Replace("?", "");
        incomingText = incomingText.Replace("/", "");
        incomingText = incomingText.Replace(".", "");
        incomingText = incomingText.Replace("'", "");
        incomingText = incomingText.Replace("#", "");
        incomingText = incomingText.Replace("%", "");
        incomingText = incomingText.Replace("&", "");
        incomingText = incomingText.Replace("*", "");
        incomingText = incomingText.Replace("!", "");
        incomingText = incomingText.Replace("@", "");
        incomingText = incomingText.Replace("+", "");
        incomingText = incomingText.ToLower();
        incomingText = incomingText.Trim();

        // tüm harfleri küçült
        string encodedUrl = (incomingText ?? "").ToLower();

        // & ile " " yer değiştirme
        encodedUrl = Regex.Replace(encodedUrl, @"\&+", "-");

        // " " karakterlerini silme
        encodedUrl = encodedUrl.Replace("'", "");

        // geçersiz karakterleri sil
        encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

        // tekrar edenleri sil
        encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

        // karakterlerin arasına tire koy
        encodedUrl = encodedUrl.Trim('-');

        return encodedUrl;
    }

    public static string fileNameCreator(string fileName)
    {
        string isim = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random r = new Random();
        Random rnd = new Random();

        string name = rnd.Next(1, 10000).ToString() + isim[r.Next(0, 28)].ToString();



        fileName = Path.GetFileNameWithoutExtension(fileName) + "-" + name + Path.GetExtension(fileName);
        return Temizle(fileName);
    }

    public static bool mailValidation(string mail)
    {
        try
        {
            MailAddress m = new MailAddress(mail);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

}