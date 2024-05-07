using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrPrivilegesRepository
    {
        private AppDbContext _context;
        public PrPrivilegesRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------------------
        // ADD new (PR)_Group
        //------------------------------

        public string Add(PrPrivilegesVM ID)
        {
            bool exists = _context.PrPrivileges.Any(s => s.Name == ID.Name );
            if (exists)
            {
                return " Name already exists.";
            }
            var _Row = new PrPrivileges()
                {
                    Name = ID.Name,

                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrPrivileges.Add(_Row);
                _context.SaveChanges();
                return _Row.Id.ToString();
         
        }

        //-------------------------------------------
        // Update (PR)_Group { where id == Group.id }
        //-------------------------------------------
        public string Update(PrPrivilegesVM ID)
        {
            bool exists = _context.PrPrivileges.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.PrPrivileges.Single(n => n.Id == ID.Id);
               _Row.Name = ID.Name;

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
           
                var _Row = _context.PrPrivileges.Single(n => n.Id == ID);
               
                    _context.PrPrivileges.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //---------------------------------------------------------------
        //Select * (PR)_Group { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrPrivilegesGetVM> GetAll()
            => _context.PrPrivileges.Select(
                n => new PrPrivilegesGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_Group where {id = GroupID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrPrivilegesGetVM GetById(int ID)
            => _context.PrPrivileges.Select(
                n => new PrPrivilegesGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ID);

    }
}

