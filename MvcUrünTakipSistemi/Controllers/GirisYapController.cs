using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcUrünTakipSistemi.Models.Entity;

namespace MvcUrünTakipSistemi.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Admin t)
        {
            var bilgiler = db.Admin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteriler");
            }
            else
            {
                return View();
            }


        }
        
         
    }
}