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
                                            new VehicleTypeChargeRule(),
                                            new DayFreeChargeRule(),
                                            new TimeFreeChargeRule(),
            };
            var CalculationRules = new List<ICaculationTollRule> { 
                                          new TimeTableChargeRule()
                    };
            _ruleEngine = new RuleEngine(freeChargeRules, CalculationRules);
        }
    }
}
