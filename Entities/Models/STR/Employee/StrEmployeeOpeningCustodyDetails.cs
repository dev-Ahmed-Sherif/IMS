using Entities.Models.PR;
using Entities.Models.STR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Employee
{
    public class StrEmployeeOpeningCustodyDetails : EntityBase
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int Total { get; set; }
        [StringLength(150)]
        public string State { get; set; }
        public int Percentage { get; set; }
        [StringLength(150)]
        public string Notes { get; set; }
        public string Description { get; set; }
        //Navigate foreignkey
        public int CustodyId { get; set; }
        public virtual StrEmployeeOpeningCustody STR_Employee_Opening_Custody { get; set; }
        public int ItemId { get; set; }
        public virtual StrItem STR_Item { get; set; }
        //----------------------------------------------------------------------------------------------//
        // Relation { PrUser => StrEmployeeOpeningCustodyDetails } +++ {View Model => TransactionUserId} 
        //---------------------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }

}
