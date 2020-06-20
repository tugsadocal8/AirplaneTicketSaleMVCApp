using FlyMvcApp.Identity;
using FlyMvcApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyMvcApp.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View(userManager.Users);
        }

        [HttpGet]
        public ActionResult SeferEkle()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Seferler()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Seferler(string HavaYolu, string Nereden, string Nereye, string GidisTarihi, double Fiyat, string ucusSuresi, string varisSaati, int busYolcu, int ecoYolcu)
        {
            SeferContext db = new SeferContext();

            Sefer yeniSefer = new Sefer();

            yeniSefer.HavaYolu = HavaYolu;
            yeniSefer.Nereden = Nereden;
            yeniSefer.Nereye = Nereye;
            yeniSefer.GidisTarihi = GidisTarihi;
            yeniSefer.Fiyat = Fiyat;
            yeniSefer.UcusSuresi = ucusSuresi;
            yeniSefer.VarisSaati = varisSaati;
            yeniSefer.BusinessYolcuSayisi = busYolcu;
            yeniSefer.EcoYolcuSayisi = ecoYolcu;

            db.Seferler.Add(yeniSefer);
            db.SaveChanges();

            var seferler = db.Seferler.ToList();

            return View(seferler);

        }
        [HttpGet]
        public ActionResult MevcutSeferler()
        {
            SeferContext db = new SeferContext();

            var seferler = db.Seferler.ToList();
            return View(seferler);

        }
        [HttpPost]
        public ActionResult MevcutSeferler(string sil)
        {
            string[] bolunmus = sil.Split(',');

            string havaYolu = bolunmus[0];
            string nereden = bolunmus[1];
            string nereye = bolunmus[2];
            string gidisTarihi = bolunmus[3];

            SeferContext db = new SeferContext();
            var sefer = db.Seferler.Where(i => i.HavaYolu == havaYolu && i.Nereden == nereden && i.Nereye == nereye && i.GidisTarihi == gidisTarihi).FirstOrDefault();

            if (sefer != null)
            {
                db.Seferler.Remove(sefer);
            }
            db.SaveChanges();
            var seferler = db.Seferler.ToList();
            return View(seferler);

        }
    }
}