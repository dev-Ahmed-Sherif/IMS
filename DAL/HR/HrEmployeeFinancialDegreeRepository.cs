using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeFinancialDegreeRepository
    {

        private AppDbContext _context;
        public HrEmployeeFinancialDegreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeFinancialDegreeVM EmployeeFinancialDegree)
        {
            try
            {
                var _EmployeeFinancialDegree = new HrEmployeeFinancialDegree()
                {

                    FinancialDegreeId = EmployeeFinancialDegree.FinancialDegreeId,
                    FinancialDegreeDate = EmployeeFinancialDegree.FinancialDegreeDate,
                    CreatedByID = EmployeeFinancialDegree.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.EmployeeFinancialDegree.Add(_EmployeeFinancialDegree);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeFinancialDegreeVM EmployeeFinancialDegree)
        {
            try
            {
                var _EmployeeFinancialDegree = _context.EmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegree.Id);
                if (_EmployeeFinancialDegree != null)
                {

                    _EmployeeFinancialDegree.FinancialDegreeDate = EmployeeFinancialDegree.FinancialDegreeDate;
                    _EmployeeFinancialDegree.FinancialDegreeId = EmployeeFinancialDegree.FinancialDegreeId;

                    _EmployeeFinancialDegree.UpdateByID = EmployeeFinancialDegree.TransactionUserId;

                    _EmployeeFinancialDegree.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeFinancialDegreeId)
        {
            try
            {
                var _EmployeeFinancialDegree = _context.EmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
                if (_EmployeeFinancialDegree != null)
                {
                    _context.EmployeeFinancialDegree.Remove(_EmployeeFinancialDegree);
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


        public List<HrEmployeeFinancialDegreeGetVM> GetAll() => _context.EmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name }).ToList();
        public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.EmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);

    }
}
