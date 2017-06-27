using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class BodyModel
    {
       
        public List<Slider> Slider { get; set; }

        public List<sp_EniyiEgitimciler2_Result> spEniyiEgitimci_Result { get; set; }
        public List<sp_Eniyikurumlar_Result> spEniyikurum_Result { get; set; }
        public List<sp_EniyiYoneticiler_Result> spEniyiYonetici_Result { get; set; }
        public List<HaberKategorileri> Haberler { get; set; }




    }
}