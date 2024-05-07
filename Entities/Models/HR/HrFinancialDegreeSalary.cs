using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrFinancialDegreeSalary : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }
        public int FinancialDegreeId { get; set; }
        public virtual HrFinancialDegree FinancialDegree { get; set; }
        public int Salary { get; set; }
        public DateTime Date { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
