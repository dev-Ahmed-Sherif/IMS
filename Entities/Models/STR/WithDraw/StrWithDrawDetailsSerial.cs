using Entities.Models.PR;
using Entities.Models.STR.Product;

namespace Entities.Models.STR.WithDraw
{
    public class StrWithDrawDetailsSerial : EntityBase
    {

        public int StrWithDrawDetailsId { get; set; }
        public virtual StrWithDrawDetails StrWithDrawDetails { get; set; }
        public int ProductSerialId { get; set; }
        public virtual StrProductSerial ProductSerial { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public virtual StrProduct Product { get; set; }

        //------------------------------------------------------------------------------------//
        // Relation { PrUser => StrWithDrawDetailsSerial } +++ {View Model => TransactionUserId} 
        //------------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
