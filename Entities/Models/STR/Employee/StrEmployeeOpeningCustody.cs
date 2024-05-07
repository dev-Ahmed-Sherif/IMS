using Entities.Models.Cc;
using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Employee
{
    public class StrEmployeeOpeningCustody : EntityBase
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        [StringLength(150)]
        public string Notes { get; set; }

        //navigate foreignkey
        public int? EmployeeId { get; set; }
        public virtual HrEmployee HR_Employee { get; set; }
        public int? CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear Fiscalyear { get; set; }
        //navigate primaryKey
        public virtual ICollection<StrEmployeeOpeningCustodyDetails> STR_Employee_Opening_Custody_Details { get; set; }

        //----------------------------------------------------------------------------------------------//
        // Relation { PrUser => StrEmployeeOpeningCustody } +++ {View Model => TransactionUserId} 
        //---------------------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public string Attachment { get; set; }

    }
}
