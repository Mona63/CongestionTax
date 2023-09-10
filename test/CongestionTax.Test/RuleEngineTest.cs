using CongestionTax.Core;
using CongestionTax.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Test
{
    public class RuleEngineTest
    {
        private RuleEngine.RuleEngine _ruleEngine;

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
            _ruleEngine = new RuleEngine.RuleEngine(freeChargeRules, CalculationRules);
        }
    }
}
