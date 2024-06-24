using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlDrivierLicense : EntityBaseNotes
    {
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public virtual VlStaff Driver { get; set; }
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public virtual VlDrivierLicenseType Type { get; set; }
    }
}
