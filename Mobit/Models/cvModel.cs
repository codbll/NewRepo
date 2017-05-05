using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class cvModel
    {

        [Required(ErrorMessage = " Ad ve Soyadınız boş geçilemez")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = " Email adresiniz boş geçilemez")]
        [EmailAddress(ErrorMessage = "Email formatı uygun değil")]
        [DisplayName("Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = " Lütfen bir dosya seçiniz")]
        //[FileExtensions(ErrorMessage = "Sadece Pdf ve Word dosyaları seçebilirsiniz.", Extensions = "pdf,doc,docx")]
        public HttpPostedFileBase File { get; set; }
    }
}