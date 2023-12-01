using CongestionTax.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CongestionTax.Core.Entities
{
    public class Toll
    {
        public int Id { get; set; }
        public DateTime EvaluateAt { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }     
        public decimal Amount { get; set; }
    }
}
