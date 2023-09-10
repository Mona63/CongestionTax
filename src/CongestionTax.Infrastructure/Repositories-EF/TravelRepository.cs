using CongestionTax.Core;
using Microsoft.EntityFrameworkCore;

namespace CongestionTax.Infrastructure
{
    public class TravelRepository : ITravelRepository
    {
        private readonly CongestionTaxDbContext _context;
        public TravelRepository(CongestionTaxDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Travel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Travel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Travel entity)
        {
            await _context.Travels.AddAsync(entity);
        }

        public Task UpdateAsync(Travel entity)
        {
            throw new NotImplementedException();
        }
    }

}
