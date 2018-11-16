using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace demosite.Models
{
    public class demositeContext : DbContext
    {
        public demositeContext (DbContextOptions<demositeContext> options)
            : base(options)
        {
        }

        public DbSet<demosite.Models.Facility> Facility { get; set; }
    }
}
