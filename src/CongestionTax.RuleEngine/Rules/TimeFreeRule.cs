using System.Reflection.Metadata;

namespace CongestionTax.RuleEngine
{
    public class TimeFreeRule : ITaxFreeRule
    {
        public int Proiority { get; set; }
        private static readonly TimeSpan StartFreeTaxTime = new(18, 30, 0);
        private static readonly TimeSpan EndFreeTaxTime = new(5, 59, 0);
        public bool IsApplicable(Travel travel)
        {
            var result = IsTaxFreeTime(travel.ActionAt);
            return result;
        }

        private bool IsTaxFreeTime(DateTime dt)
        {
            var result = (dt.IsBetweenTime(StartFreeTaxTime, EndFreeTaxTime));
            return result;

        }
    }
}
