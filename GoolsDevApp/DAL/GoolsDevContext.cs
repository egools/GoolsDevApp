using GoolsDevApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoolsDevApp.DAL
{
    public class GoolsDevContext : DbContext
    {
        public GoolsDevContext(DbContextOptions<GoolsDevContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Testing");
            modelBuilder.Entity<Thingy>().Property(s => s.ThingyId).ValueGeneratedOnAdd();
        }

        public DbSet<Thingy> Thingies { get; set; }
    }
}
