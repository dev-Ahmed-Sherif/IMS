using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlVehicleLicense : EntityBaseNotes
    {
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))] 
        public virtual VlViechle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
