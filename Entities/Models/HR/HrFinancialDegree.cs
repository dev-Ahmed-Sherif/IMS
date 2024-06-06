using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Entities.Models.TR.Plan;

namespace Entities.Models.HR
{
    public class HrFinancialDegree : EntityBase
    {
        public int? Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public int NoYear { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<HrEmployee> Employees { get; set; }
        //public List<TrPlan> TrPlanFinancialDegree { get; set; }
        //public List<TrPlanCourseData> TrPlanCourseData_Financial { get; set; }


    }
}
