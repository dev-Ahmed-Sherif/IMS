using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlVehicleItinerary : EntityBaseNotes
    {
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual VlViechle Vehicle { get; set; }
        public int ItineraryId { get; set; }
        [ForeignKey(nameof(ItineraryId))]
        public virtual VlItinerary Itinerary { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
