using Entities.Models.Fa;
using Entities.Models.FI.Journal;
using Entities.Models.PR;
using Entities.Models.SE;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.FI.Entry
{
    public class FiEntry : EntityBase
    {
        public int JournalId { get; set; }
        public virtual FiJournal Journal { get; set; }
        public int? FiEntrySourceTypeId { get; set; }
        public virtual FiEntrySourceType FiEntrySourceType { get; set; }
        public int No { get; set; }
        [StringLength(350)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal CreditTotal { get; set; }
        public decimal DebitTotal { get; set; }
        public decimal Balance { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        //Navigation Primary
        public virtual ICollection<FiEntryDetails> Fi_Entry_Details { get; set; }
        public virtual ICollection<FaFixedAsset> FaFixedAsset { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => FiEntry } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
