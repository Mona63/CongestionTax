using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;
using System.Data;
using System.Text;

namespace CongestionTax.Service
{
    public class RuleEngine : IRuleEngine
    {
        readonly IEnumerable<ICongestionTaxRule> _rules;
      
        public RuleEngine(IEnumerable<ICongestionTaxRule> rules)
        {
            _rules = rules;
        }

        public async Task<decimal> Run(Travel travel)
        {
           var result= new EvalutionResult(true, 0);
            foreach (var rule in _rules)
            {

                result = await rule.Evaluate(travel, result);
                if (!result.Continue)
                {
                    break;
                }

            }
           return result.Amount;
           
        }
    }
}
