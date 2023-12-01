using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Service;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class CalculationTollRuleTest
    {


        [Test]
        [TestCaseSource(nameof(TimeTableChargeTest))]
        public void It_should_be_charge_according_time_table_charge(DateTime actionAt, decimal toll)
        {
            // arrange
            var travelToProcess = new TravelDto {  TravelAt = actionAt };
            var timeTableChargeRule = new TimeTableChargeRule();

            // act
            var actToll = timeTableChargeRule.CalculationToll(travelToProcess);

            // assert
            actToll.Should().Be(toll);
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

        };
    }
}