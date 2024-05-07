using Entities.ExtensionMethods.PR;
using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrGroupRoleRepository
    {
        private AppDbContext _context;

        public PrGroupRoleRepository(AppDbContext context)
        {
            _context = context;
        }
        //------------------------
        // ADD new (PR)_GroupRole
        //------------------------
        public string Add(PrGroupRoleGeneralVM ID)
        {
           
                var _Row = new PrGroupRole()
                {
                    GroupId = ID.GroupId,
                    RoleId = ID.RoleId,
                    CanInsert = ID.CanInsert,
                    CanEdit = ID.CanEdit,
                    CanDelete = ID.CanDelete,
                    CanPrint = ID.CanPrint,
                    CanView = ID.CanView,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrGroupRole.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
         
        }

        //-------------------------------------------
        // Update (PR)_GroupRole { where id == GroupRole.id }
        //-------------------------------------------
        public string Update(PrGroupRoleVM ID)
        {

            var _Row = _context.PrGroupRole. Single(n => n.Id == ID.Id);
           
                _Row.GroupId = ID.GroupId;
                _Row.RoleId = ID.RoleId;
                _Row.CanInsert = ID.CanInsert;
                _Row.CanEdit = ID.CanEdit;
                _Row.CanDelete = ID.CanDelete;
                _Row.CanPrint = ID.CanPrint;
                _Row.CanView = ID.CanView;
                _Row.UpdateByID = ID.TransactionUserId;
                _Row.LastUpdateDate = DateTime.Now;

                _context.SaveChanges();
                return "Succeeded";
           

        }

        //-------------------------------------------
        // Dellete (PR)_GroupRole { where id == GroupRoleID }
        //-------------------------------------------
        public string Delete(int ID)
        {

            var _Row = _context.PrGroupRole.Single(n => n.Id == ID);
             _context.PrGroupRole.Remove(_Row);
                _context.SaveChanges();
                return "Succeeded";
          
        }

        //---------------------------------------------------------------
        //Select * (PR)_GroupRole { with CreateUserName , TransactionUserId }
        //---------------------------------------------------------------
        public List<PrGroupRoleGetVM> GetAll()
            => _context.PrGroupRole.Select(
                n => new PrGroupRoleGetVM
                {
                    Id = n.Id,
                    GroupId = n.GroupId,
                    RoleId = n.RoleId,
                    GroupName = n.PR_Group.Name,
                    RoleName = n.PR_Role.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //------------------------------------------------------------------------------------
        // Select * (PR)_GroupRole where {id = GroupRoleID} { with CreateUserName ,TransactionUserId } 
        //------------------------------------------------------------------------------------
        public PrGroupRoleGetVM GetById(int ID)
            => _context.PrGroupRole.Select(
                n => new PrGroupRoleGetVM
                {
                    Id = n.Id,
                    GroupId = n.GroupId,
                    RoleId = n.RoleId,
                    GroupName = n.PR_Group.Name,
                    RoleName = n.PR_Role.Name,
                    CanInsert = n.CanInsert,
                    CanEdit = n.CanEdit,
                    CanDelete = n.CanDelete,
                    CanPrint = n.CanPrint,
                    CanView = n.CanView,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == ID);
        public List<PrGroupRoleGetVM> GetByGroup(int GroupId)
        {

            var GroupRoleVMs = _context.PrGroupRole
             .Where(n => n.GroupId == GroupId)
             .Select(n => n.ToPrGroupRoleGetVM())
             .ToList();

            return GroupRoleVMs;
        }
    }
}
