using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.FI.Account
{
    public class FiAccountHierarchy : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        public string Level { get; set; }
        //----------------------------------------------------------------------------------------//
        // Relation { Account } +++ {Navigation Primary => AccountHierarchyId} 
        //----------------------------------------------------------------------------------------//
        public virtual ICollection<FiAccount> FiAccount { get; set; }
        //----------------------------------------------------------------------------//
        // Relation { PrUser => AccountHierarchy } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
