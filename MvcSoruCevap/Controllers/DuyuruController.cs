using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURU.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURU d)
        {
            db.TBLDUYURU.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            db.TBLDUYURU.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBLDUYURU p)
        {
            var duyuru = db.TBLDUYURU.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURU g)
        {
            var duyuru = db.TBLDUYURU.Find(g.ID);
            duyuru.KATEGORI = g.KATEGORI;
            duyuru.ICERIK = g.ICERIK;
            duyuru.TARIH = g.TARIH;
            db.SaveChanges();
            return RedirectToAction ("Index");
        }
    }
}