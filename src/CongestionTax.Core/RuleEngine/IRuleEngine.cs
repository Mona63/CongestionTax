using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public interface IRuleEngine
    {
        decimal GetTollAmount(TravelDto travel);
    }
}
