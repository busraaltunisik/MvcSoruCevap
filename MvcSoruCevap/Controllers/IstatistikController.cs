using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index()
        {
            var doktor = db.TBLDOKTOR.Count();
            var hasta = db.TBLUYEHASTA.Count();
            var soru = db.TBLSORU.Count();
            var cevap = db.TBLCEVAP.Count();
            ViewBag.dkt = doktor;
            ViewBag.hst = hasta;
            ViewBag.sor = soru;
            ViewBag.cvp = cevap;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/galeri"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var kategori = db.TBLKATEGORI.Count();
            var doktor = db.TBLDOKTOR.Count();
            var hasta = db.TBLUYEHASTA.Count();
            var soru = db.TBLSORU.Count();
            var cevap = db.TBLCEVAP.Count();
            var iletisim = db.TBLILETISIM.Count();
            var aktifh = db.EnAktifHasta().FirstOrDefault();
            var aktifd = db.EnAktifDoktor().FirstOrDefault();
            var ensoru = db.EnSıkSoru().FirstOrDefault();

            ViewBag.ilt = iletisim;
            ViewBag.ktg = kategori;
            ViewBag.dkt = doktor;
            ViewBag.hst = hasta;
            ViewBag.sor = soru;
            ViewBag.cvp = cevap;
            ViewBag.ah = aktifh;
            ViewBag.ad = aktifd;
            ViewBag.ensor = ensoru;
            return View();
        }
    }
}