using Entities.Models.PR;
using Entities.Models.SE;
using System.Collections.Generic;

namespace Entities.Models.TR.Course
{
    public class TrCourseType : EntityBase
    {
        public string Name { get; set; }
        //public int? SectionId { get; set; }
        public virtual ImsSection Section { get; set; }
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
