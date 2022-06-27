using Microsoft.EntityFrameworkCore;
using NudeApp.Models;

namespace NudeApp.Data
{
    public class NudeAppContext : DbContext
    {
        public NudeAppContext(DbContextOptions options) : base(options) { }

        public DbSet<HighValueItem> HighValueItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new HighValueItemConfiguration());
        }
    }
}
