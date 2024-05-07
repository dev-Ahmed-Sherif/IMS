using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models.STR.General
{
    public class StrApprovalStatus : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        //---------------------------------------------------------------------//
        // Relation { PrUser => StrApprovalStatus } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
