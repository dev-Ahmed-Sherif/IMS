using Entities.Models.PR;
using System;



namespace Entities.Models.HR
{
    public class HrEmployeeAttendance : EntityBase

    {
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public int AttendanceMachineId { get; set; }
        public virtual HrAttendanceMachine AttendanceMachine { get; set; }
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }

        public DateTime Date { get; set; }
        public DateTime Attendance { get; set; }
        public DateTime Departure { get; set; }


        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
