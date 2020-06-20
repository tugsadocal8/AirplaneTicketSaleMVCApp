using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyMvcApp.Models
{
    public class Sefer
    {
        public int Id { get; set; }
        public string HavaYolu { get; set; }

        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public string GidisTarihi { get; set; }
       
        public double Fiyat { get; set; }
        public string UcusSuresi { get; set; }

        public string VarisSaati { get; set; }

        public int BusinessYolcuSayisi { get; set; }
        public int EcoYolcuSayisi { get; set; }
        
    }
}