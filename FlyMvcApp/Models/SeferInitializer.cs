using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlyMvcApp.Models
{
    public class SeferInitializer : DropCreateDatabaseIfModelChanges<SeferContext>
    {
        protected override void Seed(SeferContext context)
        {
            List<Sefer> seferler = new List<Sefer>()
            {
                new Sefer() { HavaYolu="Pegasus", Nereden="Ankara",Nereye="Antalya", GidisTarihi="27/09/2020 07:40",Fiyat=89.99,UcusSuresi="1saat20dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul SAW",Nereye="Kayseri", GidisTarihi="27/10/2020 06:20",Fiyat=89.99,UcusSuresi="1saat25dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul SAW",Nereye="Erzincan", GidisTarihi="27/10/2020 11:48",Fiyat=89.99,UcusSuresi="1saat50dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="Antalya", GidisTarihi="27/10/2020 08:25",Fiyat=87.99,UcusSuresi="1saat5dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="SunExpress", Nereden="İstanbul",Nereye="Erzincan", GidisTarihi="27/10/2020 10:40",Fiyat=89.99,UcusSuresi="1saat50dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="Ankara",Nereye="Antalya", GidisTarihi="01/11/2020 06:45",Fiyat=87.99,UcusSuresi="1saat10dk",VarisSaati="07:55",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul SAW",Nereye="Antalya", GidisTarihi="02/11/2020 06:05",Fiyat=87.99,UcusSuresi="1saat20dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul SAW",Nereye="Dalaman", GidisTarihi="02/11/2020 11:48",Fiyat=89.99,UcusSuresi="1saat25dk",VarisSaati="13:15",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul",Nereye="İzmir", GidisTarihi="02/11/2020 08:30",Fiyat=89.99,UcusSuresi="1saat5dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="Erzincan",Nereye="İzmir", GidisTarihi="02/11/2020 08:30",Fiyat=89.99,UcusSuresi="1saat5dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul",Nereye="Antalya", GidisTarihi="07/11/2020 08:45",Fiyat=89.99,UcusSuresi="1saat50dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul",Nereye="Paris", GidisTarihi="17/12/2020 08:20",Fiyat=329.99,UcusSuresi="3saat50dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul",Nereye="Stuttgart", GidisTarihi="08/01/2021 09:45",Fiyat=89.99,UcusSuresi="3saat",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul",Nereye="Amsterdam", GidisTarihi="01/02/2021 08:40",Fiyat=315.15,UcusSuresi="3saat15dk",VarisSaati="13:38",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="İstanbul",Nereye="Ankara", GidisTarihi="05/06/2020 07:15",Fiyat=129.99,UcusSuresi="1saat5dk",VarisSaati="08:25",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul SAW",Nereye="Ankara", GidisTarihi="05/06/2020 11:30",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="12:35",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="SunExpress", Nereden="İstanbul SAW",Nereye="Ankara", GidisTarihi="05/06/2020 21:35",Fiyat=89.99,UcusSuresi="1saat5dk",VarisSaati="22:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul SAW",Nereye="Ankara", GidisTarihi="05/06/2020 15:45",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="16:45",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="İstanbul SAW", GidisTarihi="06/06/2020 09:30",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="10:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="İstanbul SAW", GidisTarihi="06/06/2020 13:45",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="14:30",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="Ankara",Nereye="İstanbul SAW", GidisTarihi="06/06/2020 17:40",Fiyat=129.99,UcusSuresi="1saat5dk",VarisSaati="18:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="SunExpress", Nereden="Ankara",Nereye="İstanbul SAW", GidisTarihi="06/06/2020 21:45",Fiyat=109.99,UcusSuresi="1saat5dk",VarisSaati="22:45",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="Ankara",Nereye="Antalya", GidisTarihi="05/06/2020 07:15",Fiyat=129.99,UcusSuresi="1saat5dk",VarisSaati="08:25",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="Antalya", GidisTarihi="05/06/2020 11:30",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="12:35",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="SunExpress", Nereden="İstanbul SAW",Nereye="Antalya", GidisTarihi="05/06/2020 21:35",Fiyat=89.99,UcusSuresi="1saat5dk",VarisSaati="22:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="İstanbul SAW",Nereye="Antalya", GidisTarihi="05/06/2020 15:45",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="16:45",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="Kayseri", GidisTarihi="06/06/2020 09:30",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="10:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="THY", Nereden="Ankara",Nereye="Kayseri", GidisTarihi="06/06/2020 13:45",Fiyat=112.99,UcusSuresi="1saat5dk",VarisSaati="14:30",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="Pegasus", Nereden="Kayseri",Nereye="Ankara", GidisTarihi="06/06/2020 17:40",Fiyat=129.99,UcusSuresi="1saat5dk",VarisSaati="18:40",BusinessYolcuSayisi=0,EcoYolcuSayisi=100},
                new Sefer() { HavaYolu="SunExpress", Nereden="Kayseri",Nereye="Ankara", GidisTarihi="06/06/2020 21:45",Fiyat=109.99,UcusSuresi="1saat5dk",VarisSaati="22:45",BusinessYolcuSayisi=0,EcoYolcuSayisi=100}
            };

            foreach (var item in seferler)
            {
                context.Seferler.Add(item);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}