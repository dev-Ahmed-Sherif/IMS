using Entities.Models.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Account
{
    public class FiAccountItemCategoryRepository
    {
        private AppDbContext _context;

        public FiAccountItemCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        //-------------------------
        // Add new (FI)_AccountItem
        //-------------------------
        public string Add(FiAccountItemCategoryGVM ID)
        {
            try
            {
                var _Row = new FiAccountItemCategory()
                {
                    Name = ID.Name,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiAccountItemCategory.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        //-------------------------------------------------------
        // Update (FI)_accountitem { where id == AccountItem.id }
        //-------------------------------------------------------
        public string Update(FiAccountItemCategoryVM ID)
        {
            
                var _Row = _context.FiAccountItemCategory.Single(n => n.Id == ID.Id);
               
                    _Row.Name = ID.Name;
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
           
                var _Row = _context.FiAccountItemCategory.Single(n => n.Id == ID);
              
                    _context.FiAccountItemCategory.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //-------------------------------------------------------------------------------
        // Select * (FI)_accountitem { with CreateUserName , UpdateUserName , AccountId }
        //-------------------------------------------------------------------------------
        public List<FiAccountItemCategoryGetVM> GetAll()
            => _context.FiAccountItemCategory.Select(
                n => new FiAccountItemCategoryGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountItemCategoryGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiAccountItemCategory.Count();
            List<FiAccountItemCategoryGetVM> Item = _context.FiAccountItemCategory
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiAccountItemCategoryGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiAccountItemCategoryGetVM>
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
        public FiAccountItemCategoryGetVM GetById(int ID)

            => _context.FiAccountItemCategory.Select(
                n => new FiAccountItemCategoryGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);
    }
}
