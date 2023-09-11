using CongestionTax.Core;

namespace CongestionTax.Core.Dtos
{
    public class TravelDto
    {
        public int VehicleId { get;  set; }
        public VehicleType VehicleType { get;  set; }
        public DateTime ActionAt { get;  set; }
       
    }
}