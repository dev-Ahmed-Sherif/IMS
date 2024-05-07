using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Instructor;
//using Entities.Models.TR.Plan;
using System.Collections.Generic;

namespace Entities.Models.TR.Course
{
    public class TrCourse : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
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
        public int? CategoryId { get; set; }
        public virtual TrCourseCategory Category { get; set; }
        public int? CourseTypeId { get; set; }

        public virtual TrCourseType CourseType { get; set; }
        public virtual ICollection<TrInstructorCourse> Tr_InstructorCourse { get; set; }
        public virtual ICollection<TrExcuted> TrExcutedCourse { get; set; }
        //public List<TrPlan> TrPlanCourse { get; set; }
        //public List<TrPlanCourseData> TrPlanCourseData { get; set; }
    }
}
