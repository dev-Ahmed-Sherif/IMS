using Entities.Models.Cc;
using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.Employee
{
    public class StrEmployeeExchange : EntityBase
    {

        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }
        //---------------------------------------------------------------------------------------//
        // Relation Foregin Key { Grade,Item,Employee,CostCenter,FiscalYear ==> EmployeeExchange }
        //--------------------------------------------------------------------------------------//
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int DestEmployeeId { get; set; }
        public virtual HrEmployee DestEmployee { get; set; }
        public int CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear Fiscalyear { get; set; }
        //----------------------------------------------------------------------------------------------//
        // Relation { Grade,Item,EmployeeExchangeDetails } ++ { Navigation Primary => EmployeeExchangeId }
        //----------------------------------------------------------------------------------------------//
        public virtual ICollection<StrGrade> STR_Grade { get; set; }
        public virtual ICollection<StrEmployeeExchangeDetails> STR_Employee_Exchange_Details { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => EmployeeExchange } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public string Attachment { get; set; }


    }
}
