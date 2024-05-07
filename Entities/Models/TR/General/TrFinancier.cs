using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Plan;
using System.Collections.Generic;

namespace Entities.Models.TR.General
{
    public class TrFinancier : EntityBase
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => TrFinancier } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<TrExcutedFinancier> TrExcutedFinancier { get; set; }
        public virtual ICollection<TrPlanFinancier> TrPlanFinancier { get; set; }
    }
}
