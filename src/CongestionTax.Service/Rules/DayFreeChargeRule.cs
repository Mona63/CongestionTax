using CongestionTax.Core;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Service
{
    public class DayFreeChargeRule : ICongestionTaxRule
    {
        int Priority => 1;

        public async Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult)
        {
            var continueEvalution = true;
            var amount = lastEvalutionResult.Amount;

            if (travel.TravelAt.IsWeekend() ||
                           travel.TravelAt.IsPublicHoliday() ||
                           travel.TravelAt.IsDayBeforePublicHoliday() ||
                           travel.TravelAt.IsJuly())
            {
                continueEvalution = false;
                amount = 0m;
            }
            return new EvalutionResult(continueEvalution, amount);

        }

    }


}
