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
    public class ProTenderCommittee : EntityBase
    {
        [MaxLength(50)]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual ProTenderCommitteeRole Role { get; set; }
        [Required]
        public bool Close { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
        //Navigation Properties
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual HrEmployee Employee { get; set; }
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
    }
}
