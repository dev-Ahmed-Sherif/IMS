using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrRoleRepository
    {
        private AppDbContext _context;

        public PrRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------
        // ADD new (PR)_Role
        //------------------

        public string Add(PrRoleVM ID)
        {
            bool exists = _context.PrRole.Any(s => s.Name == ID.Name);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = new PrRole()
                {
                    Name = ID.Name,
                    Description = ID.Description,
                    ModuleId = ID.ModuleId,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrRole.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
            
           
        }

        //-------------------------------------------
        // Update (PR)_Role { where id == Role.id }
        //-------------------------------------------
        public string Update(PrRoleVM ID)
        {
            bool exists = _context.PrRole.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.PrRole.Single(n => n.Id == ID.Id);
              
                    _Row.Name = ID.Name;
                    _Row.Description = ID.Description;
                    _Row.ModuleId = ID.ModuleId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
           
        }

        //-------------------------------------------
        // Dellete (PR)_Role { where id == RoleID }
        //-------------------------------------------
        public string Delete(int ID)
        {
           
                var _Row = _context.PrRole. Single(n => n.Id == ID);
            var grouprole = _context.PrGroupRole.Where(p => p.RoleId == ID).ToList();
            _context.PrGroupRole.RemoveRange(grouprole);
            _context.SaveChanges();

            _context.PrRole.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //---------------------------------------------------------------
        //Select * (PR)_Role { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrRoleGetVM> GetAll()
            => _context.PrRole.Select(
                n => new PrRoleGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    ModuleId = n.ModuleId,
                    ModuleName = n.Module.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_Role where {id = RoleID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrRoleGetVM GetById(int ID)
            => _context.PrRole.Select(
                n => new PrRoleGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    ModuleId = n.ModuleId,
                    ModuleName = n.Module.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ID);
    }
}
