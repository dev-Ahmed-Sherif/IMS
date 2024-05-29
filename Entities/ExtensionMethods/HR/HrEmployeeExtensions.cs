using Entities.Models.HR;
using Entities.ViewModels.HR;

namespace Entities.ExtensionMethods.HR
{
    public static class HrEmployeeExtensions
    {
        public static HrEmployeeGetVM ToHrEmployeeGetVM(this HrEmployee n)
        {
            return new HrEmployeeGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Phone = n.Phone ?? "",
                Email = n.Email ?? "",
                Code = n.Code ?? "",
                National_Code = n.National_Code,
                Birth_Date = n.Birth_Date,
                Address = n.Address ?? "",
                QualificationDate = n.QualificationDate,
                HiringDate = n.HiringDate,
                WorkingStateDate = n.WorkingStateDate,
                FinancialDegreeDate = n.FinancialDegreeDate,
                Gender = n.Gender ?? "",
                MaritalState = n.MaritalState,
                QualificationId = n.QualificationId,
                QualificationName = n.Qualification?.Name ?? "",
                QualificationLevelId = n.QualificationLevelId,
                QualificationLevelName = n.Qualification?.Name ?? "",
                SpecializationId = n.SpecializationId,
                SpecializationName = n.Specialization?.Name ?? "",
                JobTitleId = n.JobTitleId,
                JobTitleName = n.JobTitle?.Name ?? "",
                PositionId = n.PositionId,
                PositionName = n.Position?.Name ?? "",
                MillitryStateId = n.MillitryStateId,
                MillitryStateName = n.MillitryState?.Name ?? "",
                HiringTypeId = n.HiringTypeId,
                BankId = n.BankId,
                PayMethodId = n.PayMethodId,
                Religion = n.Religion ?? "",
                SalaryStatusId = n.SalaryStatusId,
                HiringTypeName = n.HiringType?.Name ?? "",
                FinancialDegreeId = n.FinancialDegreeId,
                FinancialDegreeName = n.FinancialDegree?.Name ?? "",
                CityStateId = n.CityStateId,
                CityStateName = n.CityState?.Name ?? "",
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace?.Name ?? "",
                DepartmentId = n.DepartmentId,
                DepartmentName = n.Department?.Name,
                SeveranceReasonId = n.SeveranceReasonId,
                SeveranceReasonName = n.SeveranceReason?.Name,
                CreateUserName = n.CreatedBy?.Name ?? "",
                TransactionUserId = n.CreatedBy?.Id ?? default,
                UpdateUserName = n.UpdateBy?.Name
            };
        }
        public static HrEmployeeGetSearchVM ToHrEmployeeGetSearchVM(this HrEmployee n)
        {
            return new HrEmployeeGetSearchVM
            {
                Id = n.Id,
                Name = n.Name,
                Phone = n.Phone,
                Email = n.Email,
                Code = n.Code,
                National_Code = n.National_Code,
                Birth_Date = n.Birth_Date,
                Address = n.Address,
                QualificationDate = n.QualificationDate,
                HiringDate = n.HiringDate,
                WorkingStateDate = n.WorkingStateDate,
                FinancialDegreeDate = n.FinancialDegreeDate,
                Gender = n.Gender,
                MaritalState = n.MaritalState,
                QualificationId = n.QualificationId,
                QualificationName = n.Qualification?.Name,
                QualificationLevelId = n.QualificationLevelId,
                QualificationLevelName = n.Qualification?.Name,
                SpecializationId = n.SpecializationId,
                SpecializationName = n.Specialization?.Name,
                JobTitleId = n.JobTitleId,
                JobTitleName = n.JobTitle?.Name,
                PositionId = n.PositionId,
                PositionName = n.Position?.Name,
                MillitryStateId = n.MillitryStateId,
                MillitryStateName = n.MillitryState?.Name,
                HiringTypeId = n.HiringTypeId,
                HiringTypeName = n.HiringType?.Name,
                FinancialDegreeId = n.FinancialDegreeId,
                FinancialDegreeName = n.FinancialDegree?.Name,
                CityStateId = n.CityStateId,
                CityStateName = n.CityState?.Name,
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace?.Name,
                DepartmentId = n.DepartmentId,
                DepartmentName = n.Department?.Name,
                SeveranceReasonId = n.SeveranceReasonId,
                SeveranceReasonName = n.SeveranceReason?.Name,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? default,
                UpdateUserName = n.UpdateBy?.Name,
                Birth_DateShort = n.Birth_Date.ToString("dd/MM/yyyy"),
                FinancialDegreeDateShort = n.FinancialDegreeDate.ToString("dd/MM/yyyy"),
                HiringDateShort = n.HiringDate.ToString("dd/MM/yyyy"),
                QualificationDateShort = n.QualificationDate.ToString("dd/MM/yyyy"),
                WorkingStateDateShort = n.WorkingStateDate.ToString("dd/MM/yyyy"),
            };
        }
    }
}
