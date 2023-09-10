using CongestionTax.Core;

namespace CongestionTax.RuleEngine
{
    public class DaysRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
        public  bool CanBeFreeCharge(Travel travel)
        {
            var result = (travel.ActionAt.IsWeekend() ||
                           travel.ActionAt.IsPublicHoliday() ||
                           travel.ActionAt.IsDayBeforePublicHoliday() ||
                           travel.ActionAt.IsJuly());
            return result;
        }
    }
}
