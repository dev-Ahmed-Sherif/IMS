using Entities.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderCommitteeMember : EntityBaseNotes
    {
        public int TenderCommitteeId { get; set; }
        [ForeignKey(nameof(TenderCommitteeId))]
        public virtual ProTenderCommittee TenderCommittee { get; set; }
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
