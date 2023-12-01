using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Core
{
    public interface ICongestionTaxRule
    {
        Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult);
    }
}
