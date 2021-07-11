using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index()
        {
            var kullanici = db.TBLDOKTOR.ToList();
            return View(kullanici);
        }
        public ActionResult Index2()
        {
            var kullanici = db.TBLDOKTOR.ToList();
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult YeniDoktor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDoktor(TBLDOKTOR d)
        {
            db.TBLDOKTOR.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult DoktorSil(int id)
        {
            var doktor = db.TBLDOKTOR.Find(id);
            db.TBLDOKTOR.Remove(doktor);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult DoktorGuncelle(int id)
        {
            var doktor = db.TBLDOKTOR.Find(id);
            return View("DoktorGuncelle",doktor);
        }
        [HttpPost]
        public ActionResult DoktorGuncelle(TBLDOKTOR d)
        {
            var doktor = db.TBLDOKTOR.Find(d.ID);
            doktor.KULLANICIADI = d.KULLANICIADI;
            doktor.SIFRE = d.SIFRE;
            doktor.YETKI = d.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}