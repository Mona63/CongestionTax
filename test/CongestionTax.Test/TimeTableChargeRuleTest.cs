using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using CongestionTax.Service;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class TimeTableChargeRuleTest
    {
        [Test]
        [TestCaseSource(nameof(TimeTableChargeTest))]
        public async Task It_should_be_charge_according_time_table_charge(DateTime actionAt, decimal tollAmount)
        {
            // arrange
            var travelToProcess = new Travel() {  TravelAt = actionAt };
            var timeTableChargeRule = new TimeTableChargeRule();
            var evaluationResult = new EvalutionResult(true, 0);

            // act
            var actResult =await timeTableChargeRule.Evaluate(travelToProcess, evaluationResult);

            // assert
            actResult.Amount.Should().Be(tollAmount);
        }
        public static object[] TimeTableChargeTest =
        {
            new object[] { new DateTime(2013, 1, 1, 6, 0, 0), 8m },
            new object[] { new DateTime(2013, 1, 1, 6, 30, 0), 13m },
            new object[] { new DateTime(2013, 1, 1, 7, 0, 0), 18m },
            new object[] { new DateTime(2013, 1, 1, 8, 0, 0), 13m },
            new object[] { new DateTime(2013, 1, 1, 8, 30, 0), 8m },
            new object[] { new DateTime(2013, 1, 1, 15, 0, 0), 13m },
            new object[] { new DateTime(2013, 1, 1, 15, 30, 0), 18m },
            new object[] { new DateTime(2013, 1, 1, 19, 30, 0), 0m },
            new object[] { new DateTime(2013, 1, 1, 4, 30, 0), 0m},
        };
    }
}

