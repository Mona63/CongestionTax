using CongestionTax.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CongestionTax.Infrastructure
{
    public class CongestionTaxDbContext : DbContext
    {
        public DbSet<Toll> Tolls { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
       
        public CongestionTaxDbContext()
        {
        }
        public CongestionTaxDbContext(DbContextOptions<CongestionTaxDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
