namespace CongestionTax.RuleEngine
{
    public interface ICaculationTollRule : ICongestionTaxBaseRule
    {
        public decimal CalculationToll(Travel travel);
    }
}
