using CongestionTax.Core;
using CongestionTax.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CongestionTax.Infrastructure
{
    public class TollRepository : ITollRepository
    {
        private readonly CongestionTaxDbContext _context;
        public TollRepository(CongestionTaxDbContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(Toll entity)
        {
            await _context.Tolls.AddAsync(entity);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<Toll>> GetAllAsync(Expression<Func<Toll, bool>> filter)
        {
            return await _context.Tolls.Where(filter).ToListAsync();   
        }
        public  Task<decimal> GetTotalAmount(Expression<Func<Toll, bool>> filter)
        {
            return _context.Tolls.Where(filter).SumAsync(t => t.Amount);
            
        }
        public Task<decimal> GetMaxAmount(Expression<Func<Toll, bool>> filter)
        {
            return _context.Tolls.Where(filter).MaxAsync(t => t.Amount);

        }
        
    }

}
