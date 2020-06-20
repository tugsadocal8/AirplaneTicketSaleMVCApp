using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlyMvcApp.Models
{
    public class SeferContext:DbContext
    {
        public SeferContext()
        {
            Database.SetInitializer(new SeferInitializer());
        }
        public DbSet<Sefer> Seferler { get; set; }
    }
}