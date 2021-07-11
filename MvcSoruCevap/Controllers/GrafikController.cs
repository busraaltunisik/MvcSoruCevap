using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models;

namespace MvcSoruCevap.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKtgResualt()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                KATEGORI = "Bel Ağrısı",
                sayi = 3
            });
            cs.Add(new Class1()
            {
                KATEGORI = "Baş Ağrısı",
                sayi = 10
            });
            cs.Add(new Class1()
            {
                KATEGORI = "Kalp Ağrısı",
                sayi = 6
            });
            return cs;
        }
    }
}