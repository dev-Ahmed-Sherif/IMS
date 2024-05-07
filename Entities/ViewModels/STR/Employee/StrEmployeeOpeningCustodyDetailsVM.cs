using System;
using System.Collections.Generic;

namespace Entities.ViewModels.STR.Employee
{
    public class StrEmployeeOpeningCustodyDetailsGeneralVM
    {

        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int Total { get; set; }
        public string State { get; set; }
        public int Percentage { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public int CustodyId { get; set; }
        public int ItemId { get; set; }
        //public int? ProductId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrEmployeeOpeningCustodyDetailsVM : StrEmployeeOpeningCustodyDetailsGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeOpeningCustodyDetailsGetVM : StrEmployeeOpeningCustodyDetailsVM
    {
        public string ItemName { get; set; }
        public string FullCode { get; set; }
        //public string ProductName { get; set; }
        public int CustodyNO { get; set; }
        public string CreateUserName { get; set; }
        //add header Data
        public string HeaderEmployeeName { get; set; }
        public string HeaderCostCenterName { get; set; }
        public string HeaderCreateUserName { get; set; }
        public string HeaderFiscalYear { get; set; }
        public DateTime HeaderDate { get; set; }
        public string ShortHeaderDate { get; set; }
        public string ReportDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int HeaderNo { get; set; }
        public int HeaderTotal { get; set; }
        public string Section { get; set; }
        public string Unit { get; set; }
    }
    public class GetEmployeeOpeningCustodyDetailsByStrEmployeeOpeningCustodyId
    {
        public StrEmployeeOpeningCustodyGetVM StrEmployeeOpeningCustodyGetVM { get; set; }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> StrEmployeeOpeningCustodyDetailsGetVM { get; set; }
    }
}
