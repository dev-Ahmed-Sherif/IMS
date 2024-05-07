using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcActivity : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }

        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //Navigation
        public virtual ICollection<CcCostCenter> CcCostCenter { get; set; }
        public virtual ICollection<CcEntryDetails> CcEntryDetails { get; set; }//24-10
    }
}
