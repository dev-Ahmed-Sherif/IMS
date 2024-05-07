using Entities.Models.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PR
{
    public class PrUserGroupRepository
    {
        private AppDbContext _context;

        public PrUserGroupRepository(AppDbContext context)
        {
            _context = context;
        }
        //-----------------------
        // ADD new (PR)_UserGroup
        //-----------------------
        public string Add(PrUserGroupVM ID)
        {
            
                var _Row = new PrUserGroup()
                {
                    GroupId = ID.GroupId,
                    UserId = ID.UserId,
                    UpdateByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PrUserGroup.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        //-------------------------------------------
        // Update (PR)_UserGroup { where id == UserGroup.id }
        //-------------------------------------------
        public string Update(PrUserGroupVM ID)
        {
           
                var _Row = _context.PrUserGroup.Single(n => n.Id == ID.Id);
               
                    _Row.GroupId = ID.GroupId;
                    _Row.UserId = ID.UserId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //-------------------------------------------
        // Dellete (PR)_UserGroup { where id == UserGroupID }
        //-------------------------------------------
        public string Delete(int ID)
        {
            
                var _Row = _context.PrUserGroup.Single(n => n.Id == ID);
              
                    _context.PrUserGroup.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //---------------------------------------------------------------
        //Select * (PR)_UserGroup { with UserId , GroupId ,Group_Name }
        //---------------------------------------------------------------
        public List<PrUserGroupWithGroupVM> GetAll()
            => _context.PrUserGroup.Select(
                n => new PrUserGroupWithGroupVM
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    GroupId = n.GroupId,
                    Group_Name = n.PR_Group.Name,
                    Group_Description = n.PR_Group.Description
                }).ToList();
        //--------------------------------------------------------------------------------------
        // Select * (PR)_UserGroup where {id = UserGroupID} { with UserId , GroupId ,Group_Name } 
        //--------------------------------------------------------------------------------------
        public PrUserGroupWithGroupVM GetById(int ID)
            => _context.PrUserGroup.Select(
                n => new PrUserGroupWithGroupVM
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    UserName = n.PrUser.Name,
                    GroupId = n.GroupId,
                    Group_Name = n.PR_Group.Name,
                    Group_Description = n.PR_Group.Description
                }). Single(n => n.Id == ID);
        public List<PrUserGroupWithGroupVM> GetByUser(int UserId)
        {

            var userGroupVMs = _context.PrUserGroup
             .Where(n => n.UserId == UserId)
             .Select(n => new PrUserGroupWithGroupVM
             {
                 Id = n.Id,
                 UserId = n.UserId,
                 UserName = n.PrUser.Name,
                 GroupId = n.GroupId,
                 Group_Name = n.PR_Group.Name,
                 Group_Description = n.PR_Group.Description,
                 TransactionUserId = n.CreatedBy.Id

             })
             .ToList();

            return userGroupVMs;
        }
    }
}
