using CongestionTax.Core;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using CongestionTax.Service;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using System.Linq.Expressions;

namespace CongestionTax.Test
{
    public class DailyMaxChargeRuleTest
    {
        [Test]
        public async Task It_should_return_zero_when_the_total_daily_amount_exceeds_the_max_configured_amount()
        {
            // arrange
            var travelToProcess = new Travel() { TravelAt = DateTime.Now, VehicleId = 1 };
            var tollRepository = Substitute.For<ITollRepository>();
            tollRepository.GetTotalAmount(Arg.Any<Expression<Func<Toll,bool>>>())
                          .Returns(50);
            var dailyMaxChargeRule = new DailyMaxChargeRule(tollRepository,
                                                             Options.Create(new RuleAppSettingsModel() { DailyMaxChargeAmount = 60 }));
            var evaluationResult = new EvalutionResult(true, 20);

            // act
            var actResult = await dailyMaxChargeRule.Evaluate(travelToProcess, evaluationResult);

            // assert
            actResult.Amount.Should().Be(0);
        }
        [Test]
        public async Task It_should_return_the_last_amount_when_the_total_daily_amount_is_less_than_the_max_configured_amount()
        {
            // arrange
            var travelToProcess = new Travel() { TravelAt = DateTime.Now, VehicleId = 1 };
            var tollRepository = Substitute.For<ITollRepository>();
            tollRepository.GetTotalAmount(Arg.Any<Expression<Func<Toll, bool>>>())
                          .Returns(10);
            var dailyMaxChargeRule = new DailyMaxChargeRule(tollRepository,
                                                             Options.Create(new RuleAppSettingsModel() { DailyMaxChargeAmount = 60 }));
            var evaluationResult = new EvalutionResult(true, 20);

            // act
            var actResult = await dailyMaxChargeRule.Evaluate(travelToProcess, evaluationResult);

            // assert
            actResult.Amount.Should().Be(20);
        }
    }
}
