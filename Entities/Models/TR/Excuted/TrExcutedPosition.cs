using Entities.Models.HR;
using Entities.Models.PR;

namespace Entities.Models.TR.Excuted
{
    public class TrExcutedPosition : EntityBase
    {
        public int ExcutedId { get; set; }
        public virtual TrExcuted Excuted { get; set; }
        public int PositionId { get; set; }
        public virtual HrPosition Position { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrTrackCourse } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
