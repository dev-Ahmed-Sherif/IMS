using Entities.Models.PR;
using Entities.Models.STR.General;

namespace Entities.Models.STR.WithDraw
{
    public class StrWithDrawDetails : EntityBase
    {

        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string State { get; set; }

        public decimal? Percentage { get; set; }
        public string Notes { get; set; }


        //Navigation foreign

        public int STR_WithdrawId { get; set; }
        public virtual StrWithDraw STR_Withdraw { get; set; }

        public int ItemId { get; set; }
        public virtual StrItem STR_Item { get; set; }

        //------------------------------------------------------------------------//
        // Relation { PrUser => StrWithDrawDetails } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
