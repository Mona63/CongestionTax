namespace CongestionTax.RuleEngine
{
    public class VehichleTypeRule : IFreeChargeRule
    {
        public int Proiority { get; set; }
       
        public  bool CanBeFreeCharge(Travel travel)
        {
            var result = Enum.IsDefined(typeof(FreeChargeVehicleType), travel.VehicleType.ToString());
            return result;
        }
       
    }
}
