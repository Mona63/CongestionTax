using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Core.Entities
{
    public class Travel
    {
        public int Id { get; set; }
        public DateTime TravelAt { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
