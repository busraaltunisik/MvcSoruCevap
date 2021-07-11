using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
using PagedList;
namespace MvcSoruCevap.Controllers

{
    public class CevapController : Controller
    {
        // GET: Cevap
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLCEVAP.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CevapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLSORU.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ICERIK,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLDOKTOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult CevapEkle(TBLCEVAP p)
        {
            db.TBLCEVAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CevapSil(int id)
        {
            var sil = db.TBLCEVAP.Find(id);
            db.TBLCEVAP.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CevapGetir(int id)
        {
            var gtr = db.TBLCEVAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLSORU.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ICERIK,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLDOKTOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("CevapGetir", gtr);
        }
        public ActionResult CevapGuncelle(TBLCEVAP p)
        {
            var guncelle = db.TBLCEVAP.Find(p.ID);
            guncelle.ID = p.ID;
            guncelle.CEVAP = p.CEVAP;
            guncelle.EKLENMETARIHI = p.EKLENMETARIHI;
            guncelle.DUZENLEMETARIHI = p.DUZENLEMETARIHI;
            var soru = db.TBLSORU.Where(s => s.ID == p.TBLSORU.ID).FirstOrDefault();
            var dkt = db.TBLDOKTOR.Where(d => d.ID == p.TBLDOKTOR.ID).FirstOrDefault();
            guncelle.SORU = soru.ID;
            guncelle.DOKTOR = dkt.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}