using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcSoruCevap.Controllers
{
    public class HastaController : Controller
    {
        // GET: Hasta
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index(int sayfa=1)
        {
            var hasta = db.TBLUYEHASTA.ToList().ToPagedList(sayfa, 3);
            return View(hasta);
        }
        [HttpGet]
        public ActionResult HastaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaEkle(TBLUYEHASTA p)
        {
            if (!ModelState.IsValid)
            {
                return View("HastaEkle");
            }
            db.TBLUYEHASTA.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult HastaSil(int id)
        {
            var hst = db.TBLUYEHASTA.Find(id);
            db.TBLUYEHASTA.Remove(hst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaGetir(int id)
        {
            var get = db.TBLUYEHASTA.Find(id);
            return View("HastaGetir", get);
        }
        public ActionResult HastaGuncelle(TBLUYEHASTA p)
        {
            var guncelle = db.TBLUYEHASTA.Find(p.ID);
            guncelle.AD = p.AD;
            guncelle.SOYAD = p.SOYAD;
            guncelle.MAIL = p.MAIL;
            guncelle.KULLANICIADI = p.KULLANICIADI;
            guncelle.SIFRE = p.SIFRE;
            guncelle.FOTOGRAF = p.FOTOGRAF;
            guncelle.TELEFON = p.TELEFON;
            guncelle.HASTALIK = p.HASTALIK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}