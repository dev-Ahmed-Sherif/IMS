using Entities.Models.FI;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Entry
{
    public class FiEntrySourceRepository
    {
        private AppDbContext _context;
        public FiEntrySourceRepository(AppDbContext context)
        {
            _context = context;
        }
        //-------------------------
        // Add new (FI)EntrySource
        //-------------------------
        public string Add(FiEntrySourceGeneralVM ID)
        {
            bool exists = _context.FiEntrySource.Any(s => s.Name == ID.Name);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = new FiEntrySource()
                {
                    Name = ID.Name,


                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiEntrySource.Add(_Row);
                _context.SaveChanges();
                return _Row.Id.ToString();
          
        }
        //------------------------------------------
        // Update (FI)Entry { where id == Entry.id } 
        //------------------------------------------
        public string Update(FiEntrySourceVM ID)
        {
            bool exists = _context.FiEntrySource.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.FiEntrySource.Single(n => n.Id == ID.Id);
               
                    _Row.Name = ID.Name;

                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //------------------------------------------
        // Dellete (FI)EntrySource{ where id == EntryID }
        //------------------------------------------
        public string Delete(int ID)
        {
           
                var _Row = _context.FiEntrySource.Single(n => n.Id == ID);
                
                    _context.FiEntrySource.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //-------------------------------------------------------------
        // Select * (FI)EntrySource { with CreateUserName , UpdateUserName  }
        //-------------------------------------------------------------
        public List<FiEntrySourceGetVM> GetAll()
            => _context.FiEntrySource.Select
            (n => new FiEntrySourceGetVM
            {

                Id = n.Id,
                Name = n.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreateUserName = n.CreatedBy.Name,

                UpdateUserName = n.UpdateBy.Name

            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiEntrySourceGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiEntrySource.Count();
            List<FiEntrySourceGetVM> Item = _context.FiEntrySource
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiEntrySourceGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiEntrySourceGetVM>
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
        //---------------------------------------------------------------------------------
        // Select * (FI)EntrySource where {id = EntryID} { with CreateUserName , UpdateUserName } 
        //---------------------------------------------------------------------------------
        public FiEntrySourceGetVM GetById(int ID)
            => _context.FiEntrySource.Select(
                n => new FiEntrySourceGetVM
                {
                    Id = n.Id,
                    Name = n.Name,


                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.UpdateBy.Id,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);
    }
}
