using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcSubRegionRepository
    {
        private AppDbContext _context;
        public CcSubRegionRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------
        //auto code function
        public string GetLastNo(int RegionId)
        {


            try
            {
                int maxNo = _context.CcRegion.Where(item => item.Id == RegionId).Select(item => item.Code).DefaultIfEmpty().Max();
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
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //----------------------------------------------
        //add function
        public string Add(CcSubRegionGeneralVM ccsub)
        {
           
                var _ccsub = new CcSubRegion()
                {
                    Name = ccsub.Name,

                    Code = ccsub.Code,
                    RegionId = ccsub.RegionId,

                    CreatedByID = ccsub.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcSubRegion.Add(_ccsub);
                _context.SaveChanges();
                return _ccsub.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(CcSubRegionVM cc_sub)
        {

            var entity =
                _context
                .CcSubRegion
                .Single(n => n.Id == cc_sub.Id) ??
                throw new KeyNotFoundException();

            if (!string.IsNullOrWhiteSpace(entity.Name))
            {
                entity.Name = cc_sub.Name;
            }
            entity.Code = cc_sub.Code;
            entity.RegionId = cc_sub.RegionId;
            entity.UpdateByID = cc_sub.TransactionUserId;
            entity.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";

        }

        //--------------------------------------------
        //delet function

        public string Delete(int CcSubRegion_Id)
        {
                var _CcSubRegion = _context.CcSubRegion.Single(n => n.Id == CcSubRegion_Id);
               
                    _context.CcSubRegion.Remove(_CcSubRegion);
                    _context.SaveChanges();
                    return "Succeeded";
                
            

        }
        //-----------------------------------
        //get function
        public List<CcSubRegionGetVM> GetAll()
            => _context.CcSubRegion.Select(n => new CcSubRegionGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                RegionId = n.RegionId,
                RegionName = n.Region.Name,
                RegionCode = n.Region.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcSubRegionGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcSubRegion.Count();
            List<CcSubRegionGetVM> Item = _context.CcSubRegion
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcSubRegionGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    RegionId = n.RegionId,
                    RegionName = n.Region.Name,
                    RegionCode = n.Region.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcSubRegionGetVM>
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
        public CcSubRegionGetVM GetById(int itemId) => _context.CcSubRegion.Select(n => new CcSubRegionGetVM { Id = n.Id, Name = n.Name, Code = n.Code, RegionId = n.RegionId, RegionName = n.Region.Name, RegionCode = n.Region.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);

    }
}
