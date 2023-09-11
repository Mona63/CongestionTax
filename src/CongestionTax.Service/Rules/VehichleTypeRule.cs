using CongestionTax.Core;
using CongestionTax.Core.Dtos;

namespace CongestionTax.Service
{
    public class VehichleTypeRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
       
        public  bool CanBeFreeCharge(TravelDto travel)
        {
            var result = Enum.IsDefined(typeof(FreeChargeVehicleType), travel.VehicleType.ToString());
            return result;
        }
       
    }
}
