using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {
        [Key]
        public int KimlikId { get; set; }
        [DisplayName("Tarifler Baslik")]
        [Required,StringLength(100,ErrorMessage ="100 karakter olmalidir")]
        public string Title { get; set; }
        [DisplayName("Tarifler Yan Baslik")]
        [Required, StringLength(200, ErrorMessage = "200 karakter olmalidir")]
        public string Keywords { get; set; }
        [DisplayName("Tarifler Aciklama")]
        [Required, StringLength(300, ErrorMessage = "300 karakter olmalidir")]
        public string Description { get; set; }
        [DisplayName("Tarifler Logo")]
        
        public string LogoURL { get; set; }

        public string Unvan { get; set; }
    }
}