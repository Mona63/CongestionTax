namespace CongestionTax.RuleEngine
{
    public class VehichleTypeRule : ITaxFreeRule
    {
        public int Proiority { get; set; }
       
        public  bool IsApplicable(Travel travel)
        {
            var result= IsTaxFreeVehicle(travel.VehicleType);    
            return result;
        }
       
        private bool IsTaxFreeVehicle(VehicleType vehicleType)
        {
            var result= Enum.IsDefined(typeof(FreeTaxVehicleType), vehicleType.ToString());   
            return result;
        }

    }
}
