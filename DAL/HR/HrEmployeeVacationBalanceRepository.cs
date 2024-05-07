using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeVacationBalanceRepository
    {

        private AppDbContext _context;
        public HrEmployeeVacationBalanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            try
            {
                var _EmployeeVacationBalance = new HrEmployeeVacationBalance()
                {
                    Name = EmployeeVacationBalance.name,
                    EmployeeId = EmployeeVacationBalance.EmployeeId,
                    VacationId = EmployeeVacationBalance.VactionId,
                    Year = EmployeeVacationBalance.Year,
                    Balance = EmployeeVacationBalance.Balance,
                    CreatedByID = EmployeeVacationBalance.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeVacationBalance.Add(_EmployeeVacationBalance);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            try
            {
                var _EmployeeVacationBalance = _context.HrEmployeeVacationBalance.FirstOrDefault(n => n.Id == EmployeeVacationBalance.Id);
                if (_EmployeeVacationBalance != null)
                {
                    _EmployeeVacationBalance.Name = EmployeeVacationBalance.name;
                    _EmployeeVacationBalance.EmployeeId = EmployeeVacationBalance.EmployeeId;
                    _EmployeeVacationBalance.VacationId = EmployeeVacationBalance.VactionId;
                    _EmployeeVacationBalance.Year = EmployeeVacationBalance.Year;
                    _EmployeeVacationBalance.Balance = EmployeeVacationBalance.Balance;
                    _EmployeeVacationBalance.UpdateByID = EmployeeVacationBalance.TransactionUserId;
                    _EmployeeVacationBalance.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeVacationBalanceId)
        {
            try
            {
                var _EmployeeVacationBalance = _context.HrEmployeeVacationBalance.FirstOrDefault(n => n.Id == EmployeeVacationBalanceId);
                if (_EmployeeVacationBalance != null)
                {
                    _context.HrEmployeeVacationBalance.Remove(_EmployeeVacationBalance);
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


        public List<HrEmployeeVacationBalanceGetVM> GetAll() => _context.HrEmployeeVacationBalance.Select(n => new HrEmployeeVacationBalanceGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, EmployeeId = n.EmployeeId, VactionId = n.VacationId, Year = n.Year, Balance = n.Balance, EmployeeName = n.Employee.Name, VactionName = n.Vacation.Name }).ToList();
        public HrEmployeeVacationBalanceGetVM GetById(int EmployeeVacationBalanceId) => _context.HrEmployeeVacationBalance.Select(n => new HrEmployeeVacationBalanceGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, EmployeeId = n.EmployeeId, VactionId = n.VacationId, Year = n.Year, Balance = n.Balance, EmployeeName = n.Employee.Name, VactionName = n.Vacation.Name }).FirstOrDefault(n => n.Id == EmployeeVacationBalanceId);

    }
}
