using InspectorPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data
{
    public class InspectorPortalDbContext : DbContext
    {
        public InspectorPortalDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
