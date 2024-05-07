using Entities.Models.HR;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class HrEmployeeDisciplinary : EntityBase
    {
        [StringLength(50)]

        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int DisciplinaryId { get; set; }

        public virtual HrDisciplinary Disciplinary { get; set; }
        public DateTime Date { get; set; }
        public int No { get; set; }

        public int NoDays { get; set; }
        public string Description { get; set; }


        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary




    }
}
