using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoolsDevApp.Models
{
    public class GoolsDevContext : DbContext
    {
        public GoolsDevContext(DbContextOptions<GoolsDevContext> options) : base(options)
        {
        }
        public DbSet<Thingy> Thingies { get; set; }
    }
}
