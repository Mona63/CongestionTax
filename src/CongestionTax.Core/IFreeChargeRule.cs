namespace CongestionTax.Core
{
    public interface IFreeChargeRule : ICongestionTaxBaseRule
    {
        public bool CanBeFreeCharge(Travel travel);
    }
}
