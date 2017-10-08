using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class SponsorlarDetayModel
    {
        public List<Slider> Slider { get; set; }
        public List<Haberler> Haberler { get; set; }
        public Kurumlar Kurumlar { get; set; }
    }
}