using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }
        public int? KategoriID { get; set; }
        public Kategori Kategori { get; set; }
    }
}