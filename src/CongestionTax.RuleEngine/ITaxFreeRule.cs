using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.RuleEngine
{
    public interface ITaxFreeRule : ICongestionTaxBaseRule
    {
        public  bool IsApplicable(Travel travel);
    }
}
