using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
using PagedList;
namespace MvcSoruCevap.Controllers
{
    public class DoktorController : Controller
    {
        // GET: Doktor
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index(int sayfa=1)
        {
            var doktor = db.TBLDOKTOR.ToList().ToPagedList(sayfa, 3);
            return View(doktor);
        }
        [HttpGet]
        public ActionResult DoktorEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorEkle(TBLDOKTOR p)
        {
            if (!ModelState.IsValid)
            {
                return View("DoktorEkle");
            }
            db.TBLDOKTOR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoktorSil(int id)
        {
            var sil = db.TBLDOKTOR.Find(id);
            db.TBLDOKTOR.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoktorGetir(int id)
        {
            var gtr = db.TBLDOKTOR.Find(id);
            return View("DoktorGetir", gtr);
        }
        public ActionResult DoktorGuncelle(TBLDOKTOR p)
        {
            var guncelle = db.TBLDOKTOR.Find(p.ID);
            guncelle.AD = p.AD;
            guncelle.SOYAD = p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
