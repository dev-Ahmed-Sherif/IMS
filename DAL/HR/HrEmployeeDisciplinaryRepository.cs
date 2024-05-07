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

    }
}
