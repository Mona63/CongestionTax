using CongestionTax.Core.Entities;
using System.Linq.Expressions;

namespace CongestionTax.Core
{
    public interface ITollRepository
    {
        Task InsertAsync(Toll entity);
        Task UpdateAsync(Toll entity);
        Task BulkUpdateAsync(Expression<Func<Toll, bool>> filter,
                                          Func<Toll, object> property,
                                          Func<Toll, object> value);

        Task<List<Toll>> GetAllAsync(Expression<Func<Toll, bool>> filter);
        IEnumerable<TResult> GetGrouped<TKey, TResult>(
                                   Expression<Func<Toll, TKey>> groupingKey,
                                   Expression<Func<IGrouping<TKey, Toll>, TResult>> resultSelector,
                                   Expression<Func<Toll, bool>>? filter = null);
        Task<Toll> GetByIdAsync(int id);


    }
}
