using System;
using System.Collections.Generic;

namespace Entities.ViewModels.STR.Employee
{

    public class StrEmployeeExchangeDetailsGeneralVM
    {
        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string State { get; set; }

        public decimal Percentage { get; set; }
        public string Notes { get; set; }
        public int ItemId { get; set; }
        //public int? ProductId { get; set; }
        public int Employee_ExchangeId { get; set; }
        public int TransactionUserId { get; set; }



    }
    public class StrEmployeeExchangeDetailsVM : StrEmployeeExchangeDetailsGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeExchangeDetailsGetVM : StrEmployeeExchangeDetailsVM
    {
        public string ItemName { get; set; }
        public string FullCode { get; set; }
        //public string ProductName { get; set; }
        public int Employee_ExchangeNO { get; set; }
        public string CreateUserName { get; set; }
        //add header Data
        public string HeaderEmployeeName { get; set; }
        public string DestEmployeeName { get; set; }
        public string HeaderDestEmployeeName { get; set; }
        public string HeaderCostCenterName { get; set; }
        public string HeaderCreateUserName { get; set; }
        public string HeaderFiscalYear { get; set; }
        public string HeaderItemName { get; set; }
        public DateTime HeaderDate { get; set; }
        public string ShortHeaderDate { get; set; }
        public string ReportDate { get; set; }
        public int HeaderNo { get; set; }
        public int HeaderTotal { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Unit {  get; set; }
    }
    public class GetEmployeeExchangeDetailsByEmployeeExchangeId
    {
        public StrEmployeeExchangeGetVM StrEmployeeExchangeGetVM { get; set; }
        public List<StrEmployeeExchangeDetailsGetVM> StrEmployeeExchangeDetailsGetVM { get; set; }
    }
}
