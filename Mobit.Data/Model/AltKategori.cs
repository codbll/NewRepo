using Mobit.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobit.Data.Model
{
    public partial class AltKategori
    {
        public int AltKategoriId { get; set; }
        public string AltKategoriAdi { get; set; }
        public string Ikon { get; set; }
        public string Slug { get; set; }
        public bool Aktif { get; set; }
        public bool Area { get; set; }
        public bool Depart { get; set; }
        public int KategoriId { get; set; }
        public int Sira { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }
    }
}
