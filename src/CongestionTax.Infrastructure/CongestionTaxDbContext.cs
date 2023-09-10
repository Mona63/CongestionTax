using CongestionTax.Core;
using Microsoft.EntityFrameworkCore;

namespace CongestionTax.Infrastructure
{
    public class CongestionTaxDbContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }
        
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
