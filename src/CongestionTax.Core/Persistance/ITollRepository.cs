using CongestionTax.Core.Entities;
using System.Linq.Expressions;

namespace CongestionTax.Core
{
    public interface ITollRepository
    {
        Task InsertAsync(Toll entity);
        Task<IEnumerable<Toll>> GetAllAsync(Expression<Func<Toll, bool>> filter);
        Task<decimal> GetTotalAmount(Expression<Func<Toll, bool>> filter);
        Task<decimal> GetMaxAmount(Expression<Func<Toll, bool>> filter);
      
    }
}
