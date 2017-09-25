using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin
{
    public class _Yetki : ActionFilterAttribute
    {
        public string Roles { get; set; }
        Entities db = new Entities();
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext.Current.Session.Add("AdminId", "1");
            //HttpContext.Current.Session.Add("AdSoyad", "Bilal ");
            //HttpContext.Current.Session["Yetki"] = "Admin";

            if (Roles == null || Roles == "")// normal session kontrolü - Rolün olmadığı oturum açmış herkes görebilir.
            {
                loginKontrol();
            }
            else// role göre kontrol
            {
                loginKontrol();
                int adminId = Convert.ToInt32(HttpContext.Current.Session["AdminId"]);
                string[] roller = Roles.Split(',');

                var rolVarmi = db.AdminRolIliski.Where(rol => rol.AdminId == adminId && roller.Contains(rol.AdminRolleri.RolAdi)).Select(rol => rol.AdminRolleri.RolAdi).FirstOrDefault();

                if (rolVarmi == null || rolVarmi == "")
                {
                    HttpContext.Current.Server.TransferRequest("/Admin/Home/YetkiYok", true);
                }
            }

        }

        void loginKontrol()
        {
            if (HttpContext.Current.Session["AdminId"] == null)
            {
                HttpContext.Current.Response.Redirect("/Admin/Uye", true);
            }
        }
    }
}