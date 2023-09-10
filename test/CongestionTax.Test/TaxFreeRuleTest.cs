using CongestionTax.RuleEngine;
using FluentAssertions;
using System;

namespace CongestionTax.Test
{
    public class TaxFreeRuleTest
    {
        private RuleEngine.RuleEngine _ruleEngine;


        [SetUp]
        public void Setup()
        {

            var taxFreeRules = new List<ITaxFreeRule> {
                                            new VehichleTypeRule {Proiority=1},
                                            new CalendarRule(){Proiority=2},
                                            new TimeFreeRule(){Proiority=3},
            };
            List<ITaxCaculationRule> _taxCalculationRules = new();
            _ruleEngine = new RuleEngine.RuleEngine(taxFreeRules, _taxCalculationRules);
        }

        [Test]
        [TestCase(VehicleType.Motorcycle)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Tractor)]
        [TestCase(VehicleType.Military)]
        public async Task It_should_be_tax_free_for_except_vehichle(VehicleType vehicleType)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = vehicleType, ActionAt = DateTime.Now };
            var vehichleTypeRule = new VehichleTypeRule();

            // act
            var vehichleTypeRuleApplicable = vehichleTypeRule.IsApplicable(travelToProcess);

            // assert
            vehichleTypeRuleApplicable.Should().Be(true);
        }
        [Test]
        [TestCaseSource(nameof(PublicHolidayTestDate), new object[] { 2013 })]
        public async Task It_should_be_tax_free_on_public_holidays(DateTime actionAt)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = VehicleType.Others, ActionAt = actionAt };
            var calendarRule = new CalendarRule();

            // act
            var calendarRuleApplicable = calendarRule.IsApplicable(travelToProcess);

            // assert
            calendarRuleApplicable.Should().Be(true);
        }
        [Test]
        [TestCaseSource(nameof(TaxFreeTimeTest))]
        public async Task It_should_be_tax_free_on_specific_time(DateTime actionAt)
        {
            // arrange
            var travelToProcess = new Travel { Id = 1, VehicleId = 1, VehicleType = VehicleType.Others, ActionAt = actionAt };
            var timeRule = new TimeFreeRule();

            // act
            var timeRuleApplicable = timeRule.IsApplicable(travelToProcess);

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
        static IEnumerable<DateTime> TaxFreeTimeTest()
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