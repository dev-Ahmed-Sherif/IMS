using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyExchangeRepository
    {
        private AppDbContext _context;
        public PyExchangeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyExchangeVM Exchange)
        {
         
                var _PyExchange = new PyExchange()
                {
                    Name = Exchange.Name,
                    No = Exchange.No,
                    FiscalYearId = Exchange.FiscalYearId,
                    Date = Exchange.Date,
                    Description = Exchange.Description,

                    CreatedByID = Exchange.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyExchange.Add(_PyExchange);
                _context.SaveChanges();
                return _PyExchange.Id.ToString();
           
        }
        public string Update(PyExchangeVM Exchange)
        {
           
                var _Exchange = _context.PyExchange.Single(n => n.Id == Exchange.Id);
               
                    _Exchange.Name = Exchange.Name;
                    _Exchange.No = Exchange.No;
                    _Exchange.FiscalYearId = Exchange.FiscalYearId;
                    _Exchange.Date = Exchange.Date;
                    _Exchange.Description = Exchange.Description;




                    _Exchange.UpdateByID = Exchange.TransactionUserId;
                    _Exchange.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public string Delete(int ExchangeId)
        {
            
                var _Exchange = _context.PyExchange.Single(n => n.Id == ExchangeId);
              
                    _context.PyExchange.Remove(_Exchange);
                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyExchangeGetVM> GetAll() =>
            _context.PyExchange.Select(
                n => new PyExchangeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    No = n.No,
                    Date = n.Date,
                    FiscalYearId = n.FiscalYearId,
                    FiscalYear = n.FiscalYear.fiscalyear,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //----------------------------------
        // GET { Data By ID => ExchangeId } 
        //----------------------------------
        public PyExchangeGetVM GetById(int ExchangeId)
            => _context.PyExchange.Select(
                n => new PyExchangeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    No = n.No,
                    Date = n.Date,
                    FiscalYearId = n.FiscalYearId,
                    FiscalYear = n.FiscalYear.fiscalyear,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ExchangeId);
        public List<PyExchangeGetVM> Search(search searchModel)
        {
            var query = _context.PyExchange.AsQueryable();
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.fiscalyearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.fiscalyearId);
            }

            var results = query.Select(p => new PyExchangeGetVM
            {
                Id = p.Id,
                Name = p.Name,
                No = p.No,
                Date = p.Date,
                FiscalYearId = p.FiscalYearId,
                FiscalYear = p.FiscalYear.fiscalyear,
                Description = p.Description,
                CreateUserName = p.CreatedBy.Name,
                TransactionUserId = p.CreatedBy.Id
            }).ToList();

            return results;

        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<PyExchangeGetVM> getAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyExchange.Count();
            List<PyExchangeGetVM> item = _context.PyExchange
                .OrderByDescending(item => item.Date)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyExchangeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    No = n.No,
                    Date = n.Date,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();
            var paginatedResult = new PaginatedResult<PyExchangeGetVM>
            {
                Items = item,
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
