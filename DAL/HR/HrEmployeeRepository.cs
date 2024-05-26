using Entities.ExtensionMethods.HR;
using Entities.Models.HR;
using Entities.ViewModels;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeRepository
    {
        private AppDbContext _context;
        public HrEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(HrEmployeeVM employee)
        {
            try
            {
                var _employee = new HrEmployee()
                {
                    Name = employee.Name,
                    Code = employee.Code,
                    National_Code = employee.National_Code,
                    Birth_Date = employee.Birth_Date,
                    Address = employee.Address,
                    QualificationDate = employee.QualificationDate,
                    HiringDate = employee.HiringDate,
                    WorkingStateDate = employee.WorkingStateDate,
                    FinancialDegreeDate = employee.FinancialDegreeDate,
                    Gender = employee.Gender,
                    MaritalState = employee.MaritalState,
                    QualificationId = employee.QualificationId,
                    QualificationLevelId = employee.QualificationLevelId,
                    SpecializationId = employee.SpecializationId,
                    JobTitleId = employee.JobTitleId,
                    PositionId = employee.PositionId,
                    MillitryStateId = employee.MillitryStateId,
                    HiringTypeId = employee.HiringTypeId,
                    FinancialDegreeId = employee.FinancialDegreeId,
                    CityStateId = employee.CityStateId,
                    WorkPlaceId = employee.WorkPlaceId,
                    DepartmentId = employee.DepartmentId,
                    SeveranceReasonId = employee.SeveranceReasonId,
                    BankId = employee.BankId,
                    PayMethodId = employee.PayMethodId,
                    ReligionId = employee.ReligionId,
                    SalaryStatusId = employee.SalaryStatusId,

                    CreatedByID = employee.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployee.Add(_employee);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(HrEmployeeVM employee)
        {
            try
            {
                var _employee = _context.HrEmployee.FirstOrDefault(n => n.Id == employee.Id);
                if (_employee != null)
                {
                    _employee.Name = employee.Name;
                    _employee.Code = employee.Code;
                    _employee.National_Code = employee.National_Code;
                    _employee.Birth_Date = employee.Birth_Date;
                    _employee.Address = employee.Address;
                    _employee.QualificationDate = employee.QualificationDate;
                    _employee.HiringDate = employee.HiringDate;
                    _employee.WorkingStateDate = employee.WorkingStateDate;
                    _employee.FinancialDegreeDate = employee.FinancialDegreeDate;
                    _employee.Gender = employee.Gender;
                    _employee.MaritalState = employee.MaritalState;
                    _employee.QualificationId = employee.QualificationId;
                    _employee.QualificationLevelId = employee.QualificationLevelId;
                    _employee.SpecializationId = employee.SpecializationId;
                    _employee.JobTitleId = employee.JobTitleId;
                    _employee.PositionId = employee.PositionId;
                    _employee.MillitryStateId = employee.MillitryStateId;
                    _employee.HiringTypeId = employee.HiringTypeId;
                    _employee.FinancialDegreeId = employee.FinancialDegreeId;
                    _employee.CityStateId = employee.CityStateId;
                    _employee.WorkPlaceId = employee.WorkPlaceId;
                    _employee.DepartmentId = employee.DepartmentId;
                    _employee.SeveranceReasonId = employee.SeveranceReasonId;
                    _employee.BankId = employee.BankId;
                    _employee.PayMethodId = employee.PayMethodId;
                    _employee.ReligionId = employee.ReligionId;
                    _employee.SalaryStatusId = employee.SalaryStatusId;
                    _employee.UpdateByID = employee.TransactionUserId;
                    _employee.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be updated";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Delete(int employeeId)
        {
            try
            {
                var _employee = _context.HrEmployee.FirstOrDefault(n => n.Id == employeeId);
                if (_employee != null)
                {
                    _context.HrEmployee.Remove(_employee);
                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<HrEmployeeGetVM> GetAll()
        {
            return _context.HrEmployee.Select(n => n.ToHrEmployeeGetVM()).ToList();
        }

        public HrEmployeeGetVM GetById(int employeeId)
        {
            var Employee = _context.HrEmployee.FirstOrDefault(n => n.Id == employeeId) ?? throw new Exception("Employee Not Found");
            return Employee.ToHrEmployeeGetVM();
        }

        public List<HrEmployeeGetVM> GetByName(string Name)
        {
            return _context.HrEmployee
                .Where(n => n.Name.Contains(Name))
                .Select(n => n.ToHrEmployeeGetVM())
               .ToList();
        }

        public List<HrEmployeeGetSearchVM> Search(HrSearch searchModel)
        {
            var query = _context.HrEmployee.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Code))
            {
                query = query.Where(p => p.Code.Contains(searchModel.Code));
            }
            if (!string.IsNullOrEmpty(searchModel.National_Code))
            {
                query = query.Where(p => p.National_Code.Contains(searchModel.National_Code));
            }
            if (!string.IsNullOrEmpty(searchModel.Address))
            {
                query = query.Where(p => p.Address.Contains(searchModel.Address));
            }
            if (!string.IsNullOrEmpty(searchModel.Phone))
            {
                query = query.Where(p => p.Phone.Contains(searchModel.Phone));
            }
            if (!string.IsNullOrEmpty(searchModel.Email))
            {
                query = query.Where(p => p.Email.Contains(searchModel.Email));
            }
            if (!string.IsNullOrEmpty(searchModel.Gender))
            {
                query = query.Where(p => p.Gender.Contains(searchModel.Gender));
            }
            if (!string.IsNullOrEmpty(searchModel.MaritalState))
            {
                query = query.Where(p => p.MaritalState.Contains(searchModel.MaritalState));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationName))
            {
                query = query.Where(p => p.Qualification.Name.Contains(searchModel.QualificationName));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationLevelName))
            {
                query = query.Where(p => p.Qualification.Name == searchModel.QualificationLevelName);
            }
            if (!string.IsNullOrEmpty(searchModel.SpecializationName))
            {
                query = query.Where(p => p.Specialization.Name.Contains(searchModel.SpecializationName));
            }
            if (!string.IsNullOrEmpty(searchModel.JobTitleName))
            {
                query = query.Where(p => p.JobTitle.Name.Contains(searchModel.JobTitleName));
            }
            if (!string.IsNullOrEmpty(searchModel.PositionName))
            {
                query = query.Where(p => p.Position.Name.Contains(searchModel.PositionName));
            }
            if (!string.IsNullOrEmpty(searchModel.MillitryStateName))
            {
                query = query.Where(p => p.MillitryState.Name.Contains(searchModel.MillitryStateName));
            }
            if (!string.IsNullOrEmpty(searchModel.HiringTypeName))
            {
                query = query.Where(p => p.HiringType.Name.Contains(searchModel.HiringTypeName));
            }
            if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
            {
                query = query.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));
            }
            if (!string.IsNullOrEmpty(searchModel.CityStateName))
            {
                query = query.Where(p => p.CityState.Name.Contains(searchModel.CityStateName));
            }
            if (!string.IsNullOrEmpty(searchModel.WorkPlaceName))
            {
                query = query.Where(p => p.WorkPlace.Name.Contains(searchModel.WorkPlaceName));
            }
            if (!string.IsNullOrEmpty(searchModel.DepartmentName))
            {
                query = query.Where(p => p.Department.Name.Contains(searchModel.DepartmentName));
            }
            if (!string.IsNullOrEmpty(searchModel.SeveranceReasonName))
            {
                query = query.Where(p => p.SeveranceReason.Name.Contains(searchModel.SeveranceReasonName));
            }
            if (searchModel.Birth_Date.HasValue)
            {
                query = query.Where(p => p.Birth_Date >= searchModel.Birth_Date.Value.Date);
            }
            if (searchModel.QualificationDate.HasValue)
            {
                query = query.Where(p => p.QualificationDate >= searchModel.QualificationDate.Value.Date);
            }
            if (searchModel.HiringDate.HasValue)
            {
                query = query.Where(p => p.HiringDate >= searchModel.HiringDate.Value.Date);
            }
            if (searchModel.WorkingStateDate.HasValue)
            {
                query = query.Where(p => p.WorkingStateDate >= searchModel.WorkingStateDate.Value.Date);
            }
            if (searchModel.FinancialDegreeDate.HasValue)
            {
                query = query.Where(p => p.FinancialDegreeDate >= searchModel.FinancialDegreeDate.Value.Date);
            }
            var result = query.Select(n => new HrEmployeeGetSearchVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                National_Code = n.National_Code,
                Birth_Date = n.Birth_Date,
                Birth_DateShort = n.Birth_Date.ToString("dd/MM/yyyy"),
                Address = n.Address,
                QualificationDate = n.QualificationDate,
                QualificationDateShort = n.QualificationDate.ToString("dd/MM/yyyy"),
                HiringDate = n.HiringDate,
                HiringDateShort = n.HiringDate.ToString("dd/MM/yyyy"),
                WorkingStateDate = n.WorkingStateDate,
                WorkingStateDateShort = n.WorkingStateDate.ToString("dd/MM/yyyy"),
                FinancialDegreeDate = n.FinancialDegreeDate,
                FinancialDegreeDateShort = n.FinancialDegreeDate.ToString("dd/MM/yyyy"),
                Gender = n.Gender,
                MaritalState = n.MaritalState,
                QualificationId = n.QualificationId,
                QualificationName = n.Qualification.Name,
                QualificationLevelId = n.QualificationLevelId,
                QualificationLevelName = n.Qualification.Name,
                SpecializationId = n.SpecializationId,
                SpecializationName = n.Specialization.Name,
                JobTitleId = n.JobTitleId,
                JobTitleName = n.JobTitle.Name,
                PositionId = n.PositionId,
                PositionName = n.Position.Name,
                MillitryStateId = n.MillitryStateId,
                MillitryStateName = n.MillitryState.Name,
                HiringTypeId = n.HiringTypeId,
                BankId = n.BankId,
                PayMethodId = n.PayMethodId,
                ReligionId = n.ReligionId,
                SalaryStatusId = n.SalaryStatusId,
                HiringTypeName = n.HiringType.Name,
                FinancialDegreeId = n.FinancialDegreeId,
                FinancialDegreeName = n.FinancialDegree.Name,
                CityStateId = n.CityStateId,
                CityStateName = n.CityState.Name,
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace.Name,
                DepartmentId = n.DepartmentId,
                DepartmentName = n.Department.Name,
                SeveranceReasonId = n.SeveranceReasonId,
                SeveranceReasonName = n.SeveranceReason.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Section.Name,



            }).ToList();

            return result;
        }

        public PaginatedResult<HrEmployeeGetVM> GetEmployeePagianation(int page, int pageSize)
        {

            var totalCount = _context.HrEmployee.Count();
            List<HrEmployeeGetVM> HrEmployee = _context.HrEmployee
                .OrderByDescending(HrEmployee => HrEmployee.Id)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => n.ToHrEmployeeGetVM())
                .ToList();

            var paginatedResult = new PaginatedResult<HrEmployeeGetVM>
            {
                Items = HrEmployee,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }

    }
}
