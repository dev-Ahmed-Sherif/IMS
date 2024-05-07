using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrAttendanceMachineWorkPlace : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------

        public DateTime Date { get; set; }
        public int AttendanceMachineId { get; set; }
        public virtual HrAttendanceMachine AttendanceMachine { get; set; }
        public int WorkPlaceId { get; set; }
        public virtual HrWorkPlace WorkPlace { get; set; }

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }





    }
}
