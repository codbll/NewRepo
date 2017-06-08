﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mobit.Models
{
    public class GelismisAramaModel
    {
        [Required(ErrorMessage = "Lütfen kategori seçiniz")]
        public int KategoriId { get; set; }
        [Required(ErrorMessage = "Lütfen arama kriterini yazınız")]
        public string SearchKey { get; set; }
    }
}