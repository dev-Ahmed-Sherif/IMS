using Entities.Models.PR;
using System.Collections.Generic;

namespace Entities.Models.TR.Course
{
    public class TrCourseType : EntityBase
    {
        public string Name { get; set; }

        // Relation { PrUser => TRCoursetype } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        // Relation {TRCourse => TRCoursetype } +++ {Navigation Primary => courseId} 
        //---------------------------------------------------------------//
        public virtual ICollection<TrCourse> TR_Course { get; set; }
    }
}
