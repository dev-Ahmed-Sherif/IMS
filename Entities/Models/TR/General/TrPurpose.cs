using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Plan;
using System.Collections.Generic;

namespace Entities.Models.TR.General
{
    public class TrPurpose : EntityBase
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => rPurpose } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public virtual ICollection<TrExcuted> Material_Purpose { get; set; }
        public virtual ICollection<TrExcuted> Ex_Purpose { get; set; }

        public virtual ICollection<TrPlan> TrPlan_Purpose { get; set; }

    }
}
