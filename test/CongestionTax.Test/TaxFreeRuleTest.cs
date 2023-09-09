using CongestionTax.RuleEngine;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class TaxFreeRuleTest
    {
        private RuleEngine.RuleEngine _ruleEngine;


        [SetUp]
        public void Setup()
        {

            var rules = new List<CongestionTaxBaseRule> {
                new VehichleTypeRule(1)
            };

            _ruleEngine = new RuleEngine.RuleEngine(rules);
        }

        [Test]
        public async Task It_should_be__tax_free_for_except_vehichle()
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = VehicleType.Motorcycle, ActionAt = DateTime.Now };

            // act
            var taxFee = _ruleEngine.GetCongestionTaxFee(travelToProcess);

            // assert
            taxFee.Should().Be(0);
        }


    }
}