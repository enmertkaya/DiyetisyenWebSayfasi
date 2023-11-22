using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaId { get; set; }
        [Required]
        [DisplayName("Hakkimizda Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Satir 1 Aciklama")]
        public string Satir1Aciklama { get; set; }
        [DisplayName("Satir 2 Aciklama")]
        public string Satir2Aciklama { get; set; }
        [DisplayName("Satir 3 Aciklama")]
        public string Satir3Aciklama { get; set; }
        [DisplayName("Sonuc Aciklama")]
        public string SonAciklama { get; set; }
        [DisplayName("Site Linki")]
        public string Link { get; set; }
        public string ResimURL { get; set; }
        public string Baslik { get; set; }
    }
}