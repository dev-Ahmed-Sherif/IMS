using Entities.Models.Cc;
using Entities.Models.FI.Entry;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Fa
{
    public class FaFixedAsset : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string? Place { get; set; }
        public int CategoryFirstId { get; set; }
        public virtual FaCategoryFirst CategoryFirst { get; set; }
        public int CategorySecondId { get; set; }
        public virtual FaCategorySecond CategorySecond { get; set; }
        public int CategoryThirdId { get; set; }
        public virtual FaCategoryThird CategoryThird { get; set; }
        public string No { get; set; }

        [StringLength(10)]
        public string Code { get; set; }
        public int? CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public int? EntryId { get; set; }
        public virtual FiEntry Entry { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime? WorkDate { get; set; }
        public decimal InitialValue { get; set; }
        public decimal? BookValue { get; set; }
        public decimal DepreciationRate { get; set; }
        public DateTime? SpeculateDate { get; set; }

        public decimal? SpeculateValue { get; set; }

        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
