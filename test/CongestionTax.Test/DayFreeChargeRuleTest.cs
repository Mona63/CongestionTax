﻿using CongestionTax.Core;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using CongestionTax.Service;
using FluentAssertions;

namespace CongestionTax.Test
{
    public class DayFreeChargeRuleTest
    {
        [Test]
        [TestCaseSource(nameof(PublicHolidayTestDate), new object[] { 2013 })]
        public async Task It_should_be_free_on_public_holidays(DateTime actionAt)
        {
            // arrange
            var travelToProcess = new Travel() { TravelAt = actionAt };
            var dayFreeRule = new DayFreeChargeRule();
            var evaluationResult = new EvalutionResult(true, 0);

            // act
            var actResult = await dayFreeRule.Evaluate(travelToProcess, evaluationResult);

            // assert
            actResult.Amount.Should().Be(0);
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
    }
}
