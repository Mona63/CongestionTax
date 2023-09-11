using CongestionTax.Core;
using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public class TimeFreeChargeRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
        private static readonly TimeSpan StartFreeChargeTime = new(18, 30, 0);
        private static readonly TimeSpan EndFreeChargeTime = new(5, 59, 0);
        public bool CanBeFreeCharge(TravelDto travel)
        {
            var result = (travel.ActionAt.IsBetweenTime(StartFreeChargeTime, EndFreeChargeTime));
            return result;
        }

    }
}
