using CongestionTax.Core.Entities;

namespace CongestionTax.Core
{
    public interface ITollRepository
    {
        Task InsertAsync(Toll entity);
        Task UpdateAsync(Toll entity);
        Task<IEnumerable<Toll>> GetAllAsync();
        Task<Toll> GetByIdAsync(int id);
    }
}
