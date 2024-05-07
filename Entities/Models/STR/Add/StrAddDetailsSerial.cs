using Entities.Models.PR;
using Entities.Models.STR.Product;

namespace Entities.Models.STR.Add
{
    public class StrAddDetailsSerial : EntityBase
    {
        //----------------------------------------------------------------------//
        // Relation Foregin Key { AddDetails,ProductSerial ==> AddDetailsSerial }
        //----------------------------------------------------------------------//
        public int AddDetailsId { get; set; }
        public virtual StrAddDetails AddDetails { get; set; }
        public int ProductSerialId { get; set; }
        public virtual StrProductSerial ProductSerial { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public virtual StrProduct Product { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => StrAddDetailsSerial } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
