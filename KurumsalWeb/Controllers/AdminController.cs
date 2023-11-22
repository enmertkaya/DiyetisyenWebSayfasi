using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Web.Mail;
using KurumsalWeb.Models;
using KurumsalWeb.Models.Model;
using KurumsalWeb.Models.Context;

namespace KurumsalWeb.Controllers
{
    public class AdminController : Controller
    {
        AdminContext db = new AdminContext();

        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategoris.ToList();
            
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admins.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta==admin.Eposta && login.Sifre==admin.Sifre)
            {
                Session["AdminId"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");

            }
            ViewBag.Uyari = "Kullanıcı adı yada sifre yanlis";
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            Session["Sifre"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

    }
}