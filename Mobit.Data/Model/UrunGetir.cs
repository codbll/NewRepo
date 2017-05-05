using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobit.Data.Model
{
    // teknik destek alt kategoriye bağlı ürünleri listelemeki için kullandığım model

    public class UrunGetir
    {
        [Key]
        public int UrunId { get; set; }
        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }
    }
}
