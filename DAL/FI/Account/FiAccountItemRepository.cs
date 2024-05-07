using Entities.Models.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Account
{
    public class FiAccountItemRepository
    {
        private AppDbContext _context;

        public FiAccountItemRepository(AppDbContext context)
        {
            _context = context;
        }

        //-------------------------
        // Add new (FI)_AccountItem
        //-------------------------
        public string Add(FiAccountItemGVM ID)
        {
            bool exists = _context.FiAccountItem.Any(s => s.Name == ID.Name );
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = new FiAccountItem()
                {
                    Name = ID.Name,
                    AccountId = ID.AccountId,
                    AccountItemCategoryId = ID.AccountItemCategoryId,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiAccountItem.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
          

        }

        //-------------------------------------------------------
        // Update (FI)_accountitem { where id == AccountItem.id }
        //-------------------------------------------------------
        public string Update(FiAccountItemVM ID)
        {
            bool exists = _context.FiAccountItem.Any(s => s.Name == ID.Name&& s.Id!=ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.FiAccountItem.Single(n => n.Id == ID.Id);
               
                    _Row.Name = ID.Name;
                    _Row.AccountId = ID.AccountId;
                    _Row.AccountItemCategoryId = ID.AccountItemCategoryId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             

        }

        //----------------------------------------------------
        // Dellete (FI)_accountitem { where id == Account_id }
        //----------------------------------------------------
        public string Delete(int ID)
        {
           
                var _Row = _context.FiAccountItem.Single(n => n.Id == ID);
                
                    _context.FiAccountItem.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }

        //-------------------------------------------------------------------------------
        // Select * (FI)_accountitem { with CreateUserName , UpdateUserName , AccountId }
        //-------------------------------------------------------------------------------
        public List<FiAccountItemGetVM> GetAll()
            => _context.FiAccountItem.Select(
                n => new FiAccountItemGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    AccountId = n.AccountId,
                    AccounName = n.Account.Name,
                    AccounCode = n.Account.Code,
                    AccountItemCategoryId = n.AccountItemCategoryId,
                    AccountItemCategoryName = n.AccountItemCategory.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    UpdateUserName = n.UpdateBy.Name
                }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountItemGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiAccountItem.Count();
            List<FiAccountItemGetVM> Item = _context.FiAccountItem
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiAccountItemGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    AccountId = n.AccountId,
                    AccounName = n.Account.Name,
                    AccounCode = n.Account.Code,
                    AccountItemCategoryId = n.AccountItemCategoryId,
                    AccountItemCategoryName = n.AccountItemCategory.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiAccountItemGetVM>
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

        //-----------------------------------------------------------------------------------------------------------------
        // Select * (FI)_accountitem where {id = AccountID} { with CreateUserName , UpdateUserName , FiAccountHierarchyId }
        //-----------------------------------------------------------------------------------------------------------------
        public FiAccountItemGetVM GetById(int ID)

            => _context.FiAccountItem.Select(
                n => new FiAccountItemGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    AccountId = n.AccountId,
                    AccounName = n.Account.Name,
                    AccounCode = n.Account.Code,
                    AccountItemCategoryId = n.AccountItemCategoryId,
                    AccountItemCategoryName = n.AccountItemCategory.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id

                }).Single(n => n.Id == ID);

        //-------------------------------------------------------------------------------------------------------------
        // Select * (FI)_accountItem where {Name = AccountName} { with CreateUserName , UpdateUserName , FiAccountHierarchyId } 
        //-------------------------------------------------------------------------------------------------------------
        public List<FiAccountItemGetVM> GetByName(string accountName)
        {
            return _context.FiAccountItem
                .Where(n => n.Name.Contains(accountName))
                .Select(n => new FiAccountItemGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    AccountId = n.AccountId,
                    AccounName = n.Account.Name,
                    AccounCode = n.Account.Code,
                    AccountItemCategoryId = n.AccountItemCategoryId,
                    AccountItemCategoryName = n.AccountItemCategory.Name,
                    CreateUserName = n.CreatedBy.Name


                })
               .ToList();
        }
    }
}
