using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobit.Data.Model
{
    // ürün ekleme için kullandığım kategoriye bağlı alt kategori getirme modeli.
    public class AltKategoriGetir
    {
        [Key]
        public int AltKategoriId { get; set; }
        [DisplayName("Alt Kategori")]
        public string AltKategoriAdi { get; set; }
    }
}
