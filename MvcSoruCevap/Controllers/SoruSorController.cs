using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
    public class SoruSorController : Controller
    {
        // GET: SoruSor
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index()
        {
            var kullanici = db.TBLSORU.ToList();
            return View(kullanici);
        }
        public ActionResult Index2()
        {
            var kullanici = db.TBLSORU.ToList();
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult YeniSoru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSoru(TBLSORU d)
        {
            db.TBLSORU.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult SoruSil(int id)
        {
            var sor = db.TBLSORU.Find(id);
            db.TBLSORU.Remove(sor);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult SoruGuncelle(int id)
        {
            var sor = db.TBLSORU.Find(id);
            return View("SoruGuncelle", sor);
        }
        [HttpPost]
        public ActionResult SoruGuncelle(TBLSORU d)
        {
            var sor = db.TBLSORU.Find(d.ID);
            sor.BASLIK = d.BASLIK;
            sor.ICERIK = d.ICERIK;
            sor.EKLEMETARIHI = d.EKLEMETARIHI;
            sor.DUZENLEMETARIHI = d.DUZENLEMETARIHI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}