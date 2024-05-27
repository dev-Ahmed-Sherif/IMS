using Microsoft.AspNetCore.Http;
using System;

namespace Entities.ViewModels
{
    public class HrEmployeeQualificationGeneralVM
    {

        public DateTime Date { get; set; }
        public string Attachment { get; set; }
        public IFormFile File { get; set; }
       
        public int QualificationId { get; set; }
        public int QualificationLevelId { get; set; }
        public int SpecializationId { get; set; }
        public int EmployeeId { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrEmployeeQualificationVM : HrEmployeeQualificationGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrEmployeeQualificationGetVM : HrEmployeeQualificationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualificationName { get; set; }
        public string QualificationLeveName { get; set; }
        public string SpecializationName { get; set; }
        public string EmployeeName { get; set; }

    }
    public class HrEmployeeQualificationGetSearch : HrEmployeeQualificationGetVM
    {

        public string ShortDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }





    public class HrEmployeeQualificationSearch
    {
        public DateTime? Date { get; set; }
        public string Attachment { get; set; }
        public string QualificationId { get; set; }
        public string QualificationLevelId { get; set; }
        public string SpecializationId { get; set; }
        public string EmployeeId { get; set; }
        public string TransactionUserId { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualificationName { get; set; }
        public string QualificationLeveName { get; set; }
        public string SpecializationName { get; set; }
        public string EmployeeName { get; set; }

    }
    public class HrEmployeeQualificationReport : HrEmployeeQualificationSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }

}
