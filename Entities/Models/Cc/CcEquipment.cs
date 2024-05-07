using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcEquipment : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public int CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }



        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //navigation
        public virtual ICollection<CcEntryDetails> CcEntryDetails { get; set; }

    }
}
