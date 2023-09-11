using CongestionTax.Core;
using CongestionTax.Service;

namespace CongestionTax.Test
{
    public class RuleEngineTest
    {
        private RuleEngine _ruleEngine;

        [SetUp]
        public void Setup()
        {

            var freeChargeRules = new List<IFreeChargeRule> {
                                            new VehichleTypeRule {Proiority=1},
                                            new DaysRule(){Proiority=2},
                                            new TimeFreeChargeRule(){Proiority=3},
            };
            var CalculationRules = new List<ICaculationTollRule> { 
                                          new TimeTableChargeRule()
                    };
            _ruleEngine = new RuleEngine(freeChargeRules, CalculationRules);
        }
    }
}
