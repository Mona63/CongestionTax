using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using System.Data;

namespace CongestionTax.Service
{
    public class RuleEngine: IRuleEngine
    {
        readonly IEnumerable<IFreeChargeRule> _freeChargeRules;
        readonly IEnumerable<ICaculationTollRule> _caculationTollRules;

        public RuleEngine(IEnumerable<IFreeChargeRule?> freeChargeRules
                         , IEnumerable<ICaculationTollRule?> caculationTollRules)
        {
            _freeChargeRules=freeChargeRules;
            _caculationTollRules = caculationTollRules;
        }   

        public decimal GetTollAmount(TravelDto travel)
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
