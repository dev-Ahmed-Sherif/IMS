using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyExchangeDetailsRepository
    {

        private AppDbContext _context;
        public PyExchangeDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyExchangeDetailsVM ExchangeDetails)
        {
              var _PyExchangeDetails = new PyExchangeDetails()
                {
                    Value = ExchangeDetails.Value,
                    EmployeeId = ExchangeDetails.EmployeeId,
                    ExChangeId = ExchangeDetails.ExChangeId,
                    PyItemId = ExchangeDetails.PyItemId,

                    CreatedByID = ExchangeDetails.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyExchangeDetails.Add(_PyExchangeDetails);
                _context.SaveChanges();
                return "Succeeded";
         
        }
        public string Update(PyExchangeDetailsVM ExchangeDetails)
        {
          
                var _ExchangeDetails = _context.PyExchangeDetails.Single(n => n.Id == ExchangeDetails.Id);
              
                    _ExchangeDetails.Value = ExchangeDetails.Value;
                    _ExchangeDetails.EmployeeId = ExchangeDetails.EmployeeId;
                    _ExchangeDetails.ExChangeId = ExchangeDetails.ExChangeId;
                    _ExchangeDetails.PyItemId = ExchangeDetails.PyItemId;
                    _ExchangeDetails.UpdateByID = ExchangeDetails.TransactionUserId;
                    _ExchangeDetails.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public string Delete(int ExchangeDetailsId)
        {
            
                var _ExchangeDetails = _context.PyExchangeDetails.Single(n => n.Id == ExchangeDetailsId);
              
                    _context.PyExchangeDetails.Remove(_ExchangeDetails);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyExchangeDetailsGetVM> GetAll()
            => _context.PyExchangeDetails.Select(
                n => new PyExchangeDetailsGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    ExChangeId = n.ExChangeId,
                    ExChangeName = n.ExChange.Name,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------------
        // GET { Data From Table By ID => ExchangeDetailsId } 
        //---------------------------------------------------
        public PyExchangeDetailsGetVM GetById(int ExchangeDetailsId)
            => _context.PyExchangeDetails.Select(
                n => new PyExchangeDetailsGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    ExChangeId = n.ExChangeId,
                    ExChangeName = n.ExChange.Name,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ExchangeDetailsId);
        //------------------------------------
        // GET { Data From Table By HeaderID } 
        //------------------------------------
        public List<PyExchangeDetailsGetVM> GetByHeader(int HeaderId)
           => _context.PyExchangeDetails
              .Where(ssd => ssd.ExChangeId == HeaderId)
                        .Select(ssd => new PyExchangeDetailsGetVM
                        {
                            ExChangeId = ssd.ExChangeId,
                            HeaderName = ssd.ExChange.Name,
                            HeaderNo = ssd.ExChange.No,
                            HeaderDate = ssd.ExChange.Date,
                            HeaderDescription = ssd.ExChange.Description,
                            Id = ssd.Id,
                            Value = ssd.Value,
                            ExChangeName = ssd.ExChange.Name,
                            EmployeeId = ssd.EmployeeId,
                            EmployeeName = ssd.Employee.Name,
                            PyItemId = ssd.PyItemId,
                            PyItemName = ssd.PyItem.Name,
                            CreateUserName = ssd.CreatedBy.Name,
                            TransactionUserId = ssd.CreatedBy.Id

                        }).ToList();
        //---------------------------------------------------
        // Search By { No, StartDate, EndDate, fiscalyearId }
        //---------------------------------------------------
        public List<PyExchangeDetailsGetVM> Search(search searchModel)
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
            }).ToList();
            List<PyExchangeDetailsGetVM> items = new List<PyExchangeDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item.Id);
                if (isNotNull != null)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;

        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize , user_id )} 
        //----------------------------------------------------------
        public PaginatedResult<PyExchangeDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.PyExchangeDetails.Where(n => n.ExChangeId == HeaderId).Count();
            List<int> ExChangeId = _context.PyExchangeDetails
                .Where(sus => sus.ExChangeId == HeaderId)
                .Select(sus => sus.ExChangeId)
                .ToList();
            List<PyExchangeDetailsGetVM> Item = _context.PyExchangeDetails
                .Where(n => ExChangeId.Contains(n.ExChangeId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyExchangeDetailsGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    ExChangeId = n.ExChangeId,
                    ExChangeName = n.ExChange.Name,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyExchangeDetailsGetVM>
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
