using Entities.Models.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Account
{
    public class FiAccountHierarchyRepository
    {
        private AppDbContext _context;

        public FiAccountHierarchyRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------------------
        // ADD new (FI)_AccountHierarchy
        //------------------------------
        public string Add(FiAccountHierarchyGVM ID)
        {
            bool exists = _context.FiAccountHierarchy.Any(s => s.Name == ID.Name || s.Level == ID.level);
            if (exists)
            {
                return " Name or level  already exists.";
            }
            var _Row = new FiAccountHierarchy()
                {
                    Name = ID.Name,
                    Level = ID.level,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiAccountHierarchy.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
           

        }

        //-----------------------------------------------------------------
        // Update (FI)_accountHierarchy { where id == AccountHierarchy.id }
        //-----------------------------------------------------------------
        public string Update(FiAccountHierarchyVM ID)
        {
            bool exists = _context.FiAccountHierarchy.Any(s => s.Name == ID.Name || s.Level == ID.level && s.Id != ID.Id);
            if (exists)
            {
                return " Name or level  already exists.";
            }

            var _Row = _context.FiAccountHierarchy.Single(n => n.Id == ID.Id);
                
                    _Row.Name = ID.Name;
                    _Row.Level = ID.level;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
              

        }

        //-----------------------------------------------------------------
        // Dellete (FI)_accountHierarchy { where id == AccountHierarchyID }
        //-----------------------------------------------------------------
        public string Delete(int ID)
        {
            
                var _Row = _context.FiAccountHierarchy.Single(n => n.Id == ID);
               
                    _context.FiAccountHierarchy.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }

        //-----------------------------------------------------------------------------------
        //Select * (FI)_accountHierarchy { with CreateUserName , UpdateUserName , AccountId }
        //-----------------------------------------------------------------------------------
        public List<FiAccountHierarchyGetVM> GetAll()
            => _context.FiAccountHierarchy.Select(
                n => new FiAccountHierarchyGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    level = n.Level,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountHierarchyGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiAccountHierarchy.Count();
            List<FiAccountHierarchyGetVM> Item = _context.FiAccountHierarchy
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiAccountHierarchyGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    level = n.Level,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiAccountHierarchyGetVM>
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
        //--------------------------------------------------------------------------------------------------------------------------------
        // Select * (FI)_accountHierarchy where {id = AccountHierarchyID} { with CreateUserName , UpdateUserName , AccountId, HierarchyId } 
        //--------------------------------------------------------------------------------------------------------------------------------
        public FiAccountHierarchyGetVM GetById(int ID)

            => _context.FiAccountHierarchy.Select(
                n => new FiAccountHierarchyGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    level = n.Level,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);
    }
}
