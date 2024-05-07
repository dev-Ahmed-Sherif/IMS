using Entities.Models.PR;
using System;

namespace Entities.Models.STR.Product
{
    public class StrProductSerial : EntityBase
    {
        public int Serial { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }

        //---------------------------------------------------------------------------//
        // Relation Foregin Key { Product( الصنف ) ==> ProductSerial ( تفاصيل الصنف )}
        //--------------------------------------------------------------------------//
        public int ProductId { get; set; }
        public virtual StrProduct Product { get; set; }

        //--------------------------------------------------------------------------//
        // Relation Foregin Key {User => Product} + {View Model => TransactionUserId}
        //-------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
