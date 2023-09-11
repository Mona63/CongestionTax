using CongestionTax.Core.Dtos;

namespace CongestionTax.Core
{
    public interface ICaculationTollRule : ICongestionTaxBaseRule
    {
        public decimal CalculationToll(TravelDto travel);
    }
}
