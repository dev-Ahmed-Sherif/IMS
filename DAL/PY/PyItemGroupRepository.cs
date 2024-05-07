using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyItemGroupRepository
    {
        private AppDbContext _context;
        public PyItemGroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyItemGroupVM ItemGroup)
        {
          
                var _PyItemGroup = new PyItemGroup()
                {
                    Name = ItemGroup.name,
                    CreatedByID = ItemGroup.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyItemGroup.Add(_PyItemGroup);
                _context.SaveChanges();
                return _PyItemGroup.Id.ToString();

        }
        public string Update(PyItemGroupVM ItemGroup)
        {
                var _ItemGroup = _context.PyItemGroup.Single(n => n.Id == ItemGroup.Id);
            
                    _ItemGroup.Name = ItemGroup.name;
                    _ItemGroup.UpdateByID = ItemGroup.TransactionUserId;
                    _ItemGroup.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public string Delete(int ItemGroupId)
        {
          
                var _ItemGroup = _context.PyItemGroup.Single(n => n.Id == ItemGroupId);
              
                    _context.PyItemGroup.Remove(_ItemGroup);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyItemGroupGetVM> GetAll()
            => _context.PyItemGroup.Select(
                n => new PyItemGroupGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------
        // GET { Data From Table By ID => ItemGroupId } 
        //---------------------------------------------
        public PyItemGroupGetVM GetById(int ItemGroupId) =>
            _context.PyItemGroup.Select(
                n => new PyItemGroupGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ItemGroupId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyItemGroupGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyItemGroup.Count();
            List<PyItemGroupGetVM> Item = _context.PyItemGroup
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyItemGroupGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyItemGroupGetVM>
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
