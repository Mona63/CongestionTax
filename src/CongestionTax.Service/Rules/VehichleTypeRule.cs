using CongestionTax.Core;
using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public class VehichleTypeRule : IFreeChargeRule
    {

        public bool CanBeFreeCharge(TravelDto travel)
        {

            var result = true;
                //!(travel.VehicleType == VehicleType.ShouldBeCharge);

            return result;
        }

    }
}
