using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesaj = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(mesaj);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesaj = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.GONDEREN = uyemail.ToString();
            m.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(m);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesaj");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}