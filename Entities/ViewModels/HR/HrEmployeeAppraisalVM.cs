using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities.ViewModels
{
    public class HrEmployeeAppraisalGeneralVM
    {
        public DateTime Date { get; set; }
        public int Appraisal { get; set; }

        public string Attachment { get; set; }
        public IFormFile File { get; set; }
        public int EmployeeId { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class HrEmployeeAppraisalVM : HrEmployeeAppraisalGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrEmployeeAppraisalGetVM : HrEmployeeAppraisalVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public int QualificationLevelId { get; set; }
        public DateTime Birth_Date { get; set; }


    }
    public class searchEmpAppr
    {
        public int? Id { get; set; }
        public int? Appraisal { get; set; }
        public int? EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int? SectionId { get; set; }
    }

    public class HrEmployeeAppraisalGetSearchVM : HrEmployeeAppraisalGetVM
    {
       public string? ShortDate { get; set; }
       public string? ReportDate { get; set; }

       public string Section { get; set; }

}
    public class HrEmployeeAppraisalReport : searchEmpAppr
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

    }
}
