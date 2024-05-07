using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Fa
{
    public class FaCategorySecond : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(5)]
        public string Code { get; set; }


        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //navigation
        public virtual ICollection<FaFixedAsset> FaFixedAsset { get; set; }
    }
}
