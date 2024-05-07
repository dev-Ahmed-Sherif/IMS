using Entities.Models.PR;
using Entities.Models.TR.Course;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR.Instructor
{
    public class TrInstructorCourse : EntityBase
    {

        [StringLength(50)]
        public string Rating { get; set; }

        public decimal price { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        //-------------------------------------------------//
        // Relation { TrInstructorCourse => TrInstructor }  
        //-------------------------------------------------//
        public int InstructorId { get; set; }
        public virtual TrInstructor Instructor { get; set; }
        public int? CourseId { get; set; }
        public virtual TrCourse Course { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrInstructorCourse } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        virtual public PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
