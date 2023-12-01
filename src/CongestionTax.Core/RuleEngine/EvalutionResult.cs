using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Core.RuleEngine
{
    public record EvalutionResult(bool Continue,decimal Amount);
}
