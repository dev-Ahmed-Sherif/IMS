using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models.HR
{
    public class HrQualification : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }
        public int QualitativeGroupId { get; set; }
        public virtual HrQualitativeGroup QualitativeGroup { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<HrEmployee> Employees { get; set; }


    }
}
