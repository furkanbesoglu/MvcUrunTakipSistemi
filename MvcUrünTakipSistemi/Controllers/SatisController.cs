using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrünTakipSistemi.Models.Entity;

namespace MvcUrünTakipSistemi.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        public ActionResult Index()
        {
            var satislar = db.Satislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> deger = (from x in db.Urunler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAD,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            //Personel
            List<SelectListItem> deger1 = (from p in db.Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = p.PersonelAD + " " + p.PersonelSoyad,
                                               Value = p.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            //Müşteri
            List<SelectListItem> deger2 = (from m in db.Musteriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = m.MusteriAD + " " + m.MusteriSoyad,
                                               Value = m.MusteriID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Satislar s)
        {
            var urn = db.Urunler.Where(u => u.UrunID == s.Urunler.UrunID).FirstOrDefault();
            var pers = db.Personel.Where(p => p.PersonelID == s.Personel.PersonelID).FirstOrDefault();
            var mstr = db.Musteriler.Where(m => m.MusteriID == s.Musteriler.MusteriID).FirstOrDefault();
            s.Urunler = urn;
            s.Personel = pers;
            s.Musteriler = mstr;
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Satislar.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}