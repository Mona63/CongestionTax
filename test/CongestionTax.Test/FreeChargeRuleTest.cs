using CongestionTax.RuleEngine;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class FreeChargeRuleTest
    {
        [Test]
        [TestCase(VehicleType.Motorcycle)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Tractor)]
        [TestCase(VehicleType.Military)]
        public void It_should_be_free_for_except_vehichle(VehicleType vehicleType)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = vehicleType, ActionAt = DateTime.Now };
            var vehichleTypeRule = new VehichleTypeRule();

            // act
            var vehichleTypeRuleApplicable = vehichleTypeRule.CanBeFreeCharge(travelToProcess);

            // assert
            vehichleTypeRuleApplicable.Should().Be(true);
        }
        [Test]
        [TestCaseSource(nameof(PublicHolidayTestDate), new object[] { 2013 })]
        public void It_should_be_free_on_public_holidays(DateTime actionAt)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = VehicleType.Others, ActionAt = actionAt };
            var calendarRule = new DaysRule();

            // act
            var calendarRuleApplicable = calendarRule.CanBeFreeCharge(travelToProcess);

            // assert
            calendarRuleApplicable.Should().Be(true);
        }
        [Test]
        [TestCaseSource(nameof(FreeChargeTimeTest))]
        public void It_should_be_free_on_specific_time(DateTime actionAt)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = VehicleType.Others, ActionAt = actionAt };
            var timeRule = new TimeFreeChargeRule();

            // act
            var timeRuleApplicable = timeRule.CanBeFreeCharge(travelToProcess);

            // assert
            timeRuleApplicable.Should().Be(true);
        }
       
        static IEnumerable<DateTime> PublicHolidayTestDate(int year)
        {
            yield return GothenburgPublicHoliday.NewYear(year);
            yield return GothenburgPublicHoliday.Epiphany(year);
            yield return GothenburgPublicHoliday.WomensDay(year);
            yield return GothenburgPublicHoliday.MayDay(year);
            yield return GothenburgPublicHoliday.Assumption(year);
            yield return GothenburgPublicHoliday.WorldChildrensDay(year);
            yield return GothenburgPublicHoliday.Christmas(year);
          
        }
        static IEnumerable<DateTime> FreeChargeTimeTest()
        {
            yield return new DateTime(2023, 12, 12, 18, 30, 0);
            yield return new DateTime(2023, 12, 12, 20, 0, 0);
            yield return new DateTime(2023, 12, 12, 22, 30, 0);
            yield return new DateTime(2023, 12, 12, 23, 59, 0);
            yield return new DateTime(2023, 12, 12, 1, 0, 0);
            yield return new DateTime(2023, 12, 12, 3, 34, 0);
            yield return new DateTime(2023, 12, 12, 5, 59, 0);

        }
    }
}