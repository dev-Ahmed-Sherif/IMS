using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.STR.Employee
{
    public class StrEmployeeOpeningCustodyGeneralVM
    {

        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string Notes { get; set; }
        public int? EmployeeId { get; set; }
        public int? CostCenterId { get; set; }
        public int TransactionUserId { get; set; }
        public int FiscalYearId { get; set; }
        public IFormFile File { get; set; }

    }
    public class StrEmployeeOpeningCustodyVM : StrEmployeeOpeningCustodyGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeOpeningCustodyGetVM : StrEmployeeOpeningCustodyVM
    {
        public string EmployeeName { get; set; }
        public string CostCenterName { get; set; }
        public string CreateUserName { get; set; }
        public string fiscalyear { get; set; }
        public string ShortDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> StrEmployeeOpeningCustodyDetailsGetVM { get; set; }
    }
    public class searchemployeeopeningcustody
    {


        // public DateTime? Date { get; set; }
        public int? No { get; set; }
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CostCenterId { get; set; }
        public int? ItemId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? FiscalYearId { get; set; }
        public int? SectionId { get; set; }

    }
    public class reportemployeeopeningcustody : searchemployeeopeningcustody
    {

        public string reportName { get; set; }
        public string reportType { get; set; }



    }

}
