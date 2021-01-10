using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrünTakipSistemi.Models.Entity;

namespace MvcUrünTakipSistemi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin p)
        {
            db.Admin.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}