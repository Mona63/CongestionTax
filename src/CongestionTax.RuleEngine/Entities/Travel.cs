namespace CongestionTax.RuleEngine
{
    public class Travel
    {
        public int Id { get; set; }
        public DateTime ActionAt { get; set; }
        public int VehicleId { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
