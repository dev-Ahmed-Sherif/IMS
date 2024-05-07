using Entities.Models.FI;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Entry
{
    public class FiEntrySourceTypeRepository
    {
        private AppDbContext _context;
        public FiEntrySourceTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        //-------------------------
        // Add new (FI)EntryEntrySourceType
        //-------------------------
        public string Add(FiEntrySourceTypeGeneralVM ID)
        {
            bool exists = _context.FiEntrySourceType.Any(s => s.Name == ID.Name);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = new FiEntrySourceType()
                {
                    Name = ID.Name,
                    EntrySourceId = ID.EntrySourceId,

                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiEntrySourceType.Add(_Row);
                _context.SaveChanges();
                return _Row.Id.ToString();
          
        }
        //------------------------------------------
        // Update (FI)EntrySourceType { where id == Entry.id } 
        //------------------------------------------
        public string Update(FiEntrySourceTypeVM ID)
        {
            bool exists = _context.FiEntrySourceType.Any(s => s.Name == ID.Name && s.Id != ID.Id);
            if (exists)
            {
                return " Name already exists.";
            }

            var _Row = _context.FiEntrySourceType.Single(n => n.Id == ID.Id);
              _Row.Name = ID.Name;
                    _Row.EntrySourceId = ID.EntrySourceId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //------------------------------------------
        // Dellete (FI)EntrySourceType { where id == EntryID }
        //------------------------------------------
        public string Delete(int ID)
        {
            try
            {
                var _Row = _context.FiEntrySourceType.Single(n => n.Id == ID);
                if (_Row != null)
                {
                    _context.FiEntrySourceType.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //-------------------------------------------------------------
        // Select * (FI)EntrySourceType { with CreateUserName , UpdateUserName  }
        //-------------------------------------------------------------
        public List<FiEntrySourceTypeGetVM> GetAll()
            => _context.FiEntrySourceType.Select
            (n => new FiEntrySourceTypeGetVM
            {

                Id = n.Id,
                Name = n.Name,
                EntrySourceId = n.EntrySourceId,
                FiEntrySourceName = n.EntrySource.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreateUserName = n.CreatedBy.Name,
                UpdateUserName = n.UpdateBy.Name

            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiEntrySourceTypeGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiEntrySourceType.Count();
            List<FiEntrySourceTypeGetVM> Item = _context.FiEntrySourceType
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiEntrySourceTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    EntrySourceId = n.EntrySourceId,
                    FiEntrySourceName = n.EntrySource.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<FiEntrySourceTypeGetVM>
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
        // Select * (FI)EntrySourceType where {id = EntryID} { with CreateUserName , UpdateUserName } 
        //---------------------------------------------------------------------------------
        public FiEntrySourceTypeGetVM GetById(int ID)
            => _context.FiEntrySourceType.Select(
                n => new FiEntrySourceTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    EntrySourceId = n.EntrySourceId,
                    FiEntrySourceName = n.EntrySource.Name,
                    TransactionUserId = n.UpdateBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);

    }
}
