using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrGroupPrivilegesRepository
    {
        private AppDbContext _context;

        public PrGroupPrivilegesRepository(AppDbContext context)
        {
            _context = context;
        }
        //------------------------
        // ADD new (PR)_GroupPrivileges
        //------------------------
        public string Add(PrGroupPrivilegesGeneralVM ID)
        {
           
                var _Row = new PrGroupPrivileges()
                {
                    GroupId = ID.GroupId,
                    PrivilegesId = ID.PrivilegesId,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrGroupPrivileges.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        //-------------------------------------------
        // Update (PR)_GroupPrivileges { where id == GroupPrivileges.id }
        //-------------------------------------------
        public string Update(PrGroupPrivilegesVM ID)
        {
           
                var _Row = _context.PrGroupPrivileges.Single(n => n.Id == ID.Id);
              
                    _Row.GroupId = ID.GroupId;
                    _Row.PrivilegesId = ID.PrivilegesId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //-------------------------------------------
        // Dellete (PR)_GroupPrivileges { where id == GroupPrivilegesID }
        //-------------------------------------------
        public string Delete(int ID)
        {
         
                var _Row = _context.PrGroupPrivileges.Single(n => n.Id == ID);
               
                    _context.PrGroupPrivileges.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //---------------------------------------------------------------
        //Select * (PR)_GroupPrivileges { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrGroupPrivilegesGetVM> GetAll()
            => _context.PrGroupPrivileges.Select(
                n => new PrGroupPrivilegesGetVM
                {
                    Id = n.Id,
                    GroupId = n.GroupId,
                    PrivilegesId = n.PrivilegesId,
                    GroupName = n.PR_Group.Name,
                    PrivilegesName = n.Privileges.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_GroupPrivileges where {id = GroupPrivilegesID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrGroupPrivilegesGetVM GetById(int ID)
            => _context.PrGroupPrivileges.Select(
                n => new PrGroupPrivilegesGetVM
                {
                    Id = n.Id,
                    GroupId = n.GroupId,
                    PrivilegesId = n.PrivilegesId,
                    GroupName = n.PR_Group.Name,
                    PrivilegesName = n.Privileges.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ID);
    }
}

