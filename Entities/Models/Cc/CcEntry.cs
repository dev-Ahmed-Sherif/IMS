using Entities.Models.FI.Journal;
using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcEntry : EntityBase
    {
        public int No { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal? CreditTotal { get; set; }
        public decimal? DebitTotal { get; set; }
        public decimal? Balance { get; set; }
        public int? FiscalYearId { get; set; }
        public virtual StrFiscalYear Fiscalyear { get; set; }
        public int? JournalId { get; set; }
        public virtual FiJournal Journal { get; set; }

        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //navigation
        public virtual ICollection<CcEntryDetails> CcEntryDetails { get; set; }//24-10
    }
}
