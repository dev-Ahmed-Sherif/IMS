using Entities.Models.Cc;
using Entities.Models.FI.Entry;
using Entities.Models.PR;
using Entities.Models.STR.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entities.Models.FI.Account
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class FiAccount : EntityBase
    {
        [StringLength(100)]
        public string Code { get; set; }
        public string Name { get; set; }
        //-----------------------------------------------------------------------------------
        // Relation { AccountHierarchy => Account } +++ {forign key => FiAccountHierarchyIdId} 
        //-----------------------------------------------------------------------------------
        public int FiAccountHierarchyId { get; set; }
        public virtual FiAccountHierarchy FiAccountHierarchy { get; set; }
        //------------------------------------------------------------------------------------------
        // Relation { AccountItem,AccountParent,EntryDetails } +++ {Navigation Primary => AccountId} 
        //------------------------------------------------------------------------------------------
        public virtual ICollection<FiAccountItem> FiAccountItem { get; set; }
        public virtual ICollection<FiAccountParent> FiAccountParent { get; set; }
        public virtual ICollection<FiAccountParent> FiAccountParent1 { get; set; }
        public virtual ICollection<FiEntryDetails> FiEntryDetails { get; set; }
        public virtual ICollection<StrCommodity> StrCommodity { get; set; }
        public virtual ICollection<StrGrade> StrGrade { get; set; }
        public virtual ICollection<CcEntryDetails> CcEntryDetails { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        private string GetDebuggerDisplay()
        {
            return $"{Code} - {Name}";
        }
    }
}
