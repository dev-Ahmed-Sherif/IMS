using Entities.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderOpeningMember : EntityBaseNotes
    {
        public int TenderOpeningId { get; set; }
        [ForeignKey(nameof(TenderOpeningId))]
        public virtual ProTenderOpening TenderOpening { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual ProTenderCommitteeRole Role { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual HrEmployee Employee { get; set; }
    }
}
