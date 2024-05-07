using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Add
{
    public class StrAddDetails : EntityBase
    {

        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal AvgPrice { get; set; }
        public string State { get; set; }
        public decimal? Percentage { get; set; }
        [StringLength(250)]
        public string Notes { get; set; }
        //-----------------------------------------------//
        // Relation Foregin Key { Add,Item ==> AddDetails }
        //-----------------------------------------------//
        public int AddId { get; set; }
        public virtual StrAdd STR_Add { get; set; }
        public int ItemId { get; set; }
        public virtual StrItem STR_Item { get; set; }

        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //public int FiscalYearId { get; set; }
        //public StrFiscalYear fiscalyear { get; set; }
    }
}
