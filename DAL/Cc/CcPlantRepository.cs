using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcPlantRepository
    {
        private AppDbContext _context;
        public CcPlantRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------
        //auto code function
        public string GetLastNo(int SubRegionId)
        {


            try
            {
                int maxNo = _context.CcSubRegion.Select(item => item.Code).DefaultIfEmpty().Max();
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
        public string Add(CcPlantGeneralVM Add)
        {
           
                var _Add = new CcPlant()
                {
                    Name = Add.Name,

                    Code = Add.Code,
                    SubRegionId = Add.SubRegionId,

                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcPlant.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(CcPlantVM update)
        {
            
                var _update = _context.CcPlant.Single(n => n.Id == update.Id);
                
                    _update.Name = update.Name;
                    _update.Code = update.Code;
                    _update.SubRegionId = update.SubRegionId;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
             
        }

        //--------------------------------------------
        //delet function

        public string Delete(int dele_Id)
        {
           
                var _dele = _context.CcPlant.Single(n => n.Id == dele_Id);
              
                    _context.CcPlant.Remove(_dele);
                    _context.SaveChanges();
                    return "Succeeded";
            

        }
        //-----------------------------------
        //get function
        public List<CcPlantGetVM> GetAll()
            => _context.CcPlant.Select(n => new CcPlantGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                SubRegionId = n.SubRegionId,
                SubRegionName = n.SubRegion.Name,
                SubRegionCode = n.SubRegion.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcPlantGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcPlant.Count();
            List<CcPlantGetVM> Item = _context.CcPlant
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcPlantGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    SubRegionId = n.SubRegionId,
                    SubRegionName = n.SubRegion.Name,
                    SubRegionCode = n.SubRegion.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcPlantGetVM>
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

        public CcPlantGetVM GetById(int itemId)
            => _context.CcPlant.Select(n => new CcPlantGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                SubRegionId = n.SubRegionId,
                SubRegionName = n.SubRegion.Name,
                SubRegionCode = n.SubRegion.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }). Single(n => n.Id == itemId);

    }
}
