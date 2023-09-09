using System.Data;

namespace CongestionTax.RuleEngine
{
    public class RuleEngine
    {
        List<CongestionTaxBaseRule> _rules = new();

        public RuleEngine(IEnumerable<CongestionTaxBaseRule?> rules)
        {
            _rules.AddRange(rules);
        }

        public decimal GetCongestionTaxFee(Travel travel)
        {
            decimal taxFee = 0;
            var applicapleRule = _rules.OrderBy(r => r.Proiority)
                                        .FirstOrDefault(r => r.IsApplicable(travel));

            if (applicapleRule != null) { taxFee = applicapleRule.GetTaxFee(); }

            return taxFee;
        }
    }
}
