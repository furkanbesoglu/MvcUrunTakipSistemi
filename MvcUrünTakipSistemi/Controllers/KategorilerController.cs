using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrünTakipSistemi.Models.Entity;

namespace MvcUrünTakipSistemi.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        public ActionResult Index()
        {
            var ktg = db.Kategoriler.ToList();
            return View(ktg);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEKle(Kategoriler p)
        {
            var ktg = db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Kategoriler.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult Guncelle(Kategoriler p)
        {
            var ktg = db.Kategoriler.Find(p.KategoriID);
            ktg.KategoriAD = p.KategoriAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}