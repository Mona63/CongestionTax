using CongestionTax.Core.Entities;
using System.Linq.Expressions;

namespace CongestionTax.Core
{
    public interface ITravelRepository
    {
        Task InsertAsync(Travel entity);
       
    }
}
