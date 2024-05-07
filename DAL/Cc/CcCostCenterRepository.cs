using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcCostCenterRepository
    {
        private AppDbContext _context;
        public CcCostCenterRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetLastCode()
        {
            string maxNo = _context.CcCostCenter
             .Select(item => item.Code)
             .Max();
            Int64 intmaxNo = Int64.Parse(maxNo);

            if (intmaxNo == 0)
            {
                intmaxNo = 1;
            }
            else
            {
                intmaxNo = intmaxNo + 1;
            }
            maxNo = intmaxNo.ToString();
            return maxNo.ToString();

        }
        //----------------------------------------------
        //add function
        public string Add(CcCostCenterGeneralVM Add)
        {
          
                var _Add = new CcCostCenter()
                {
                    Name = Add.Name,
                    Code = Add.Code,
                    FunctionId = Add.FunctionId,
                    SourceId = Add.SourceId,
                    RegionId = Add.RegionId,
                    SubRegionId = Add.SubRegionId,
                    PlantId = Add.PlantId,
                    PlantComponentId = Add.PlantComponentId,
                    ActivityId = Add.ActivityId,
                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcCostCenter.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
          
        }
        //-----------------------------------------------
        //update function
        public string Update(CcCostCenterVM update)
        {
            
                var _update = _context.CcCostCenter.Single(n => n.Id == update.Id);
              
                    _update.Name = update.Name;
                    _update.Code = update.Code;
                    _update.FunctionId = update.FunctionId;
                    _update.SourceId = update.SourceId;
                    _update.RegionId = update.RegionId;
                    _update.SubRegionId = update.SubRegionId;
                    _update.PlantId = update.PlantId;
                    _update.PlantComponentId = update.PlantComponentId;
                    _update.ActivityId = update.ActivityId;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
          
        }

        //--------------------------------------------
        //delet function

        public string Delete(int dele_Id)
        {
            
                var _dele = _context.CcCostCenter.Single(n => n.Id == dele_Id);
               
                    _context.CcCostCenter.Remove(_dele);
                    _context.SaveChanges();
                    return "Succeeded";

        }
        //-----------------------------------
        //get function
        public List<CcCostCenterGetVM> GetAll()
            => _context.CcCostCenter.Select(n => new CcCostCenterGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                FunctionId = n.FunctionId,
                FunctionName = n.Function.Name,
                FunctionCode = n.Function.Code,
                SourceId = n.SourceId,
                SourceName = n.Source.Name,
                SourceCode = n.Source.Code,
                RegionId = n.RegionId,
                RegionName = n.Region.Name,
                RegionCode = n.Region.Code,
                SubRegionId = n.SubRegionId,
                SubRegionName = n.SubRegion.Name,
                SubRegionCode = n.SubRegion.Code,
                PlantId = n.PlantId,
                PlantName = n.Plant.Name,
                PlantCode = n.Plant.Code,
                PlantComponentId = n.PlantComponentId,
                PlantComponentName = n.PlantComponent.Name,
                PlantComponentCode = n.PlantComponent.Code,
                ActivityId = n.ActivityId,
                ActivityName = n.Activity.Name,
                ActivityCode = n.Activity.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public CcCostCenterGetVM GetById(int itemId)
            => _context.CcCostCenter.Select(n => new CcCostCenterGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                FunctionId = n.FunctionId,
                FunctionName = n.Function.Name,
                FunctionCode = n.Function.Code,
                SourceId = n.SourceId,
                SourceName = n.Source.Name,
                SourceCode = n.Source.Code,
                RegionId = n.RegionId,
                RegionName = n.Region.Name,
                RegionCode = n.Region.Code,
                SubRegionId = n.SubRegionId,
                SubRegionName = n.SubRegion.Name,
                SubRegionCode = n.SubRegion.Code,
                PlantId = n.PlantId,
                PlantName = n.Plant.Name,
                PlantCode = n.Plant.Code,
                PlantComponentId = n.PlantComponentId,
                PlantComponentName = n.PlantComponent.Name,
                PlantComponentCode = n.PlantComponent.Code,
                ActivityId = n.ActivityId,
                ActivityName = n.Activity.Name,
                ActivityCode = n.Activity.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcCostCenterGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcCostCenter.Count();
            List<CcCostCenterGetVM> Item = _context.CcCostCenter
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcCostCenterGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FunctionId = n.FunctionId,
                    FunctionName = n.Function.Name,
                    FunctionCode = n.Function.Code,
                    SourceId = n.SourceId,
                    SourceName = n.Source.Name,
                    SourceCode = n.Source.Code,
                    RegionId = n.RegionId,
                    RegionName = n.Region.Name,
                    RegionCode = n.Region.Code,
                    SubRegionId = n.SubRegionId,
                    SubRegionName = n.SubRegion.Name,
                    SubRegionCode = n.SubRegion.Code,
                    PlantId = n.PlantId,
                    PlantName = n.Plant.Name,
                    PlantCode = n.Plant.Code,
                    PlantComponentId = n.PlantComponentId,
                    PlantComponentName = n.PlantComponent.Name,
                    PlantComponentCode = n.PlantComponent.Code,
                    ActivityId = n.ActivityId,
                    ActivityName = n.Activity.Name,
                    ActivityCode = n.Activity.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcCostCenterGetVM>
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
