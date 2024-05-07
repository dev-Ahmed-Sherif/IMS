using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class HrIncentiveAllowance : EntityBase
    {

        [StringLength(50)]

        public int No { get; set; }

        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }

        public int FiscalYearId { get; set; }

        public virtual StrFiscalYear FiscalYear { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary




    }
}
