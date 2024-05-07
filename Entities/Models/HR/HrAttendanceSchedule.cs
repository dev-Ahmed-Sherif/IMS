using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrAttendanceSchedule : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WrkHours { get; set; }
        public DateTime AttendanceTime { get; set; }
        public int AttendanceAllowance { get; set; }
        public int DepartureAllowance { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
