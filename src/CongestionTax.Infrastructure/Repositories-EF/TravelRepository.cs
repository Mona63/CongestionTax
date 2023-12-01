using CongestionTax.Core;
using CongestionTax.Core.Entities;

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

        }

    }

}
