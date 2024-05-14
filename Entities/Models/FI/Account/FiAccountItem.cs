using Entities.Models.FI.Entry;
using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.FI.Account
{
    public class FiAccountItem : EntityBase
    {
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        //-------------------------------------------------------------------
        // Relation { FiAccountItemCategory => AccountItem } +++ { Forign key => AccountItemCategoryId } 
        //-------------------------------------------------------------------
        public int? AccountItemCategoryId { get; set; }
        public virtual FiAccountItemCategory AccountItemCategory { get; set; }
        //-------------------------------------------------------------------
        // Relation { Account => AccountItem } +++ { Forign key => AccountId } 
        //-------------------------------------------------------------------
        public int? AccountId { get; set; }
        public virtual FiAccount Account { get; set; }
        //--------------------------------------------------------------------
        // Relation { EntryDetails } +++ {Navigation Primary => AccountItemId } 
        //--------------------------------------------------------------------
        public virtual ICollection<FiEntryDetails>? FiEntryDetails { get; set; }

        //---------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //---------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
