using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrünTakipSistemi.Models.Entity;

namespace MvcUrünTakipSistemi.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcUrunnTakipSistemiEntities db = new MvcUrunnTakipSistemiEntities();
        public ActionResult Index(string p)
        {
            //var urn = db.Urunler.Where(x => x.Durum == true).ToList();
            //Arama İşlemi
            var urunler = db.Urunler.Where(x => x.Durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.UrunAD.Contains(p) && x.Durum == true);
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from u in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = u.KategoriAD,
                                               Value = u.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler u)
        {
            var ktg = db.Kategoriler.Where(x => x.KategoriID == u.KategoriID).FirstOrDefault();
            u.Kategoriler = ktg;
            var urn = db.Urunler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.Urunler.Find(id);
            List<SelectListItem> deger1 = (from u in db.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = u.KategoriAD,
                                               Value = u.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger1;
            return View("UrunGetir", urn);
        }
        public ActionResult Guncelle(Urunler u)
        {
            var urn = db.Urunler.Find(u.UrunID);
            urn.UrunAD = u.UrunAD;
            urn.Marka = u.Marka;
            urn.Stok = u.Stok;
            urn.AlisFiyat = u.AlisFiyat;
            urn.SatisFiyat = u.SatisFiyat;
            var ktg = db.Kategoriler.Where(k => k.KategoriID == u.Kategoriler.KategoriID).FirstOrDefault();
            urn.Kategoriler = ktg;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urunbul = db.Urunler.Find(id);
            urunbul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}