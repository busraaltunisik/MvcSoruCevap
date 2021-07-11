using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
using PagedList;
namespace MvcSoruCevap.Controllers
{
    public class SoruController : Controller
    {
        // GET: Soru
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLSORU.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SoruEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLUYEHASTA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult SoruEkle(TBLSORU p)
        {
            db.TBLSORU.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SoruSil(int id)
        {
            var sil = db.TBLSORU.Find(id);
            db.TBLSORU.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SoruGetir(int id)
        {
            var gtr = db.TBLSORU.Find(id);
            return View("SoruGetir", gtr);
        }
        public ActionResult SoruGuncelle(TBLSORU p)
        {
            var guncelle = db.TBLSORU.Find(p.ID);
            guncelle.BASLIK = p.BASLIK;
            guncelle.ICERIK = p.ICERIK;
            guncelle.KATEGORI = p.KATEGORI;
            var hasta = db.TBLUYEHASTA.Where(h => h.ID == p.TBLUYEHASTA.ID).FirstOrDefault();
            guncelle.EKLEMETARIHI = p.EKLEMETARIHI;
            guncelle.DUZENLEMETARIHI = p.DUZENLEMETARIHI;
            guncelle.DURUM = p.DURUM;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}