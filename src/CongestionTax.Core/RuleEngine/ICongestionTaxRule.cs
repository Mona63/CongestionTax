using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Core
{
    public interface ICongestionTaxRule
    {
        int Priority => int.MaxValue;
        Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult);
    }
    
}
