using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcSoruCevap.Models.Entity;

namespace MvcSoruCevap.Controllers
{
  
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLDOKTOR d)
        {
            var bilgiler = db.TBLDOKTOR.FirstOrDefault(x => x.MAIL == d.MAIL && x.SIFRE == d.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Kullanici"] = bilgiler.MAIL.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
           
        }
    }
}