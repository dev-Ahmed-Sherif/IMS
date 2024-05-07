using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrEmployeeVacation : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int VacationId { get; set; }
        public virtual HrVacation Vacation { get; set; }
        public int NodDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SubstituteEmpolyeeId { get; set; }
        public virtual HrEmployee SubstituteEmpolyee { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        // Navigation Primary




    }
}
