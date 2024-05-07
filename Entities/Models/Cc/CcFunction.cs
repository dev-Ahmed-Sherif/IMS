using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcFunction : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }

        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //navigation
        public virtual ICollection<CcSource> CcSource { get; set; }
        public virtual ICollection<CcCostCenter> CcCostCenter { get; set; }
    }
}
