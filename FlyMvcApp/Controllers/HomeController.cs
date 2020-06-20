using FlyMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private SeferContext context = new SeferContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(context.Seferler.ToList());
        }


        [HttpGet]
        public ActionResult FiltreSonuc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FiltreSonuc(string Nereden, string Nereye, string GidisTarihi, string DonusTarihi, string Sinif)
        {

            string yil = GidisTarihi.Substring(0, 4);
            string Ay = (GidisTarihi.Substring(4, 4)).Remove(0, 0);
            string Ay2 = Ay.Remove(0, 1);
            string Ay3 = Ay2.Substring(0, 2);
            string Gun = GidisTarihi.Substring(5, 5);
            string Gun2 = Gun.Remove(0, 3);
            string GidisTarihi2 = Gun2 + "/" + Ay3 + "/" + yil;
            

            if (DonusTarihi == null)
            {

                SeferContext db = new SeferContext();
                var seferler = db.Seferler.Where(i => i.GidisTarihi.Substring(0, 10) == GidisTarihi2 && i.Nereden == Nereden && i.Nereye == Nereye).ToList();

                return View(seferler);

            }
            else
            {
                string yil2 = DonusTarihi.Substring(0, 4);
                string Ay4 = (DonusTarihi.Substring(4, 4)).Remove(0, 0);
                string Ay5 = Ay4.Remove(0, 1);
                string Ay6 = Ay5.Substring(0, 2);
                string Gun3 = DonusTarihi.Substring(5, 5);
                string Gun4 = Gun3.Remove(0, 3);
                string DonusTarihi2 = Gun4 + "/" + Ay6 + "/" + yil2;
                //string[] tercihler = { Nereden, Nereye, GidisTarihi2, DonusTarihi2, Sinif };
                SeferContext db = new SeferContext();
                var seferler = db.Seferler.Where(i => i.GidisTarihi.Substring(0, 10) == GidisTarihi2 && i.Nereden == Nereden && i.Nereye == Nereye || i.GidisTarihi.Substring(0, 10) == DonusTarihi2 && i.Nereden == Nereye && i.Nereye == Nereden).ToList();
                return View(seferler);

            }
        }

        [HttpGet]
        public ActionResult SonucEkrani()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SonucEkrani(string HavaYolu)
        {

            string[] bolunmus = HavaYolu.Split(',');
            string havaYolu = bolunmus[0];
            string nereden = bolunmus[1];
            string nereye = bolunmus[2];
            string gidisTarihi = bolunmus[3];
            string ucusSuresi = bolunmus[4];
            SeferContext db = new SeferContext();
            var seferler = db.Seferler.Where(i => i.HavaYolu == havaYolu && i.Nereden == nereden && i.Nereye == nereye && i.GidisTarihi == gidisTarihi && i.UcusSuresi == ucusSuresi).ToList();
            return View(seferler);
        }

        public ActionResult SonucEkrani2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SonucEkrani2(string GidisDonus)
        {
            string[] bolunmus = GidisDonus.Split(',');
            return View(bolunmus);
        }

        [HttpPost]
        public ActionResult Bilet(string bilet)
        {
            SeferContext db = new SeferContext();

            string[] biletBolunmus = bilet.Split(',');
            string havaYolu = biletBolunmus[0];
            string nereden = biletBolunmus[1];
            string nereye = biletBolunmus[2];
            string gidisTarihi = biletBolunmus[3];
            string sinif = "Ekonomi";
            var seferGuncel = db.Seferler.Where(i => i.HavaYolu == havaYolu && i.Nereden == nereden && i.Nereye == nereye && i.GidisTarihi == gidisTarihi).FirstOrDefault();

            if (seferGuncel != null)
            {
                if (sinif == "Ekonomi")
                {

                    seferGuncel.EcoYolcuSayisi -= 1;
                    if (seferGuncel.EcoYolcuSayisi == 0)
                    {
                        db.Seferler.Remove(seferGuncel);
                    }
                }
                db.SaveChanges();
            }

            return View(biletBolunmus);
        }

    }
}