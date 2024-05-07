using Entities.Models.PR;
using Entities.Models.TR.Instructor;

namespace Entities.Models.TR.Excuted
{
    public class TrExcutedInstructor : EntityBase
    {
        public int ExcutedId { get; set; }
        public virtual TrExcuted Excuted { get; set; }
        public int InstructorId { get; set; }
        public virtual TrInstructor Instructor { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrTrackCourse } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
