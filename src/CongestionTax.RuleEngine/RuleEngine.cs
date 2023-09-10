using CongestionTax.Core;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace CongestionTax.RuleEngine
{
    public class RuleEngine
    {
        readonly List<IFreeChargeRule> _freeChargeRules = new();
        readonly List<ICaculationTollRule> _caculationTollRules = new();

        public RuleEngine(IEnumerable<IFreeChargeRule?> freeChargeRules
                         , IEnumerable<ICaculationTollRule?> caculationTollRules)
        {
            _freeChargeRules.AddRange(freeChargeRules);
            _caculationTollRules.AddRange(caculationTollRules);
        }

        public decimal GetToll(Travel travel)
        {
            decimal toll = 0;
            var freeChargeRule = _freeChargeRules.OrderBy(r => r.Proiority)
                                                 .FirstOrDefault(r => r.CanBeFreeCharge(travel));

            if (freeChargeRule != null) { return 0; }

            toll = _caculationTollRules.Aggregate(0m, (total, rule) => (rule.CalculationToll(travel)) + total);
           
            return toll;
        }
    }
}
