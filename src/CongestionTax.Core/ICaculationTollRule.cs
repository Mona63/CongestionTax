namespace CongestionTax.Core
{
    public interface ICaculationTollRule : ICongestionTaxBaseRule
    {
        public decimal CalculationToll(Travel travel);
    }
}
