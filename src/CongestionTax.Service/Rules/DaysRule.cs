using CongestionTax.Core;
using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public class DaysRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
        public  bool CanBeFreeCharge(TravelDto travel)
        {
            var result = (travel.ActionAt.IsWeekend() ||
                           travel.ActionAt.IsPublicHoliday() ||
                           travel.ActionAt.IsDayBeforePublicHoliday() ||
                           travel.ActionAt.IsJuly());
            return result;
        }

    }
}
