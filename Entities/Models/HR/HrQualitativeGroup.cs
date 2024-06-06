using Entities.Models.PR;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Models.HR
{
    public class HrQualitativeGroup : EntityBase
    {
        public string Name { get; set; }
        public int Code { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public virtual ICollection<HrQualification> HrQualifications { get; set; }

    }


}
