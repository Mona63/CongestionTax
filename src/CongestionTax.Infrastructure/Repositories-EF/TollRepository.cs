using CongestionTax.Core;
using CongestionTax.Core.Entities;
using System.Diagnostics;

namespace CongestionTax.Infrastructure
{
    public class TollRepository : ITollRepository
    {
        private readonly CongestionTaxDbContext _context;
        public TollRepository(CongestionTaxDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Toll>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Toll> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Toll entity)
        {
            await _context.Tolls.AddAsync(entity);
        }

        public Task UpdateAsync(Toll entity)
        {
            throw new NotImplementedException();
        }
    }

}
