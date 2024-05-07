using Entities.Models.PR;

namespace Entities.Models.STR.General
{
    public class StrVendor : EntityBase
    {
        public string Name { get; set; }

        //--------------------------------------------------------------------------------//
        // Relation { PrUser => StrAddDetailsSerial } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
