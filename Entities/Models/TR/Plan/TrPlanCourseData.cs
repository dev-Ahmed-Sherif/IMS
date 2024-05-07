using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.TR.Course;

namespace Entities.Models.TR.Plan
{
    public class TrPlanCourseData : EntityBase
    {
        public string Version { get; set; }
        public string Code { get; set; }
        public bool IsMinimum { get; set; }

        //-----------------------------------------------------------------------//
        // Relation { PrUser => TRCourse } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        // Relation Foregin Key { coursecategory,courseType }
        //---------------------------------------------------------------------------//
        public int? CourseId { get; set; }
        public virtual TrCourse TR_Course { get; set; }
        public int? PositionId { get; set; }
        public virtual HrPosition Hr_Position { get; set; }
        public int? FinancialDegreeId { get; set; }
        public virtual HrFinancialDegree Hr_FinancialDegree { get; set; }
    }
}
