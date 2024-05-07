using Entities.Models.HR;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class HrEmployeePosition : EntityBase
    {



        [StringLength(50)]
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int PositionId { get; set; }
        public virtual HrPosition Position { get; set; }
        public int WorkPlaceId { get; set; }
        public virtual HrWorkPlace WorkPlace { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary


    }
}
