using Entities.Models.PR;
//using Entities.Models.TR.Excuted;
//using Entities.Models.TR.Plan;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrPosition : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy
        {
            get; set;
        }
        public override int? UpdateByID
        {
            get; set;
        }
        public virtual PrUser UpdateBy
        {
            get; set;
        }
        //public List<TrExcutedPosition> TrExcutedPosition { get; set; }
        //public List<TrPlanCourseData> TrPlanCourseData_position { get; set; }
        //public List<TrPlanPosition> Tr_PlanPosition { get; set; }
    }
}
