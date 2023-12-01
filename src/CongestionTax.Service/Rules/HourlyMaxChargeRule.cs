using CongestionTax.Core;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Service
{
    public class HourlyMaxChargeRule : ICongestionTaxRule
    {
        private readonly ITollRepository _tollRepository;

        public HourlyMaxChargeRule(ITollRepository tollRepository)
        {
            _tollRepository = tollRepository;

        }
        public async Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult)
        {
            var countinueEvaluation = true;
            var amount = lastEvalutionResult.Amount;
            var lastHourVehicleTolls = await _tollRepository.GetAllAsync(c => c.Travel.VehicleId == travel.VehicleId &&
                                                                            c.Travel.TravelAt > travel.TravelAt.AddHours(-1) &&
                                                                            c.Travel.TravelAt < travel.TravelAt);

            if (lastHourVehicleTolls.Max(t => t.Amount) >= lastEvalutionResult.Amount)
            {
                countinueEvaluation = false;
                amount = 0;
            }


            return new EvalutionResult(countinueEvaluation, amount);

        }
    }
}
