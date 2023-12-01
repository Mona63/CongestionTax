using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using CongestionTax.Service;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class VehicleTypeChargeRuleTest
    {
        [Test]
        [TestCase(VehicleType.Motorcycle)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Tractor)]
        [TestCase(VehicleType.Military)]
        public async Task It_should_be_free_for_except_vehichle(VehicleType vehicleType)
        {
            // arrange
            var travelToProcess = new Travel {Vehicle=new Vehicle() { VehicleType = vehicleType }, TravelAt = DateTime.Now };
            var vehichleTypeRule = new VehicleTypeChargeRule();
            var evaluationResult = new EvalutionResult(true, 0);

            // act
            var actResult = await vehichleTypeRule.Evaluate(travelToProcess, evaluationResult);

            // assert
            actResult.Amount.Should().Be(0);
        }
       
       
    }
}