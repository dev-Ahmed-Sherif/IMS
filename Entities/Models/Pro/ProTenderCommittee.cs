using Entities.Models.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    [Index(nameof(Code), IsUnique = true)]
    public class ProTenderCommittee : EntityBaseNotes
    {
        //Navigation Properties
        [Required]
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        //ترسية أو إعادة طرح
        public bool Result { get; set; }
        public virtual ICollection<ProTenderCommitteeMember> TenderCommitteeMembers { get; set; }
        public virtual ICollection<ProTenderSelection> TenderSelection { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
    }
}
