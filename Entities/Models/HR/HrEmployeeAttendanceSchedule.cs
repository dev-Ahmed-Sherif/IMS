using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrEmployeeAttendanceSchedule : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int AttendanceScheduleId { get; set; }
        public virtual HrAttendanceSchedule AttendanceSchedule { get; set; }
        public int AttendancePermissionId { get; set; }
        public virtual HrAttendancePermission AttendancePermission { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
