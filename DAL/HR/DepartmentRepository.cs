using DAL.Migrations;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class DepartmentRepository
    {
        private AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(DepartmentGeneralVM Gdep)
        {
            bool exists = _context.Department.Any(s => s.Name == Gdep.Name&&s.GeneralDepartmentId==Gdep.GeneralDepartmentId);
            if (exists)
            {
                return " Name already exists.";
            }
            var _dep = new Department()
                {
                    Name = Gdep.Name,
                    GeneralDepartmentId = Gdep.GeneralDepartmentId,
                    CreatedByID = Gdep.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.Department.Add(_dep);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(DepartmentVM gdep)
        {
            bool exists = _context.Department.Any(s => s.Name == gdep.Name && s.GeneralDepartmentId == gdep.GeneralDepartmentId && s.Id != gdep.Id);
            if (exists)
            {
                return " Name already exists.";
            }
            var _gdep = _context.Department.Single(n => n.Id == gdep.Id);
               
                    _gdep.Name = gdep.Name;
                    _gdep.GeneralDepartmentId = gdep.GeneralDepartmentId;
                    _gdep.UpdateByID = gdep.TransactionUserId;
                    _gdep.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }

        public string Delete(int gdepId)
        {
            try
            {
                var _gdep = _context.Department.FirstOrDefault(n => n.Id == gdepId);
                if (_gdep != null)
                {
                    _context.Department.Remove(_gdep);
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

        public List<DepartmentGetVM> GetAll()
            => _context.Department.Select(n => new DepartmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                GeneralDepartmentId = n.GeneralDepartmentId,
                GeneralDepartmentName = n.generaldepartment.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreateUserName = n.CreatedBy.Name
            }).ToList();
        public DepartmentGetVM GetById(int GdepId)
            => _context.Department.Select(n => new DepartmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                GeneralDepartmentId = n.GeneralDepartmentId,
                GeneralDepartmentName = n.generaldepartment.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreateUserName = n.CreatedBy.Name
            }).FirstOrDefault(n => n.Id == GdepId);

    }
}
