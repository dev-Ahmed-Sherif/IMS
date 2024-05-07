using Entities.Models.PR;

namespace Entities.Models.FI.Account
{
    public class FiAccountParent : EntityBase
    {

        public int AccountId { get; set; }
        public virtual FiAccount Account { get; set; }

        public int ParentId { get; set; }
        public virtual FiAccount Parent { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
