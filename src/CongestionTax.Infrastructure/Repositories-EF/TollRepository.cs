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

        }

        public Task UpdateAsync(Toll entity)
        {
            throw new NotImplementedException();
        }
        public async Task BulkUpdateAsync(Expression<Func<Toll, bool>> filter,
                                                     Func<Toll, object> property,
                                                     Func<Toll, object> value)
        {
            await _context.Tolls.Where(filter).ExecuteUpdateAsync(setters => setters.SetProperty(property, value));

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
        public async Task<List<Toll>> GetAllAsync(Expression<Func<Toll, bool>> filter)
        {
            var query = await _context.Tolls.Where(filter).ToListAsync();
            return query;
        }
        public Task<Toll> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


    }

}
