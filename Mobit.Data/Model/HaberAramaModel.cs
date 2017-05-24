using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobit.Data.Model
{
    public class HaberAramaModel
    {
        public List<Haberler> Haberler { get; set; }
        public string SearchKey { get; set; }
        public string DidYouMean { get; set; }

    }


}
