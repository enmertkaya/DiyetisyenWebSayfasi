using KurumsalWeb.Models.Context;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hizmet
        private AdminContext db = new AdminContext();
        public ActionResult Index()
        {
            return View(db.Hakkimizdas.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hakkimizda hakkimizda, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hakkimizda/" + logoname);

                    hakkimizda.ResimURL = "/Uploads/Hakkimizda/" + logoname;
                    
                }

                db.Hakkimizdas.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = ("Guncellenecek bir hizmet bulunamadı.");
            }
            var hakkimizda = db.Hakkimizdas.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }

            return View(hakkimizda);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda hakkimizda, HttpPostedFileBase ResimURL)
        {

            if (ModelState.IsValid)
            {
                var h = db.Hakkimizdas.Where(x => x.HakkimizdaId == id).SingleOrDefault();
                if (ResimURL != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string hizmetname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hakkimizda/" + hizmetname);

                    h.ResimURL = "/Uploads/Hakkimizda/" + hizmetname;
                }
                h.Baslik = hakkimizda.Baslik;
                h.Aciklama = hakkimizda.Aciklama;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Hakkimizdas.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Hakkimizdas.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}