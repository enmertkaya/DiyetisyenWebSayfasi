using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    public class Hizmet
    {
        [Key]
        public int HizmetId { get; set; }

        [Required, StringLength(150, ErrorMessage = "150 karakter olabilir")]
        [DisplayName("Hizmet Baslik")]
        public string Baslik { get; set; }

        [DisplayName("Hizmet Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet Resim")]
        public string ResimURL { get; set; }
        [DisplayName("Satir 1 Aciklama")]
        public string Satir1Aciklama { get; set; }
        [DisplayName("Satir 2 Aciklama")]
        public string Satir2Aciklama { get; set; }
        [DisplayName("Satir 3 Aciklama")]
        public string Satir3Aciklama { get; set; }
        public string Satir4Aciklama { get; set; }
        public string Satir5Aciklama { get; set; }
        public string SonAciklama { get; set; }
    }
}