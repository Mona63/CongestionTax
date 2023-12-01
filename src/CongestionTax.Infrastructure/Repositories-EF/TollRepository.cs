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
            var tolls = await _context.Tolls.Where(filter).ToListAsync();
            return tolls;
        }
        public IEnumerable<TResult> GetGrouped<TKey, TResult>(Expression<Func<Toll, TKey>> groupingKey,
                                                              Expression<Func<IGrouping<TKey, Toll>, TResult>> resultSelector,
                                                              Expression<Func<Toll, bool>>? filter = null)

        {
            var query = _context.Tolls.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.GroupBy(groupingKey).Select(resultSelector);
        }

    }

}
