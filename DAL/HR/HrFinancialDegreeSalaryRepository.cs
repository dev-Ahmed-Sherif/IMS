using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrFinancialDegreeSalaryRepository
    {
        private AppDbContext _context;
        public HrFinancialDegreeSalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrFinancialDegreeSalaryVM FinancialDegreeSalary)
        {
            try
            {
                var _FinancialDegreeSalary = new HrFinancialDegreeSalary()
                {
                    Name = FinancialDegreeSalary.name,
                    Salary = FinancialDegreeSalary.Salary,
                    Date = FinancialDegreeSalary.Date,
                    FinancialDegreeId = FinancialDegreeSalary.FinancialDegreeId,






                    CreatedByID = FinancialDegreeSalary.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrFinancialDegreeSalary.Add(_FinancialDegreeSalary);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrFinancialDegreeSalaryVM FinancialDegreeSalary)
        {
            try
            {
                var _FinancialDegreeSalary = _context.HrFinancialDegreeSalary.FirstOrDefault(n => n.Id == FinancialDegreeSalary.Id);
                if (_FinancialDegreeSalary != null)
                {
                    _FinancialDegreeSalary.Name = FinancialDegreeSalary.name;
                    _FinancialDegreeSalary.Salary = FinancialDegreeSalary.Salary;
                    _FinancialDegreeSalary.Date = FinancialDegreeSalary.Date;
                    _FinancialDegreeSalary.FinancialDegreeId = FinancialDegreeSalary.FinancialDegreeId;






                    _FinancialDegreeSalary.UpdateByID = FinancialDegreeSalary.TransactionUserId;

                    _FinancialDegreeSalary.LastUpdateDate = DateTime.Now;

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

        public string Delete(int FinancialDegreeSalaryId)
        {
            try
            {
                var _FinancialDegreeSalary = _context.HrFinancialDegreeSalary.FirstOrDefault(n => n.Id == FinancialDegreeSalaryId);
                if (_FinancialDegreeSalary != null)
                {
                    _context.HrFinancialDegreeSalary.Remove(_FinancialDegreeSalary);
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


        public List<HrFinancialDegreeSalaryGetVM> GetAll() => _context.HrFinancialDegreeSalary.Select(n => new HrFinancialDegreeSalaryGetVM { Id = n.Id, name = n.Name, Salary = n.Salary, Date = n.Date, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeName = n.FinancialDegree.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrFinancialDegreeSalaryGetVM GetById(int FinancialDegreeSalaryId) => _context.HrFinancialDegreeSalary.Select(n => new HrFinancialDegreeSalaryGetVM { Id = n.Id, name = n.Name, Salary = n.Salary, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == FinancialDegreeSalaryId);

    }


}

