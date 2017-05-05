using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin
{
    public class _SessionController : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // bu classı kullanmıyorum.
            //HttpContext.Current.Session.Add("AdminId", "2");
            //HttpContext.Current.Session.Add("AdSoyad", "Bilal ");
            //HttpContext.Current.Session["Yetki"] = "Ürün Yöneticisi";

            if (HttpContext.Current.Session["AdminId"] == null)
            {
                HttpContext.Current.Response.Redirect("/Admin/Uye");
            }
        }
    }
}