using CongestionTax.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CongestionTax.Core.Entities
{
    public class Toll
    {
      
        public int Id { get; set; }
        public DateTime ActionAt { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }     
        public decimal Amount { get; set; }
    }
}
