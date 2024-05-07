using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrModuleRepository
    {
        private AppDbContext _context;

        public PrModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------
        // ADD new (PR)_Module
        //------------------

        public string Add(PrModuleVM ID)
        {
            bool exists = _context.PrModule.Any(s => s.Name == ID.Name);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = new PrModule()
                {
                    Name = ID.Name,
                    Description = ID.Description,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrModule.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
          
        }

        //-------------------------------------------
        // Update (PR)_Module { where id == Module.id }
        //-------------------------------------------
        public string Update(PrModuleVM ID)
        {
            bool exists = _context.PrModule.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.PrModule.Single(n => n.Id == ID.Id);
               
                    _Row.Name = ID.Name;
                    _Row.Description = ID.Description;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //-------------------------------------------
        // Dellete (PR)_Module { where id == ModuleID }
        //-------------------------------------------
        public string Delete(int ID)
        {
                var _Row = _context.PrModule.Single(n => n.Id == ID);
               
                    _context.PrModule.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
           
        }

        //---------------------------------------------------------------
        //Select * (PR)_Module { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrModuleGetVM> GetAll()
            => _context.PrModule.Select(
                n => new PrModuleGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_Module where {id = ModuleID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrModuleGetVM GetById(int ID)
            => _context.PrModule.Select(
                n => new PrModuleGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == ID);
    }
}
