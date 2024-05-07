using Entities.Models.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Account
{
    public class FiAccountParentRepository
    {
        private AppDbContext _context;

        public FiAccountParentRepository(AppDbContext context)
        {
            _context = context;
        }

        //---------------------------
        // Add new (FI)_Accountparent
        //---------------------------
        public string Add(FiAccountParentGVM ID)
        {
           
                var _Row = new FiAccountParent()
                {
                    ParentId = ID.ParentId,
                    AccountId = ID.AccountId,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiAccountParent.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
          

        }

        //-----------------------------------------------------------
        // Update (FI)_accountparent { where id == AccountParent.id }
        //-----------------------------------------------------------
        public string Update(FiAccountParentVM ID)
        {
            
                var _Row = _context.FiAccountParent.Single(n => n.Id == ID.Id);
               
                    _Row.ParentId = ID.ParentId;
                    _Row.AccountId = ID.AccountId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           

        }

        //-----------------------------------------------------------
        // Dellete (FI)_accountparent { where id == AccountParentID }
        //-----------------------------------------------------------
        public string Delete(int ID)
        {
           
                var _Row = _context.FiAccountParent.Single(n => n.Id == ID);
              
                    _context.FiAccountParent.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }

        //---------------------------------------------------------------------------------
        // Select * (FI)_accountparent { with CreateUserName , UpdateUserName , AccountId }
        //---------------------------------------------------------------------------------
        public List<FiAccountParentGetVM> GetAll()
            => _context.FiAccountParent.Select(
                n => new FiAccountParentGetVM
                {
                    Id = n.Id,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    ParentId = n.ParentId,
                    ParentName = n.Parent.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).ToList();

        //-----------------------------------------------------------------------------------------------------------------
        // Select * (FI)_accountParent where {id = AccountID} { with CreateUserName , UpdateUserName , AccountId,ParentId } 
        //-----------------------------------------------------------------------------------------------------------------
        public FiAccountParentGetVM GetById(int ID)

            => _context.FiAccountParent.Select(
                n => new FiAccountParentGetVM
                {
                    Id = n.Id,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    ParentId = n.ParentId,
                    ParentName = n.Parent.Name,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountParentGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiAccountParent.Count();
            List<FiAccountParentGetVM> Item = _context.FiAccountParent
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiAccountParentGetVM
                {
                    Id = n.Id,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    ParentId = n.ParentId,
                    ParentName = n.Parent.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiAccountParentGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }

}
