using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.FI.Account
{
    public class FiAccountItemCategory : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        //--------------------------------------------------------------------
        // Relation { EntryDetails } +++ {Navigation Primary => AccountItemId } 
        //--------------------------------------------------------------------
        public virtual ICollection<FiAccountItem> FiAccountItem { get; set; }

        //---------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //---------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
