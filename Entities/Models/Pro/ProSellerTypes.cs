using Entities.Models.PR;

namespace Entities.Models.Pro
{
    public class ProSellerTypes : EntityBase
    {
        public int SellerId { get; set; }
        public virtual ProSeller Seller { get; set; }
        public int SellerTypeId { get; set; }
        public virtual ProSupplierType SellerType { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
