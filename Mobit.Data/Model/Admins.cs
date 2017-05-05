using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Mobit.Data.Model
{

    public class Admins
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = " {0} boş geçilemez")]
        [DisplayName("Ad Soyad")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = " {0} boş geçilemez")]
        [EmailAddress(ErrorMessage = "Format uygun değil")]
        [DisplayName("Mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage = " {0} boş geçilemez")]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [DataType(DataType.Password)]
        [Compare("Sifre", ErrorMessage = "Şifreleriniz aynı değil")]
        [DisplayName("Şifte Tekrarı")]
        public string SifreTekrar { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<bool> Owner { get; set; }
    }
}
