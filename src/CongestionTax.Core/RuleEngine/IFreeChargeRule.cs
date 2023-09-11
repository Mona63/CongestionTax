using CongestionTax.Core.Dtos;

namespace CongestionTax.Core
{
    public interface IFreeChargeRule : ICongestionTaxBaseRule
    {
        public bool CanBeFreeCharge(TravelDto travel);
    }
}
