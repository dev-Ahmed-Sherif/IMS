using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrUserModuleRepository
    {
        private AppDbContext _context;

        public PrUserModuleRepository(AppDbContext context)
        {
            _context = context;
        }
        //-----------------------
        // ADD new (PR)_UserModule
        //-----------------------
        public string Add(PrUserModuleVM ID)
        {
         
                var _Row = new PrUserModule()
                {
                    ModuleId = ID.ModuleId,
                    UserId = ID.UserId,
                    IsAdmin = ID.IsAdmin,
                    UpdateByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrUserModule.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        //-------------------------------------------
        // Update (PR)_UserModule { where id == UserModule.id }
        //-------------------------------------------
        public string Update(PrUserModuleVM ID)
        {
           
                var _Row = _context.PrUserModule.Single(n => n.Id == ID.Id);
              
                    _Row.ModuleId = ID.ModuleId;
                    _Row.UserId = ID.UserId;
                    _Row.IsAdmin = ID.IsAdmin;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //-------------------------------------------
        // Dellete (PR)_UserModule { where id == UserModuleID }
        //-------------------------------------------
        public string Delete(int ID)
        {
           
                var _Row = _context.PrUserModule.Single(n => n.Id == ID);
               
                    _context.PrUserModule.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //---------------------------------------------------------------
        //Select * (PR)_UserModule { with UserId , ModuleId ,Module_Name }
        //---------------------------------------------------------------
        public List<PrUserModuleGetVM> GetAll()
            => _context.PrUserModule.Select(
                n => new PrUserModuleGetVM
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    UserName = n.User.Name,
                    ModuleId = n.ModuleId,
                    Module_Name = n.Module.Name,
                    Module_Description = n.Module.Description,
                    IsAdmin = n.IsAdmin
                }).ToList();
        //--------------------------------------------------------------------------------------
        // Select * (PR)_UserModule where {id = UserModuleID} { with UserId , ModuleId ,Module_Name } 
        //--------------------------------------------------------------------------------------
        public PrUserModuleGetVM GetById(int ID)
            => _context.PrUserModule.Select(
                n => new PrUserModuleGetVM
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    UserName = n.User.Name,
                    ModuleId = n.ModuleId,
                    Module_Name = n.Module.Name,
                    Module_Description = n.Module.Description,
                    IsAdmin = n.IsAdmin
                }).Single(n => n.Id == ID);
    }
}
