namespace CongestionTax.RuleEngine
{
    public interface IFreeChargeRule : ICongestionTaxBaseRule
    {
        public bool CanBeFreeCharge(Travel travel);
    }
}
