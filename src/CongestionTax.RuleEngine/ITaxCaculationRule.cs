using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.RuleEngine
{
    public interface ITaxCaculationRule:ICongestionTaxBaseRule
    {
        public  decimal GetTaxAmount(Travel travel,decimal currentTax);
    }
}
