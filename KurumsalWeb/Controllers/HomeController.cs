using KurumsalWeb.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private AdminContext db = new AdminContext();
        // GET: Home
        [Route("AnaSayfa")]
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmets.ToList().OrderByDescending(x => x.HizmetId);
            ViewBag.Hakkimizda = db.Hakkimizdas.ToList().OrderByDescending(x => x.HakkimizdaId);
            ViewBag.Kimlik = db.Kimliks.ToList().OrderByDescending(x => x.KimlikId);
           
            return View();
        }
        [HttpPost]
        public ActionResult Index (string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "lastgamle@gmail.com";
                WebMail.Password = "lyzokvwbthwpdeyg";
                WebMail.SmtpPort = 587;
                WebMail.Send("93enesmertkaya@gmail.com", konu, email + " - " + mesaj);

                ViewBag.Uyari = "Mesajınız başarı ile gönderilmistir";

            }
            else
            {
                ViewBag.Uyari = "Hata oluştu.Tekrar deneyiniz.";
            }

            return View();
        }
        public ActionResult SliderPartial ()
        {
            return View(db.Sliders.ToList().OrderByDescending(x=>x.SliderId));
        }
      
        


    }
}