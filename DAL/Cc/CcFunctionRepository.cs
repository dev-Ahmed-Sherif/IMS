using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcFunctionRepository
    {
        private AppDbContext _context;
        public CcFunctionRepository(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.CcFunction
             .Select(item => item.Code).DefaultIfEmpty()
             .Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {

                maxNo = maxNo + 1;

            }
            return maxNo.ToString();


        }
        //----------------------------------------------
        //add function
        public string Add(CcFunctionGeneralVM ccfun)
        {
           
                var _ccfun = new CcFunction()
                {
                    Name = ccfun.Name,

                    Code = ccfun.Code,

                    CreatedByID = ccfun.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcFunction.Add(_ccfun);
                _context.SaveChanges();
                return _ccfun.Id.ToString();
       
        }
        //-----------------------------------------------
        //update function
        public string Update(CcFunctionVM cc_fun)
        {
            
                var _cc_fun = _context.CcFunction.Single(n => n.Id == cc_fun.Id);
            
                    _cc_fun.Name = cc_fun.Name;
                    _cc_fun.Code = cc_fun.Code;
                    _cc_fun.UpdateByID = cc_fun.TransactionUserId;
                    _cc_fun.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
          
           
        }

        //--------------------------------------------
        //delet function

        public string Delete(int CcFunction_Id)
        {
           
                var _CcFunction = _context.CcFunction.FirstOrDefault(n => n.Id == CcFunction_Id);
                
                    _context.CcFunction.Remove(_CcFunction);
                    _context.SaveChanges();
                    return "Succeeded";
        

        }
        //-----------------------------------
        //get function
        public List<CcFunctionGetVM> GetAll()
            => _context.CcFunction.Select(n => new CcFunctionGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcFunctionGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcFunction.Count();
            List<CcFunctionGetVM> Item = _context.CcFunction
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcFunctionGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcFunctionGetVM>
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
        public CcFunctionGetVM GetById(int itemId)
            => _context.CcFunction.Select(n => new CcFunctionGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == itemId);

    }
}
