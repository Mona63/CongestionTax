using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Core
{
    public interface ITravelRepository
    {
        Task InsertAsync(Travel entity);
        Task UpdateAsync(Travel entity);
        Task<IEnumerable<Travel>> GetAllAsync();
        Task<Travel> GetByIdAsync(int id);
    }
}
