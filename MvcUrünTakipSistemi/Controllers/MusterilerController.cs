using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrünTakipSistemi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcUrünTakipSistemi.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var musteriListesi = db.Musteriler.Where(m => m.Durum == true).ToList().ToPagedList(sayfa, 3);
            return View(musteriListesi);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteriler m)
        {
            if (ModelState.IsValid)
            {
                m.Durum = true;
                var mustr = db.Musteriler.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("MusteriEkle");
            }
            
        }
        public ActionResult MusteriSil(int id)
        {
            var musteriler = db.Musteriler.Find(id);
            musteriler.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteriBul = db.Musteriler.Find(id);
            return View("MusteriGetir", musteriBul);
        }
        public ActionResult Guncelle(Musteriler m)
        {
            var mstr = db.Musteriler.Find(m.MusteriID);
            mstr.MusteriAD = m.MusteriAD;
            mstr.MusteriSoyad = m.MusteriSoyad;
            mstr.Sehir = m.Sehir;
            mstr.Bakiye = m.Bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}