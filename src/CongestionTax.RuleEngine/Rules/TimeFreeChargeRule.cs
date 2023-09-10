using CongestionTax.Core;
using System.Reflection.Metadata;

namespace CongestionTax.RuleEngine
{
    public class TimeFreeChargeRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
        private static readonly TimeSpan StartFreeChargeTime = new(18, 30, 0);
        private static readonly TimeSpan EndFreeChargeTime = new(5, 59, 0);
        public bool CanBeFreeCharge(Travel travel)
        {
            var result = (travel.ActionAt.IsBetweenTime(StartFreeChargeTime, EndFreeChargeTime));
            return result;
        }

    }
}
