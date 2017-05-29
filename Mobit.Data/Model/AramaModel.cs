using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobit.Data.Model
{
    public class AramaModel
    {
        public List<Kurumlar> Kurumlar { get; set; }
        public List<Kategoriler> Kategoriler { get; set; }
        public string SearchKey { get; set; }
        public string DidYouMean { get; set; }

    }


    public static class HtmlHelperExtensions
    {
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
