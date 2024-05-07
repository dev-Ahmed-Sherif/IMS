using Entities.Models.FI.Account;
using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcEntryDetails : EntityBase
    {
        public int EntryId { get; set; }
        public virtual CcEntry Entry { get; set; }
        public int AccountId { get; set; }
        public virtual FiAccount Account { get; set; }
        public int ActivityId { get; set; }
        public virtual CcActivity Activity { get; set; }
        public int CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public int? EquipmentId { get; set; }
        public virtual CcEquipment Equipment { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Qty { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }



        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
