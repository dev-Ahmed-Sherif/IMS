using Entities.Models.PR;

namespace Entities.Models.Pro
{
    public class ProVendorsTypes : EntityBase
    {
        public int VendorId { get; set; }
        public virtual ProVendor Vendor { get; set; }
        public int VendorTypeId { get; set; }
        public virtual ProVendorType VendorType { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
