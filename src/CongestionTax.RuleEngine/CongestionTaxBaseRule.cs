using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.RuleEngine
{
    public abstract class CongestionTaxBaseRule
    {
        public int Proiority { get; set; }
        public abstract bool IsApplicable(Travel travel);
        public abstract decimal GetTaxFee();
    }
}
