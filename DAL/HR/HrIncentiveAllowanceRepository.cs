using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class HrIncentiveAllowanceRepository
    {

        private AppDbContext _context;
        public HrIncentiveAllowanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrIncentiveAllowanceVM IncentiveAllowance)
        {
            try
            {
                var _IncentiveAllowance = new HrIncentiveAllowance()
                {
                    No = IncentiveAllowance.No,
                    Date = IncentiveAllowance.Date,
                    EmployeeId = IncentiveAllowance.EmployeeId,
                    FiscalYearId = IncentiveAllowance.FiscalYearId,


                    CreatedByID = IncentiveAllowance.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrIncentiveAllowance.Add(_IncentiveAllowance);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrIncentiveAllowanceVM IncentiveAllowance)
        {
            try
            {
                var _IncentiveAllowance = _context.HrIncentiveAllowance.FirstOrDefault(n => n.Id == IncentiveAllowance.Id);
                if (_IncentiveAllowance != null)
                {
                    _IncentiveAllowance.No = IncentiveAllowance.No;
                    _IncentiveAllowance.Date = IncentiveAllowance.Date;
                    _IncentiveAllowance.EmployeeId = IncentiveAllowance.EmployeeId;
                    _IncentiveAllowance.FiscalYearId = IncentiveAllowance.FiscalYearId;


                    _IncentiveAllowance.UpdateByID = IncentiveAllowance.TransactionUserId;

                    _IncentiveAllowance.LastUpdateDate = DateTime.Now;

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

        public string Delete(int IncentiveAllowanceId)
        {
            try
            {
                var _IncentiveAllowance = _context.HrIncentiveAllowance.FirstOrDefault(n => n.Id == IncentiveAllowanceId);
                if (_IncentiveAllowance != null)
                {
                    _context.HrIncentiveAllowance.Remove(_IncentiveAllowance);
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


        public List<HrIncentiveAllowanceGetVM> GetAll() => _context.HrIncentiveAllowance.Select(n => new HrIncentiveAllowanceGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, No = n.No, Date = n.Date, EmployeeId = n.EmployeeId, FiscalYearId = n.FiscalYearId, FiscalYearName = n.FiscalYear.fiscalyear, Employeename = n.Employee.Name }).ToList();
        public HrIncentiveAllowanceGetVM GetById(int IncentiveAllowanceId) => _context.HrIncentiveAllowance.Select(n => new HrIncentiveAllowanceGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, No = n.No, Date = n.Date, EmployeeId = n.EmployeeId, FiscalYearId = n.FiscalYearId, FiscalYearName = n.FiscalYear.fiscalyear, Employeename = n.Employee.Name }).FirstOrDefault(n => n.Id == IncentiveAllowanceId);

    }
}
