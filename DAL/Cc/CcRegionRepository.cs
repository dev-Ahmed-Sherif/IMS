using Entities.Models;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcRegionRepository
    {
        private AppDbContext _context;

        public CcRegionRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.CcRegion
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
        //---------------------------------------------
        //add function
        public string Add(CcRegionGeneralVM ccreg)
        {
           
                var _ccreg = new CcRegion()
                {
                    Name = ccreg.Name,

                    Code = ccreg.Code,

                    CreatedByID = ccreg.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcRegion.Add(_ccreg);
                _context.SaveChanges();
                return _ccreg.Id.ToString();
           

        }
        //-----------------------------------------------
        //update function
        public string Update(CcRegionVM cc_reg)
        {
           
                var _cc_reg = _context.CcRegion.Single(n => n.Id == cc_reg.Id);
               
                    _cc_reg.Name = cc_reg.Name;
                    _cc_reg.Code = cc_reg.Code;
                    _cc_reg.UpdateByID = cc_reg.TransactionUserId;
                    _cc_reg.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //--------------------------------------------
        //delet function

        public string Delete(int CcRegion_Id)
        {
           
                var _CcRegion = _context.CcRegion.Single(n => n.Id == CcRegion_Id);
               
                    _context.CcRegion.Remove(_CcRegion);
                    _context.SaveChanges();
                    return "Succeeded";
                
          

        }
        //-----------------------------------
        //get function
        public List<CcRegionGetVM> GetAll()
            => _context.CcRegion.Select(n => new CcRegionGetVM
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
        public PaginatedResult<CcRegionGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcRegion.Count();
            List<CcRegionGetVM> Item = _context.CcRegion
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcRegionGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcRegionGetVM>
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
        public CcRegionGetVM GetById(int itemId) => _context.CcRegion.Select(n => new CcRegionGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == itemId);

    }
}
