using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace CongestionTax.RuleEngine
{
    public class RuleEngine
    {
        List<ITaxFreeRule> _taxFreeRules = new();
        List<ITaxCaculationRule> _taxCalculationRules = new();

        public RuleEngine(IEnumerable<ITaxFreeRule?> taxFreeRules
                         ,IEnumerable<ITaxCaculationRule?> taxCalculationRules)
        {
            _taxFreeRules.AddRange(taxFreeRules);
            _taxCalculationRules.AddRange(taxCalculationRules);
        }

        public decimal GetCongestionTaxAmount(Travel travel)
        {
            decimal taxAmount = 0;
            var taxFreeRule = _taxFreeRules.OrderBy(r => r.Proiority)
                                           .FirstOrDefault(r => r.IsApplicable(travel));

            if (taxFreeRule != null) { return 0; }

            taxAmount = _taxCalculationRules.Aggregate(0m,(current, r) => Math.Max(current,r.GetTaxAmount(travel,current)));
           
            return taxAmount;
        }
    }
}
