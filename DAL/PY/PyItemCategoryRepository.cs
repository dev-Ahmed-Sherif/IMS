using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyItemCategoryRepository
    {
        private AppDbContext _context;
        public PyItemCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(PyItemCategoryVM ItemCategory)
        {
           
                var _PyItemCategory = new PyItemCategory()
                {
                    Name = ItemCategory.name,
                    CreatedByID = ItemCategory.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyItemCategory.Add(_PyItemCategory);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        public string Update(PyItemCategoryVM ItemCategory)
        {
           
                var _ItemCategory = _context.PyItemCategory.Single(n => n.Id == ItemCategory.Id);
              
                    _ItemCategory.Name = ItemCategory.name;




                    _ItemCategory.UpdateByID = ItemCategory.TransactionUserId;
                    _ItemCategory.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public string Delete(int ItemCategoryId)
        {
          
                var _ItemCategory = _context.PyItemCategory.Single(n => n.Id == ItemCategoryId);
              
                    _context.PyItemCategory.Remove(_ItemCategory);
                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyItemCategoryGetVM> GetAll()
            => _context.PyItemCategory.Select(
                n => new PyItemCategoryGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------------
        // GET { Data From Table By ID => ItemCategoryId } 
        //---------------------------------------------------
        public PyItemCategoryGetVM GetById(int ItemCategoryId)
            => _context.PyItemCategory.Select(
                n => new PyItemCategoryGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ItemCategoryId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyItemCategoryGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyItemCategory.Count();
            List<PyItemCategoryGetVM> Item = _context.PyItemCategory
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyItemCategoryGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyItemCategoryGetVM>
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
