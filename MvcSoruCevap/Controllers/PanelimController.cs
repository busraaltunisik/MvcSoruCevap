using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcSoruCevap.Models.Entity;
namespace MvcSoruCevap.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        // GET: Panelim
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var hastamail = (string)Session["Mail"];
            //var degerler = db.TBLUYEHASTA.FirstOrDefault(h => h.MAIL == hastamail);
            var degerler = db.TBLDUYURU.ToList();
            var h1 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.AD).FirstOrDefault();
            ViewBag.h1 = h1;
            var h2 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.h2 = h2;
            var h3 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.h3 = h3;
            var h4 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.h4 = h4;
            var h5 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.HASTALIK).FirstOrDefault();
            ViewBag.h5 = h5;
            var h6 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.h6 = h6;
            var h7 = db.TBLUYEHASTA.Where(x => x.MAIL == hastamail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.h7 = h7;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYEHASTA p)
        {
            var hasta = (string)Session["Mail"];
            var uye = db.TBLUYEHASTA.FirstOrDefault(x => x.MAIL == hasta);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.HASTALIK = p.HASTALIK;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sorularim()
        {
            var hasta = (string)Session["Mail"];
            var id = db.TBLUYEHASTA.Where(x => x.MAIL == hasta.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLSORU.Where(x => x.HASTA == id).ToList();
            return View(degerler);
            
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURU.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();   
            return RedirectToAction("GirisYap","Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYEHASTA.Where(x => x.MAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLUYEHASTA.Find(id);
            return PartialView("Partial2",uyebul);
        }
    }
}