using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HrEmployeeDisciplinaryRepository
    {

        private AppDbContext _context;
        public HrEmployeeDisciplinaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            try
            {
                var _EmployeeDisciplinary = new HrEmployeeDisciplinary()
                {
                    No = EmployeeDisciplinary.No,
                    Date = EmployeeDisciplinary.Date,
                    EmployeeId = EmployeeDisciplinary.EmployeeId,
                    DisciplinaryId = EmployeeDisciplinary.DisciplinaryId,
                    Description = EmployeeDisciplinary.Description,
                    NoDays = EmployeeDisciplinary.NoDays,
                    CreatedByID = EmployeeDisciplinary.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeDisciplinary.Add(_EmployeeDisciplinary);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            try
            {
                var _EmployeeDisciplinary = _context.HrEmployeeDisciplinary.FirstOrDefault(n => n.Id == EmployeeDisciplinary.Id);
                if (_EmployeeDisciplinary != null)
                {
                    _EmployeeDisciplinary.No = EmployeeDisciplinary.No;
                    _EmployeeDisciplinary.Date = EmployeeDisciplinary.Date;
                    _EmployeeDisciplinary.Description = EmployeeDisciplinary.Description;
                    _EmployeeDisciplinary.EmployeeId = EmployeeDisciplinary.EmployeeId;
                    _EmployeeDisciplinary.DisciplinaryId = EmployeeDisciplinary.DisciplinaryId;
                    _EmployeeDisciplinary.NoDays = EmployeeDisciplinary.NoDays;
                    _EmployeeDisciplinary.UpdateByID = EmployeeDisciplinary.TransactionUserId;

                    _EmployeeDisciplinary.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeDisciplinaryId)
        {
            try
            {
                var _EmployeeDisciplinary = _context.HrEmployeeDisciplinary.FirstOrDefault(n => n.Id == EmployeeDisciplinaryId);
                if (_EmployeeDisciplinary != null)
                {
                    _context.HrEmployeeDisciplinary.Remove(_EmployeeDisciplinary);
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

        public List<HrEmployeeDisciplinaryGetVM> GetAll()
            => _context.HrEmployeeDisciplinary.Select(n => new HrEmployeeDisciplinaryGetVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                No = n.No,
                Date = n.Date,
                Description = n.Description,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                DisciplinaryId = n.DisciplinaryId,
                DisciplinaryName = n.Disciplinary.Name,
                NoDays = n.NoDays
            }).ToList();
        public HrEmployeeDisciplinaryGetVM GetById(int EmployeeDisciplinaryId)
            => _context.HrEmployeeDisciplinary.Select(n => new HrEmployeeDisciplinaryGetVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                No = n.No,
                Date = n.Date,
                Description = n.Description,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                DisciplinaryId = n.DisciplinaryId,
                DisciplinaryName = n.Disciplinary.Name,
                NoDays = n.NoDays
            }).FirstOrDefault(n => n.Id == EmployeeDisciplinaryId);
        public List<HrEmployeeDisciplinaryGetSearchVM> Search(HrEmployeeDisciplinarySearch searchModel)
        {
            var query = _context.HrEmployeeDisciplinary.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.Description))
            {
                query = query.Where(p => p.Description.Contains(searchModel.Description));
            }
            if (!string.IsNullOrEmpty(searchModel.DisciplinaryId))
            {
                query = query.Where(p => p.DisciplinaryId.ToString().Contains(searchModel.DisciplinaryId));
            }
            if (!string.IsNullOrEmpty(searchModel.DisciplinaryName))
            {
                query = query.Where(p => p.Disciplinary.Name.Contains(searchModel.DisciplinaryName));
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeId))
            {
                query = query.Where(p => p.EmployeeId.ToString().Contains(searchModel.EmployeeId));
            }

            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.Contains(searchModel.EmployeeName));
            }
            if (!string.IsNullOrEmpty(searchModel.No))
            {
                query = query.Where(p => p.No.ToString().Contains(searchModel.No));
            }
            if (!string.IsNullOrEmpty(searchModel.NoDays))
            {
                query = query.Where(p => p.NoDays.ToString().Contains(searchModel.NoDays));
            }
            if (!string.IsNullOrEmpty(searchModel.CreateUserName))
            {
                query = query.Where(p => p.CreatedBy.Name.Contains(searchModel.CreateUserName));
            }
            //if (!string.IsNullOrEmpty(searchModel.CreateUserName))
            //{
            //    query = query.Where(p => p.CreatedBy.Name.Contains(searchModel.CreateUserName));
            //}
            //if (!string.IsNullOrEmpty(searchModel.CreateUserName))
            //{
            //    query = query.Where(p => p.CreatedBy.Name.Contains(searchModel.CreateUserName));
            //}

            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.Date.Value.Date);

            }
            var result = query.Select(n => new HrEmployeeDisciplinaryGetSearchVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                No = n.No,
                Date = n.Date,
                Description = n.Description,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                DisciplinaryId = n.DisciplinaryId,
                DisciplinaryName = n.Disciplinary.Name,
                NoDays = n.NoDays,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Employee.Section.Name,


            }).ToList();



            return result;
        }
    }
}
