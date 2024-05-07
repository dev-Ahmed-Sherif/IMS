using Entities.Models.HR;
using Entities.Models.PR;

namespace Entities.Models.TR.Excuted
{
    public class TrExcutedTrainee : EntityBase
    {
        public int? ExcutedId { get; set; }
        public virtual TrExcuted Excuted { get; set; }
        public int? EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int? TraineeId { get; set; }
        public virtual TrTrainee Trainee { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrTrackCourse } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
