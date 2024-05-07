using Entities.Models.PR;
using Entities.Models.TR.Instructor;

namespace Entities.Models.TR.Plan
{
    public class TrPlanInstructor : EntityBase
    {
        public int PlanId { get; set; }
        public virtual TrPlan Plan { get; set; }
        public int InstructorId { get; set; }
        public virtual TrInstructor Instructor { get; set; }

        // Relation { PrUser => TrPlanInstructor } +++ {View Model => TransactionUserId} 
        //------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
