using Entities.Models.FI.Account;
using Entities.Models.PR;

namespace Entities.Models.STR.Add
{
    public class StrWithDrawType : EntityBase
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        public int? AccountId { get; set; }
        public virtual FiAccount Account { get; set; }

        //-----------------------------------------------------------------------//
        // Relation { PrUser =>StrWithDrawType } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //---------------------------------------------------------------------------//
        // Relation { AddReceipts => StrAdd } +++ {Navigation Primary => AddReceiptId} 
        //---------------------------------------------------------------------------//

    }
}
