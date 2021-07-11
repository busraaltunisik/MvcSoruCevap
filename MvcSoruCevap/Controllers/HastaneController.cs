using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
namespace MvcSoruCevap.Controllers
{
    [AllowAnonymous]
    public class HastaneController : Controller
    {
        // GET: Hastane
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var degerler = db.TBLDOKTOR.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM i)
        {
            db.TBLILETISIM.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}