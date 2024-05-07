using Entities.Models.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Fa
{
    public class FaMoveFixedAssetRepository
    {
        private AppDbContext _context;

        public FaMoveFixedAssetRepository(AppDbContext context)
        {
            _context = context;
        }

        //------------------
        //add function
        //------------------
        public string Add(FaMoveFixedAssetGeneralVM add)
        {
          
                var _add = new FaMoveFixedAsset()
                {

                    Move_Type = add.Move_Type,
                    Move_No = add.Move_No,
                    Description = add.Description,
                    Statement = add.Statement,
                    Document_NO = add.Document_NO,
                    Document_Date = add.Document_Date,
                    Rate = add.Rate,
                    CostCenterId = add.CostCenterId,
                    FixedAssetId = add.FixedAssetId,
                    ActivityId = add.ActivityId,


                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now


                };
                _context.FaMoveFixedAsset.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
           
        }

        //------------------
        //update function
        //------------------
        public string Update(FaMoveFixedAssetVM Update)
        {
           
                var _update = _context.FaMoveFixedAsset.Single(n => n.Id == Update.Id);
              
                    _update.Move_Type = Update.Move_Type;
                    _update.Description = Update.Description;
                    _update.Move_No = Update.Move_No;
                    _update.Statement = Update.Statement;
                    _update.Document_NO = Update.Document_NO;
                    _update.Document_Date = Update.Document_Date;
                    _update.Rate = Update.Rate;
                    _update.CostCenterId = Update.CostCenterId;
                    _update.CostCenterId = Update.CostCenterId;
                    _update.FixedAssetId = Update.FixedAssetId;
                    _update.ActivityId = Update.ActivityId;
                    _update.UpdateByID = Update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //----------------
        //delete function
        //----------------
        public string Delete(int Row_Id)
        {
           
                var _Row = _context.FaMoveFixedAsset.Single(n => n.Id == Row_Id);
              
                    _context.FaMoveFixedAsset.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
               

        }

        public FaMoveFixedAssetGetVM GetById(int itemId) => _context.FaMoveFixedAsset
            .Select(n => new FaMoveFixedAssetGetVM
            {
                Id = n.Id,
                Move_Type = n.Move_Type,
                Description = n.Description,
                Move_No = n.Move_No,
                Statement = n.Statement,
                Document_NO = n.Document_NO,
                Document_Date = n.Document_Date,
                Rate = n.Rate,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                FixedAssetId = n.FixedAssetId,
                FixedAssetName = n.FixedAsset.Name,
                ActivityId = n.ActivityId,
                ActivityName = n.Activity.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);

        public List<FaMoveFixedAssetGetVM> GetAll() => _context.FaMoveFixedAsset
            .Select(n => new FaMoveFixedAssetGetVM
            {
                Id = n.Id,
                Move_Type = n.Move_Type,
                Description = n.Description,
                Move_No = n.Move_No,
                Statement = n.Statement,
                Document_NO = n.Document_NO,
                Document_Date = n.Document_Date,
                Rate = n.Rate,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                FixedAssetId = n.FixedAssetId,
                FixedAssetName = n.FixedAsset.Name,
                ActivityId = n.ActivityId,
                ActivityName = n.Activity.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public List<FaMoveFixedAssetGetVM> Search(SearchGeneralMove searchModel)
        {
            var query = _context.FaMoveFixedAsset.AsQueryable();
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.FixedAssetId.HasValue)
            {
                query = query.Where(p => p.FixedAssetId == searchModel.FixedAssetId);
            }

            if (searchModel.ActivityId.HasValue)
            {
                query = query.Where(p => p.ActivityId == searchModel.ActivityId);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.Rate.HasValue)
            {
                query = query.Where(p => p.Rate == searchModel.Rate);
            }
            if (searchModel.Document_Date.HasValue)
            {
                query = query.Where(p => p.Document_Date == searchModel.Document_Date);
            }
            if (searchModel.Document_NO.HasValue)
            {
                query = query.Where(p => p.Document_NO == searchModel.Document_NO);
            }
            if (searchModel.Move_No.HasValue)
            {
                query = query.Where(p => p.Move_No == searchModel.Move_No);
            }


            if (!string.IsNullOrEmpty(searchModel.Move_Type))
            {
                query = query.Where(p => p.Move_Type.Contains(searchModel.Move_Type));
            }


            var results = query.Select(n => new FaMoveFixedAssetGetVM
            {
                Id = n.Id,
                Move_Type = n.Move_Type,
                Description = n.Description,
                Move_No = n.Move_No,
                Statement = n.Statement,
                Document_NO = n.Document_NO,
                Document_Date = n.Document_Date,
                Rate = n.Rate,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                FixedAssetId = n.FixedAssetId,
                FixedAssetName = n.FixedAsset.Name,
                ActivityId = n.ActivityId,
                ActivityName = n.Activity.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();


            return results;

        }
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<FaMoveFixedAssetGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FaMoveFixedAsset.Count();
            List<FaMoveFixedAssetGetVM> Item = _context.FaMoveFixedAsset
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FaMoveFixedAssetGetVM
                {
                    Id = n.Id,
                    Move_Type = n.Move_Type,
                    Description = n.Description,
                    Move_No = n.Move_No,
                    Statement = n.Statement,
                    Document_NO = n.Document_NO,
                    Document_Date = n.Document_Date,
                    Rate = n.Rate,
                    CostCenterId = n.CostCenterId,
                    CostCenterName = n.CostCenter.Name,
                    FixedAssetId = n.FixedAssetId,
                    FixedAssetName = n.FixedAsset.Name,
                    ActivityId = n.ActivityId,
                    ActivityName = n.Activity.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id


                })
                .ToList();

            var paginatedResult = new PaginatedResult<FaMoveFixedAssetGetVM>
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

