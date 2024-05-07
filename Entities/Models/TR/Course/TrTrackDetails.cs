using Entities.Models.PR;

namespace Entities.Models.TR.Course
{
    public class TrTrackDetails : EntityBase
    {
        public int? CourseId { get; set; }
        public virtual TrCourse Course { get; set; }
        public int? TrackId { get; set; }
        public virtual TrTrack Track { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrTrackCourse } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
