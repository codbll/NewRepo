using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class GelismisAramaModel
    {
        //[Required(ErrorMessage = "Lütfen kategori seçiniz")]
        public int KategoriId { get; set; }


        //[Required(ErrorMessage = "Lütfen Alt kategori seçiniz")]
        public int AltKategoriId { get; set; }

        //[Required(ErrorMessage = "Lütfen ilçe seçiniz")]
        public int ilId { get; set; }

        //[Required(ErrorMessage = "Lütfen ilçe seçiniz")]
        public int ilceId { get; set; }

        //[Required(ErrorMessage = "Lütfen arama kriterini yazınız")]
        public string SearchKey { get; set; }
    }
}