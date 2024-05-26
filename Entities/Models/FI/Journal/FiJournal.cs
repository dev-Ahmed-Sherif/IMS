using Entities.Models.Cc;
using Entities.Models.FI.Entry;
using Entities.Models.PR;
using Entities.Models.SE;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.FI.Journal
{
    public class FiJournal : EntityBase
    {
        public int No { get; set; }
        [StringLength(350)]
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? FiscalYearId { get; set; }
        public virtual StrFiscalYear FiscalYear { get; set; }
        public int? SectionId { get; set; }
        public virtual ImsSection Section { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual FiJournalType Type { get; set; }
        //Navigation Primary
        public virtual ICollection<FiEntry> Fi_Entry { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }



    }
}
