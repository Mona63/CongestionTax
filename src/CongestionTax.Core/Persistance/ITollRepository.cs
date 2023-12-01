using CongestionTax.Core.Entities;
using System.Linq.Expressions;

namespace CongestionTax.Core
{
    public interface ITollRepository
    {
        Task InsertAsync(Toll entity);
      
        Task<IEnumerable<Toll>> GetAllAsync(Expression<Func<Toll, bool>> filter);
        IEnumerable<TResult> GetGrouped<TKey, TResult>(
                                   Expression<Func<Toll, TKey>> groupingKey,
                                   Expression<Func<IGrouping<TKey, Toll>, TResult>> resultSelector,
                                   Expression<Func<Toll, bool>>? filter = null);
        
    }
}
