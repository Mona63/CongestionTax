namespace CongestionTax.RuleEngine
{
    public class VehichleTypeRule : CongestionTaxBaseRule
    {
        public VehichleTypeRule(int proiority)
        {
            Proiority = proiority;
        }
        public override bool IsApplicable(Travel travel)
        {
            if (IsTaxFreeVehicle(travel.VehicleType)) return true;
            return false;
        }
        public override decimal GetTaxFee()
        {
            return 0;
        }
        private bool IsTaxFreeVehicle(VehicleType vehicleType)
        {
            var taxFreeVehichle = Enum.IsDefined(typeof(FreeTaxVehicleType), vehicleType.ToString());
            return taxFreeVehichle;
        }

    }
}
