using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyTaxBracketRepository
    {
        private AppDbContext _context;
        public PyTaxBracketRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyTaxBracketVM TaxBracket)
        {
        
                var _PyTaxBracket = new PyTaxBracket()
                {
                    Value = TaxBracket.Value,
                    Ratio = TaxBracket.Ratio,






                    CreatedByID = TaxBracket.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyTaxBracket.Add(_PyTaxBracket);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(PyTaxBracketVM TaxBracket)
        {
          
                var _TaxBracket = _context.PyTaxBracket.Single(n => n.Id == TaxBracket.Id);
              
                    _TaxBracket.Value = TaxBracket.Value;

                    _TaxBracket.Ratio = TaxBracket.Ratio;


                    _TaxBracket.UpdateByID = TaxBracket.TransactionUserId;
                    _TaxBracket.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public string Delete(int TaxBracketId)
        {
             var _TaxBracket = _context.PyTaxBracket.Single(n => n.Id == TaxBracketId);
                
                    _context.PyTaxBracket.Remove(_TaxBracket);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyTaxBracketGetVM> GetAll()
            => _context.PyTaxBracket.Select(
                n => new PyTaxBracketGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    Ratio = n.Ratio,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //----------------------------------------------
        // GET { Data From Table By ID => TaxBracketId } 
        //----------------------------------------------
        public PyTaxBracketGetVM GetById(int TaxBracketId)
            => _context.PyTaxBracket.Select(
                n => new PyTaxBracketGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    Ratio = n.Ratio,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TaxBracketId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyTaxBracketGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyTaxBracket.Count();
            List<PyTaxBracketGetVM> Item = _context.PyTaxBracket
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyTaxBracketGetVM
                {
                    Id = n.Id,
                    Value = n.Value,
                    Ratio = n.Ratio,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyTaxBracketGetVM>
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
