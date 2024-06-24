using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlVehicleGarage : EntityBaseNotes
    {
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual VlViechle Vehicle { get; set; }
        public int GarageId { get; set; }
        [ForeignKey(nameof(GarageId))]
        public virtual VlGarage Garage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
