using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeGeneralVM
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        public string National_Code { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime QualificationDate { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime WorkingStateDate { get; set; }
        public DateTime FinancialDegreeDate { get; set; }
        public string Gender { get; set; }
        public string MaritalState { get; set; }


        //Navigation foreign
        public int TransactionUserId { get; set; }
        public int QualificationId { get; set; }
        public int QualificationLevelId { get; set; }
        public int SpecializationId { get; set; }
        public int JobTitleId { get; set; }
        public int PositionId { get; set; }
        public int MillitryStateId { get; set; }
        public int HiringTypeId { get; set; }
        public int FinancialDegreeId { get; set; }
        public int CityStateId { get; set; }
        public int WorkPlaceId { get; set; }
        public int DepartmentId { get; set; }
        public int SeveranceReasonId { get; set; }
        public int? SalaryStatusId { get; set; }
        public string Religion { get; set; }
        public int? PayMethodId { get; set; }
        public int? BankId { get; set; }
    }
    public class HrEmployeeVM : HrEmployeeGeneralVM
    {
        public int Id { get; set; }

    }
    public class HrEmployeeGetVM : HrEmployeeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualificationName { get; set; }
        public string QualificationLevelName { get; set; }
        public string SpecializationName { get; set; }
        public string JobTitleName { get; set; }
        public string PositionName { get; set; }
        public string MillitryStateName { get; set; }
        public string HiringTypeName { get; set; }
        public string FinancialDegreeName { get; set; }
        public string CityStateName { get; set; }
        public string WorkPlaceName { get; set; }
        public string DepartmentName { get; set; }
        public string SeveranceReasonName { get; set; }
        public string? PayMethodName { get; set; }
        public string? BankName { get; set; }


    }
    public class HrEmployeeGetSearchVM : HrEmployeeGetVM
    {
        public string Birth_DateShort { get; set; }
        public string QualificationDateShort { get; set; }
        public string HiringDateShort { get; set; }
        public string WorkingStateDateShort { get; set; }
        public string FinancialDegreeDateShort { get; set; }
        public string ReportDate { get; set; }

        public string Section { get; set; }

    }
    public class HrSearch
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        public string National_Code { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Gender { get; set; }
        public string MaritalState { get; set; }
        public DateTime? QualificationDate { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? WorkingStateDate { get; set; }
        public DateTime? FinancialDegreeDate { get; set; }
        public string QualificationName { get; set; }
        public string QualificationLevelName { get; set; }
        public string SpecializationName { get; set; }
        public string JobTitleName { get; set; }
        public string PositionName { get; set; }
        public string HiringTypeName { get; set; }
        public string FinancialDegreeName { get; set; }
        public string WorkPlaceName { get; set; }
        public string DepartmentName { get; set; }
        public string MillitryStateName { get; set; }
        public string SeveranceReasonName { get; set; }
        public string CityStateName { get; set; }

    }

    public class HrReport : HrSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

    }
}
