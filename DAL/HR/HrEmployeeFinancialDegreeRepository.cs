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
                    EmployeeId = EmployeeFinancialDegree.EmployeeId,
                    FinancialDegreeId = EmployeeFinancialDegree.FinancialDegreeId,
                    FinancialDegreeDate = EmployeeFinancialDegree.FinancialDegreeDate,
                    CreatedByID = EmployeeFinancialDegree.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeFinancialDegree.Add(_EmployeeFinancialDegree);
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
                var _EmployeeFinancialDegree = _context.HrEmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegree.Id);
                if (_EmployeeFinancialDegree != null)
                {
                    _EmployeeFinancialDegree.EmployeeId = EmployeeFinancialDegree.EmployeeId;
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
                var _EmployeeFinancialDegree = _context.HrEmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
                if (_EmployeeFinancialDegree != null)
                {
                    _context.HrEmployeeFinancialDegree.Remove(_EmployeeFinancialDegree);
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


        public List<HrEmployeeFinancialDegreeGetVM> GetAll() => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name,EmployeeId=n.EmployeeId,EmployeeCode=n.Employee.Code,EmployeeName=n.Employee.Name }).ToList();
        public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
        public List<HrEmployeeFinancialDegreeGetSearchVM> Search(HrEmployeeFinancialDegreeSearch searchModel)
        {
            var query = _context.HrEmployeeFinancialDegree.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.FinancialDegreeId))
            {
                query = query.Where(p => p.FinancialDegreeId.ToString().Contains(searchModel.FinancialDegreeId));
            }
            if (!string.IsNullOrEmpty(searchModel.CreateUserName))
            {
                query = query.Where(p => p.CreatedBy.Name.ToString().Contains(searchModel.CreateUserName));
            }
            if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
            {
                query = query.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));

            }
            if (!string.IsNullOrEmpty(searchModel.UpdateUserName))
            {
                query = query.Where(p => p.UpdateBy.Name.Contains(searchModel.UpdateUserName));
            }

            if (searchModel.FinancialDegreeDate.HasValue)
            {
                query = query.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);

            }

            if (!string.IsNullOrEmpty(searchModel.EmployeeId))
            {
                query = query.Where(p => p.Employee.Id.ToString().Equals(searchModel.EmployeeId));
            }

            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.ToString().Equals(searchModel.EmployeeId));
            }



            var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                FinancialDegreeId = n.FinancialDegreeId,
                FinancialDegreeDate = n.FinancialDegreeDate,
                FinancialDegreeName = n.FinancialDegree.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName=n.Employee.Name,
                EmployeeCode = n.Employee.Code,
                FinancialDegreeShortDate = n.FinancialDegreeDate.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                //Section =n.

            }).ToList();




            return result;

        }
    }

}
