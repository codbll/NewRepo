using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class MenuModel
    {
        public List<Kategoriler> Kategoriler { get; set; }
        public List<iller> iller { get; set; }
        public List<ilceler> ilceler { get; set; }

    }
}