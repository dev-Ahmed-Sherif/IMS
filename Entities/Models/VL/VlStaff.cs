using Entities.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlStaff : EntityBaseNotes
    {
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual HrEmployee Employee { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual VlStaffStatus Status { get; set; }
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public virtual VlStaffPosition Position { get; set; }

    }
}
