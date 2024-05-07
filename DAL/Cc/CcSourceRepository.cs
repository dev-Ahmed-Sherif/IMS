using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcSourceRepository

    {
        private AppDbContext _context;

        public CcSourceRepository(AppDbContext context)
        {
            _context = context;
        }
        //-----------------------------------------------------
        //Autocode function (frome 2 degits)
        public string GetLastNo()
        {
            try
            {
                string maxNo = _context.CcSource

                .Select(item => item.Code)
                .Max();

                if (maxNo == null)
                {
                    maxNo = "0";
                }
                int intmaxNo = int.Parse(maxNo);

                intmaxNo = intmaxNo + 1;

                maxNo = intmaxNo.ToString();
                if (maxNo.Length == 1)
                {
                    maxNo = "0" + intmaxNo;
                }


                return maxNo.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
        public string Add(CcSourceGeneralVM ccsour)
        {
           
                var _ccsour = new CcSource()
                {
                    Name = ccsour.Name,

                    Code = ccsour.Code,
                    FunctionId = ccsour.FunctionId,

                    CreatedByID = ccsour.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcSource.Add(_ccsour);
                _context.SaveChanges();
                return _ccsour.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(CcSourceVM cc_sour)
        {
            
                var _cc_sour = _context.CcSource.Single(n => n.Id == cc_sour.Id);
               
                    _cc_sour.Name = cc_sour.Name;
                    _cc_sour.Code = cc_sour.Code;
                    _cc_sour.FunctionId = cc_sour.FunctionId;
                    _cc_sour.UpdateByID = cc_sour.TransactionUserId;
                    _cc_sour.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //--------------------------------------------
        //delet function

        public string Delete(int CcSource_Id)
        {
            
                var _CcSource = _context.CcSource.Single(n => n.Id == CcSource_Id);
              
                    _context.CcSource.Remove(_CcSource);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //-----------------------------------
        //get function
        public List<CcSourceGetVM> GetAll()
            => _context.CcSource.Select(n => new CcSourceGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                FunctionId = n.FunctionId,
                FunctionName = n.Function.Name,
                FunctionCode = n.Function.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcSourceGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcSource.Count();
            List<CcSourceGetVM> Item = _context.CcSource
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcSourceGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FunctionId = n.FunctionId,
                    FunctionName = n.Function.Name,
                    FunctionCode = n.Function.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcSourceGetVM>
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
        public CcSourceGetVM GetById(int itemId) => _context.CcSource.Select(n => new CcSourceGetVM { Id = n.Id, Name = n.Name, Code = n.Code, FunctionId = n.FunctionId, FunctionName = n.Function.Name, FunctionCode = n.Function.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);

    }
}
