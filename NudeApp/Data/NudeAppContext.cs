using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NudeApp.Models;

namespace NudeApp.Data
{
    public class NudeAppContext : DbContext
    {
        public NudeAppContext (DbContextOptions<NudeAppContext> options)
            : base(options)
        {
        }

        public DbSet<NudeApp.Models.HighValueItem> HighValueItem { get; set; }
    }
}
