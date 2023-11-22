using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olmalıdır")]

        public string Adres { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olmalıdır")]

        public string Telefon { get; set; }

        public string Faks { get; set; }
        public string WhatsApp { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

    }
}