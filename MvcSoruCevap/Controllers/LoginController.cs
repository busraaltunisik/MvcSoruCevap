using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSoruCevap.Models.Entity;
using System.Web.Security;

namespace MvcSoruCevap.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        SORUCEVAPEntities db = new SORUCEVAPEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYEHASTA p)
        {
            var bilgiler = db.TBLUYEHASTA.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();  
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}