using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class YetkiKontrol
{

    public static bool Yetki()
    {
        Entities db = new Entities();

        int AdminId = Convert.ToInt32(Kontrol.UyeId());

        //var yetki = db.Adminler.Where(adm => adm.AdminId == AdminId).Select(adm => adm.Yetki).FirstOrDefault();

        var yetki = db.AdminRolIliski.Where(rol => rol.AdminId == AdminId).Select(rol => rol.AdminRolleri.RolAdi).FirstOrDefault();
        if (yetki == "Admin")
        {
            return true;
        }
        else if (yetki == "Ürün Yöneticisi")
        {
            return false;
        }
        else
        {
            return false;
        }

    }

}
