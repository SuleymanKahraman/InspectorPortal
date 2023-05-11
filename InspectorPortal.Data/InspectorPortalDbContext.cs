using InspectorPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data
{
    //DbContext sınıfından inherit edilmiş InspectorPortalDbContext class'ı farklı bir Library projede açılır. Katmanlı mimari tasarımına uygun olması için böyle yapılır. 
    public class InspectorPortalDbContext : DbContext
    {
        public InspectorPortalDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Mufettis> Mufettisler { get; set; }
        public DbSet<Gorev> Gorevler { get; set; } 
        public DbSet<UniteBirim> UniteBirimler { get; set; } 
        public DbSet<IdariTedbir> IdariTedbirler { get; set; } 
        public DbSet<HukukiIslem> HukukiIslemler { get; set; } 
        public DbSet<DisiplinCezasi> DisiplinCezalari { get; set; } 
        public DbSet<MufettisGorev> MufettisGorevler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

    }
}
