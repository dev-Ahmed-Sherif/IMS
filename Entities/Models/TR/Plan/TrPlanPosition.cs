using Entities.Models.HR;
using Entities.Models.PR;

namespace Entities.Models.TR.Plan
{
    public class TrPlanPosition : EntityBase
    {
        public int PlanId { get; set; }
        public virtual TrPlan Plan { get; set; }
        public int PositionId { get; set; }
        public virtual HrPosition Position { get; set; }
        // Relation { PrUser => TrPlanPosition } +++ {View Model => TransactionUserId} 
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
