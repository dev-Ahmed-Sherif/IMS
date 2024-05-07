using Entities.Models.Cc;
using Entities.Models.FI.Account;
using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.FI.Entry
{
    public class FiEntryDetails : EntityBase
    {
        public int EntryId { get; set; }
        public virtual FiEntry Entry { get; set; }
        public int AccountId { get; set; }
        public virtual FiAccount Account { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        [StringLength(350)]
        public string Description { get; set; }
        public int? FiAccountItemId { get; set; }
        public virtual FiAccountItem FiAccountItem { get; set; }
        public int? CheckNo { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => FiEntryDetails } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public int? CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
    }
}
