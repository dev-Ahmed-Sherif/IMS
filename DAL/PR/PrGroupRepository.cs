using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrGroupRepository
    {
        private AppDbContext _context;
        public PrGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------------------
        // ADD new (PR)_Group
        //------------------------------

        public string Add(PrGroupVM ID)
        {
            bool exists = _context.PrGroup.Any(s => s.Name == ID.Name);
            if (exists)
            {
                return " Name already exists.";
            }
            var _Row = new PrGroup()
                {
                    Name = ID.Name,
                    Description = ID.Description,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrGroup.Add(_Row);
                _context.SaveChanges();
                return _Row.Id.ToString();
         
        }

        //-------------------------------------------
        // Update (PR)_Group { where id == Group.id }
        //-------------------------------------------
        public string Update(PrGroupVM ID)
        {
            bool exists = _context.PrGroup.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.PrGroup.Single(n => n.Id == ID.Id);
                
                    _Row.Name = ID.Name;
                    _Row.Description = ID.Description;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
    
        }

        //-------------------------------------------
        // Dellete (PR)_Group { where id == GroupID }
        //-------------------------------------------
        public string Delete(int ID)
        {
           
             var _Row = _context.PrGroup.Single(n => n.Id == ID);
            var grouprole = _context.PrGroupRole.Where(p => p.GroupId == ID).ToList();
            _context.PrGroupRole.RemoveRange(grouprole);
            _context.SaveChanges();
            var groupprivilege= _context.PrGroupPrivileges.Where(p => p.GroupId == ID).ToList();
            _context.PrGroupPrivileges.RemoveRange(groupprivilege);
            _context.SaveChanges();
            var usergroup = _context.PrUserGroup.Where(p => p.GroupId == ID).ToList();
            _context.PrUserGroup.RemoveRange(usergroup);
            _context.SaveChanges();

            _context.PrGroup.Remove(_Row);
                    _context.SaveChanges();
                     return "Succeeded";


        }

        //---------------------------------------------------------------
        //Select * (PR)_Group { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrGroupGetVM> GetAll()
            => _context.PrGroup.Select(
                n => new PrGroupGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_Group where {id = GroupID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrGroupGetVM GetById(int ID)
            => _context.PrGroup.Select(
                n => new PrGroupGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ID);

    }
}
