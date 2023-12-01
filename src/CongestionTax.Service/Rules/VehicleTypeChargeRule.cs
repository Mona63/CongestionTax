using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Service
{
    public class VehicleTypeChargeRule : ICongestionTaxRule
    {
        public async Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult)
        {
            var continueEvalution = true;
            var amount = lastEvalutionResult.Amount;

            if (!(travel.Vehicle.VehicleType == VehicleType.Personal))
            {
                 continueEvalution = false;
                 amount = 0m;
            }
            
            return new EvalutionResult(continueEvalution, amount);
        }
    }
}
