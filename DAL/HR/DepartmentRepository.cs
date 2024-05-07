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
            try
            {
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
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(DepartmentVM gdep)
        {
            try
            {
                var _gdep = _context.Department.FirstOrDefault(n => n.Id == gdep.Id);
                if (_gdep != null)
                {
                    _gdep.Name = gdep.Name;

                    _gdep.UpdateByID = gdep.TransactionUserId;
                    _gdep.LastUpdateDate = DateTime.Now;

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
