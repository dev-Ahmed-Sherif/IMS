using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrEmployeeFinancialDegree : EntityBase
    {
        [StringLength(50)]


        public int FinancialDegreeId { get; set; }

        public virtual HrFinancialDegree FinancialDegree { get; set; }

        public DateTime FinancialDegreeDate { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
