using CongestionTax.Core;

namespace CongestionTax.Core.Dtos
{
    public class TraveltoEvaluateDto
    {
        public int TravelId { get;  set; }
        public int VehicleId { get; set; }
        public DateTime TravelAt { get; set; }
    }
}