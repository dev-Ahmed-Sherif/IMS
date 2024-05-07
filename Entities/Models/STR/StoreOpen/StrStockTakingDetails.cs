using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;




namespace Entities.Models.STR.StoreOpen
{
    public class StrStockTakingDetails : EntityBase

    {

        public decimal SystemQty { get; set; }
        public decimal Balance { get; set; }

        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        [StringLength(250)]
        public string Notes { get; set; }

        //Navigation foreign
        public int STRStockTakingId { get; set; }
        public virtual StrStockTaking StockTaking { get; set; }
        public int ItemId { get; set; }
        public virtual StrItem Item { get; set; }

        //-----------------------------------------------------------------------------------//
        // Relation { PrUser => StrStockTakingDetails } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }




    }
}
