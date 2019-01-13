using aspnet_mvc_ef_codefirst.Models;
using aspnet_mvc_ef_codefirst.Models.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc_ef_codefirst.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();
            List<Kisiler> kisiler = db.Kisiler.ToList();

            List<SelectListItem> kisilerList = new List<SelectListItem>();
            foreach( Kisiler kisi in kisiler)
            {
                SelectListItem item = new SelectListItem();
                item.Text = kisi.Ad + " " + kisi.Soyad;
                item.Value = kisi.ID.ToString();
                kisilerList.Add(item);
            }
            TempData["kisiler"] = kisilerList;
            ViewBag.kisiler = kisilerList;
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Adresler adres)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == adres.Kisi.ID).FirstOrDefault();
            if(kisi != null)
            {
                adres.Kisi = kisi;
                db.Adresler.Add(adres);
                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Adres kaydedilmiştir";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Adres kaydedilememiştir";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }

        public ActionResult Duzenle(int? adresid)
        {
            Adresler adres = null;
            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                List<Kisiler> kisiler = db.Kisiler.ToList();

                List<SelectListItem> kisilerList = new List<SelectListItem>();
                foreach (Kisiler kisi in kisiler)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = kisi.Ad + " " + kisi.Soyad;
                    item.Value = kisi.ID.ToString();
                    kisilerList.Add(item);
                }
                TempData["kisiler"] = kisilerList;
                ViewBag.kisiler = kisilerList;
                adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            }
            return View(adres);
        }
        [HttpPost]
        public ActionResult Duzenle (Adresler model, int? adresid)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == model.Kisi.ID).FirstOrDefault();
            Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            if (kisi != null)
            {
                adres.Kisi = kisi;
                adres.AdresTanim = model.AdresTanim;
                
                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Adres Güncellenmiştir";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Adres Güncellenmemiştir";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }

        public ActionResult Sil(int? adresid)
        {
            Adresler adres = null;
            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            }
            return View(adres);
        }
        [HttpPost, ActionName("Sil")]
        public ActionResult SilDone(int? adresid)
        {

            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();

                db.Adresler.Remove(adres);
                db.SaveChanges();

            }
            return RedirectToAction("homepage", "Home");
        }

    }
}