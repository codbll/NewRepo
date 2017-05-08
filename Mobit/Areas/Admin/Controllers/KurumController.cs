using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Areas.Admin.Controllers
{
    [_Yetki]
    public class KurumController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }
    }
}