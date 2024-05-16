using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeVacationRepository

    {

        private AppDbContext _context;
        public HrEmployeeVacationRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeVacationVM EmployeeVacation)
        {
            try
            {
                var _EmployeeVacation = new HrEmployeeVacation()
                {
                    Name = EmployeeVacation.name,
                    EmployeeId = EmployeeVacation.EmplpoyeeId,
                    SubstituteEmpolyeeId = EmployeeVacation.SubstituteEmpolyeeId,
                    VacationId = EmployeeVacation.VacationId,
                    NodDays = EmployeeVacation.NodDays,
                    StartDate = EmployeeVacation.StartDate,
                    EndDate = EmployeeVacation.EndDate,

                    CreatedByID = EmployeeVacation.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeVacation.Add(_EmployeeVacation);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeVacationVM EmployeeVacation)
        {
            try
            {
                var _EmployeeVacation = _context.HrEmployeeVacation.FirstOrDefault(n => n.Id == EmployeeVacation.Id);
                if (_EmployeeVacation != null)
                {
                    _EmployeeVacation.Name = EmployeeVacation.name;
                    _EmployeeVacation.EmployeeId = EmployeeVacation.EmplpoyeeId;
                    _EmployeeVacation.SubstituteEmpolyeeId = EmployeeVacation.SubstituteEmpolyeeId;
                    _EmployeeVacation.VacationId = EmployeeVacation.VacationId;
                    _EmployeeVacation.NodDays = EmployeeVacation.NodDays;
                    _EmployeeVacation.StartDate = EmployeeVacation.StartDate;
                    _EmployeeVacation.EndDate = EmployeeVacation.EndDate;

                    _EmployeeVacation.UpdateByID = EmployeeVacation.TransactionUserId;
                    _EmployeeVacation.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeVacationId)
        {
            try
            {
                var _EmployeeVacation = _context.HrEmployeeVacation.FirstOrDefault(n => n.Id == EmployeeVacationId);
                if (_EmployeeVacation != null)
                {
                    _context.HrEmployeeVacation.Remove(_EmployeeVacation);
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


        public List<HrEmployeeVacationGetVM> GetAll() => _context.HrEmployeeVacation.Select(n => new HrEmployeeVacationGetVM { Id = n.Id, name = n.Name, NodDays = n.NodDays, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, EmplpoyeeId = n.EmployeeId, VacationId = n.VacationId, EmplpoyeeName = n.Employee.Name, SubstituteEmpolyeeId = n.SubstituteEmpolyeeId, SubstituteEmpolyeeName = n.SubstituteEmpolyee.Name, VacationName = n.Vacation.Name, EndDate = n.EndDate, StartDate = n.StartDate }).ToList();
        public HrEmployeeVacationGetVM GetById(int EmployeeVacationId) => _context.HrEmployeeVacation.Select(n => new HrEmployeeVacationGetVM { Id = n.Id, name = n.Name, NodDays = n.NodDays, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, EmplpoyeeId = n.EmployeeId, VacationId = n.VacationId, EmplpoyeeName = n.Employee.Name, SubstituteEmpolyeeId = n.SubstituteEmpolyeeId, SubstituteEmpolyeeName = n.SubstituteEmpolyee.Name, VacationName = n.Vacation.Name, EndDate = n.EndDate, StartDate = n.StartDate }).Single(n => n.Id == EmployeeVacationId);
        public List<HrEmployeeVacationGetSearch> Search(HrEmployeeVacationSearch searchModel)
        {
            var query = _context.HrEmployeeVacation.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.name));
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.Contains(searchModel.EmployeeName));
            }
            if (!string.IsNullOrEmpty(searchModel.VacationName))
            {
                query = query.Where(p => p.Vacation.Name.Contains(searchModel.VacationName));
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeId))
            {
                query = query.Where(p => p.EmployeeId.ToString().Contains(searchModel.EmployeeId));
            }
            if (!string.IsNullOrEmpty(searchModel.VacationId))
            {
                query = query.Where(p => p.VacationId.ToString().Contains(searchModel.VacationId));
            }
            if (!string.IsNullOrEmpty(searchModel.SubstituteEmpolyeeName))
            {
                query = query.Where(p => p.SubstituteEmpolyee.Name.Contains(searchModel.SubstituteEmpolyeeName));

            }
            if (!string.IsNullOrEmpty(searchModel.SubstituteEmpolyeeId))
            {
                query = query.Where(p => p.SubstituteEmpolyeeId.ToString().Contains(searchModel.SubstituteEmpolyeeId));
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.StartDate >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.EndDate <= searchModel.EndDate.Value.Date);

            }
            var result = query.Select(n => new HrEmployeeVacationGetSearch
            {
                Id = n.Id,
                name = n.Name,
                NodDays = n.NodDays,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmplpoyeeId = n.EmployeeId,
                VacationId = n.VacationId,
                EmplpoyeeName = n.Employee.Name,
                SubstituteEmpolyeeId = n.SubstituteEmpolyeeId,
                SubstituteEmpolyeeName = n.SubstituteEmpolyee.Name,
                VacationName = n.Vacation.Name,
                ShortEndDate = n.EndDate.ToString("dd/MM/yyyy"),
                ShortStartDate = n.StartDate.ToString("dd/MM/yyyy"),


            }).ToList();
            return result;


        }
    }
}

