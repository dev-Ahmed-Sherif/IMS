using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.StoreOpen
{
    public class StrOpeningStockDetails : EntityBase
    {
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        [StringLength(250)]
        public string Notes { get; set; }

        //Navigation foreign
        public int STR_Opening_StockId { get; set; }
        public virtual StrOpeningStock STR_Opening_Stock { get; set; }
        public int ItemId { get; set; }
        public virtual StrItem STR_Item { get; set; }

        //-----------------------------------------------------------------------------------//
        // Relation { PrUser => StrOpeningStockDetails } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
