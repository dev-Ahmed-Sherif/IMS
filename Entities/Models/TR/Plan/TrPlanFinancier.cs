using Entities.Models.PR;
using Entities.Models.TR.General;

namespace Entities.Models.TR.Plan
{
    public class TrPlanFinancier : EntityBase
    {

        //-----------------------------------------------------------------------//
        // Relation { PrUser => TRCourse } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //---------------------------------------------------------------------------//
        // Relation Foregin Key { coursecategory,courseType }
        //---------------------------------------------------------------------------//
        public int? PlanId { get; set; }
        public virtual TrPlan Plan { get; set; }
        public int? FinancierId { get; set; }
        public virtual TrFinancier Financier { get; set; }

    }
}
