using CongestionTax.Core;
using CongestionTax.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CongestionTax.Infrastructure
{
    public class TravelRepository : ITravelRepository
    {
        private readonly CongestionTaxDbContext _context;
        public TravelRepository(CongestionTaxDbContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(Travel entity)
        {
            await _context.Travels.AddAsync(entity);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<Travel>> GetAllAsync(Expression<Func<Travel, bool>> filter)
        {
            var travels = await _context.Travels.Where(filter).ToListAsync();
            return travels;
        }

       

    }

}
