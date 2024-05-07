using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Product
{
    public class StrProduct : EntityBase
    {
        public string Name { get; set; }
        [StringLength(50)]
        public string Attachment { get; set; }

        public int Code { get; set; }
        //---------------------------------------------------------//
        // Relation Foregin Key { Item,Vendor,Model ==> StrProduct }
        //---------------------------------------------------------//
        public int ItemId { get; set; }
        public virtual StrItem Item { get; set; }
        public int VendorId { get; set; }
        public virtual StrVendor Vendor { get; set; }
        public int ModelId { get; set; }
        public virtual StrModel Model { get; set; }

        //----------------------------------------------------------------------------//
        // Relation Foregin Key { User => Product } + {View Model => TransactionUserId}
        //----------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
