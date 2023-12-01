using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;

namespace CongestionTax.Service
{
    public interface IRuleEngine
    {
        Task<decimal> Run(Travel travel);
    }
}
