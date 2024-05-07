using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class GeneralDepartmentRepository
    {
        private AppDbContext _context;
        public GeneralDepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(GeneralDepartmentgeneralVM Gdep)
        {
            try
            {
                var _Gdep = new GeneralDepartment()
                {
                    Name = Gdep.Name,
                    CreatedByID = Gdep.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.GeneralDepartment.Add(_Gdep);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(GeneralDepartmentVM gdep)
        {
            try
            {
                var _gdep = _context.GeneralDepartment.FirstOrDefault(n => n.Id == gdep.Id);
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
                var _gdep = _context.GeneralDepartment.FirstOrDefault(n => n.Id == gdepId);
                if (_gdep != null)
                {
                    _context.GeneralDepartment.Remove(_gdep);
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

        public List<GeneralDepartmentGetVM> GetAll()
            => _context.GeneralDepartment.Select(n => new GeneralDepartmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreateUserName = n.CreatedBy.Name
            }).ToList();
        public GeneralDepartmentGetVM GetById(int GdepId)
            => _context.GeneralDepartment.Select(n => new GeneralDepartmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                CreateUserName = n.CreatedBy.Name
            }).FirstOrDefault(n => n.Id == GdepId);

    }
}

