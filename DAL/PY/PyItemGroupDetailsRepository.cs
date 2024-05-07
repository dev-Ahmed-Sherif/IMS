using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyItemGroupDetailsRepository
    {
        private AppDbContext _context;
        public PyItemGroupDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(PyItemGroupDetailsVM ItemGroupDetails)
        {
           
                var _PyItemGroupDetails = new PyItemGroupDetails()
                {
                    PyItemId = ItemGroupDetails.PyItemId,
                    ItemGroupId = ItemGroupDetails.ItemGroupId,
                    CreatedByID = ItemGroupDetails.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyItemGroupDetails.Add(_PyItemGroupDetails);
                _context.SaveChanges();
                return "Succeeded";
          
        }

        public string Update(PyItemGroupDetailsVM ItemGroupDetails)
        {
           var _ItemGroupDetails = _context.PyItemGroupDetails.Single(n => n.Id == ItemGroupDetails.Id);
               
                    _ItemGroupDetails.PyItemId = ItemGroupDetails.PyItemId;
                    _ItemGroupDetails.ItemGroupId = ItemGroupDetails.ItemGroupId;

                    _ItemGroupDetails.UpdateByID = ItemGroupDetails.TransactionUserId;
                    _ItemGroupDetails.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        public string Delete(int ItemGroupDetailsId)
        {
           
                var _ItemGroupDetails = _context.PyItemGroupDetails.Single(n => n.Id == ItemGroupDetailsId);
                
                    _context.PyItemGroupDetails.Remove(_ItemGroupDetails);
                    _context.SaveChanges();
                    return "Succeeded";
              
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyItemGroupDetailsGetVM> GetAll()
            => _context.PyItemGroupDetails.Select(
                n => new PyItemGroupDetailsGetVM
                {
                    Id = n.Id,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------------
        // GET { Data From Table By ID => ExchangeDetailsId } 
        //---------------------------------------------------
        public PyItemGroupDetailsGetVM GetById(int ItemGroupDetailsId)
            => _context.PyItemGroupDetails.Select(
                n => new PyItemGroupDetailsGetVM
                {
                    Id = n.Id,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ItemGroupDetailsId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyItemGroupDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.PyItemGroupDetails.Where(n => n.ItemGroupId == HeaderId).Count();
            List<int> ItemGroupId = _context.PyItemGroupDetails
                .Where(sus => sus.ItemGroupId == HeaderId)
                .Select(sus => sus.ItemGroupId)
                .ToList();
            List<PyItemGroupDetailsGetVM> Item = _context.PyItemGroupDetails
                .Where(n => ItemGroupId.Contains(n.ItemGroupId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyItemGroupDetailsGetVM
                {
                    Id = n.Id,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyItemGroupDetailsGetVM>
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

        public List<PyItemGroupDetailsGetVM> GetByHeader(int Id)
          => _context.PyItemGroupDetails.Where(n => n.ItemGroupId == Id)
                .Select(n => new PyItemGroupDetailsGetVM
                {
                    //Header
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    HeaderCreateUserName = n.ItemGroup.CreatedBy.Name,
                    //Details
                    Id = n.Id,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
    }
}
