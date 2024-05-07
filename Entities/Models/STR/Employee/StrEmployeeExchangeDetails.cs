using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Employee
{
    public class StrEmployeeExchangeDetails : EntityBase
    {

        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string State { get; set; }

        public decimal Percentage { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }
        public int ItemId { get; set; }

        public virtual StrItem STR_Item { get; set; }

        public int Employee_ExchangeId { get; set; }

        public virtual StrEmployeeExchange STR_Employee_Exchange { get; set; }
        //------------------------------------------------------------------------------------//
        // Relation { PrUser => StrEmployeeExchangeDetails } +++ {View Model => TransactionUserId} 
        //------------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
