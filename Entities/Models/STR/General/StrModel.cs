using Entities.Models.PR;

namespace Entities.Models.STR.General
{
    public class StrModel : EntityBase
    {
        public string Name { get; set; }

        //--------------------------------------------------------------------------------//
        // Relation Foregin Key { StrVendor( تعريف الصنف ) ==> StrModel ( الموديل الصنف )}
        //--------------------------------------------------------------------------------//
        public int VendorId { get; set; }
        public virtual StrVendor Vendor { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => StrAddDetailsSerial } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
