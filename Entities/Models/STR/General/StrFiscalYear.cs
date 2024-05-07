using Entities.Models.PR;
using Entities.Models.STR.Add;
using Entities.Models.STR.Employee;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using System;
using System.Collections.Generic;
//using Entities.Models.TR.Excuted;
//using Entities.Models.TR.Plan;

namespace Entities.Models.STR.General
{
    public class StrFiscalYear : EntityBase
    {
        public string fiscalyear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<StrOpeningStock> str_opening_stock_fiscalyear { get; set; }
        public virtual ICollection<StrEmployeeExchange> str_employee_exchange_fiscalyear { get; set; }
        public virtual ICollection<StrEmployeeOpeningCustody> str_employee_opening_Custody_fiscalyear { get; set; }
        public virtual ICollection<StrWithDraw> str_with_Draw_fiscalyear { get; set; }
        public virtual ICollection<StrAdd> str_add_fiscalyear { get; set; }
        //public List<TrExcuted> TrExcutedfiscalyear { get; set; }
        //public List<TrPlan> TrPlanfiscalyear { get; set; }
        //--------------------------------------------------------------------------//
        // Relation { PrUser => StrFiscalYear } +++ {View Model => TransactionUserId} 
        //-------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
