using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.STR.Employee
{
    public class StrEmployeeExchangeGeneralVM
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string Notes { get; set; }
        public int EmployeeId { get; set; }
        public int DestEmployeeId { get; set; }
        public int CostCenterId { get; set; }
        public int TransactionUserId { get; set; }
        public int FiscalYearId { get; set; }
        public IFormFile File { get; set; }


    }
    public class StrEmployeeExchangeVM : StrEmployeeExchangeGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeExchangeGetVM : StrEmployeeExchangeVM
    {
        public string EmployeeName { get; set; }
        public string DestEmployeeName { get; set; }
        public string CostCenterName { get; set; }
        public string CreateUserName { get; set; }
        public string fiscalyear { get; set; }
        public string ItemName { get; set; }
        public string ShortDate { get; set; }
        public string ReportDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Section { get; set; }
        public List<StrEmployeeExchangeDetailsGetVM> STR_Employee_Exchange_DetailsGetVM { get; set; }
    }
    public class STR_Employee_ExchangeWithDetailsVM : StrEmployeeExchangeVM
    {
        public List<StrEmployeeExchangeDetailsVM> STR_Employee_Exchange_DetailsVM { get; set; }
    }
    public class StrEmployeeExchangeGeTDetailsBymployeeExchangeIdVM : StrEmployeeExchangeGetVM
    {
        public StrEmployeeExchangeDetailsGetVM StrEmployeeExchangeDetailsGetVM { get; set; }
    }
    public class searchemployeeexchange
    {


        // public DateTime? Date { get; set; }
        public int? No { get; set; }
        public int? Id { get; set; }
        public int? DestEmployeeId { get; set; }
        public int? CostCenterId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ItemId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? FiscalYearId { get; set; }
        public int? SectionId { get; set; }

    }

    public class reportemployeeexchangesearch : searchemployeeexchange
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }

}
