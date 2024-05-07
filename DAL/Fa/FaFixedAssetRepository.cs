using Entities.Models.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Fa
{
    public class FaFixedAssetRepository
    {
        private AppDbContext _context;

        public FaFixedAssetRepository(AppDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------
        //add function
        public string Add(FaFixedAssetGeneralVM add)
        {
          
                var _add = new FaFixedAsset()
                {

                    Name = add.Name,
                    Description = add.Description,
                    Place = add.Place,
                    CategoryFirstId = add.CategoryFirstId,
                    CategorySecondId = add.CategorySecondId,
                    CategoryThirdId = add.CategoryThirdId,
                    No = add.No,
                    Code = add.Code,
                    CostCenterId = add.CostCenterId,
                    EntryId = add.EntryId,
                    State = add.State,
                    BuyDate = add.BuyDate,
                    WorkDate = add.WorkDate,
                    InitialValue = add.InitialValue,
                    BookValue = add.BookValue,
                    DepreciationRate = add.DepreciationRate,
                    SpeculateDate = add.SpeculateDate,
                    SpeculateValue = add.SpeculateValue,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now


                };
                _context.FaFixedAsset.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
         
        }

        //-----------------------------------------------
        //update function
        public string Update(FaFixedAssetVM Update)
        {
          
                var _update = _context.FaFixedAsset.Single(n => n.Id == Update.Id);
              
                    _update.Name = Update.Name;
                    _update.Description = Update.Description;
                    _update.Place = Update.Place;
                    _update.CategoryFirstId = Update.CategoryFirstId;
                    _update.CategorySecondId = Update.CategorySecondId;
                    _update.CategoryThirdId = Update.CategoryThirdId;
                    _update.No = Update.No;
                    _update.Code = Update.Code;
                    _update.CostCenterId = Update.CostCenterId;
                    _update.EntryId = Update.EntryId;
                    _update.State = Update.State;
                    _update.BuyDate = Update.BuyDate;
                    _update.WorkDate = Update.WorkDate;
                    _update.InitialValue = Update.InitialValue;
                    _update.BookValue = Update.BookValue;
                    _update.DepreciationRate = Update.DepreciationRate;
                    _update.SpeculateDate = Update.SpeculateDate;
                    _update.SpeculateValue = Update.SpeculateValue;
                    _update.UpdateByID = Update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        //--------------------------------------------
        //delete function

        public string Delete(int Row_Id)
        {
          
                var _Row = _context.FaFixedAsset.Single(n => n.Id == Row_Id);
              

                    _context.FaFixedAsset.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
            

        }
        //get function
        public List<FaFixedAssetGetVM> GetAll() => _context.FaFixedAsset
           .Select(n => new FaFixedAssetGetVM
           {
               Id = n.Id,
               Name = n.Name,
               Description = n.Description,
               Place = n.Place,
               CategoryFirstId = n.CategoryFirstId,
               CategoryFirstName = n.CategoryFirst.Name,
               CategoryFirstCode = n.CategoryFirst.Code,
               CategorySecondId = n.CategorySecondId,
               CategorySecondName = n.CategorySecond.Name,
               CategorySecondCode = n.CategorySecond.Code,
               CategoryThirdId = n.CategoryThirdId,
               CategoryThirdName = n.CategoryThird.Name,
               CategoryThirdCode = n.CategoryThird.Code,
               No = n.No,
               Code = n.Code,
               EntryId = n.EntryId,

               FiEntryNo = n.Entry.No,
               FiEntryDescription = n.Entry.Description,
               FiEntryDate = n.Entry.Date,
               FiEntryCreditTotal = n.Entry.CreditTotal,
               FiEntryDebitTotal = n.Entry.DebitTotal,
               FiEntryBalance = n.Entry.Balance,
               FiEntryState = n.Entry.State,
               CostCenterId = n.CostCenterId,
               CostCenterName = n.CostCenter.Name,
               CostCenterCode = n.CostCenter.Code,
               State = n.State,
               BuyDate = n.BuyDate,
               WorkDate = n.WorkDate,
               InitialValue = n.InitialValue,
               BookValue = n.BookValue,
               DepreciationRate = n.DepreciationRate,
               SpeculateDate = n.SpeculateDate,
               SpeculateValue = n.SpeculateValue,



               CreateUserName = n.CreatedBy.Name,
               TransactionUserId = n.CreatedBy.Id
           }).ToList();

        public FaFixedAssetGetVM GetById(int itemId) => _context.FaFixedAsset
            .Select(n => new FaFixedAssetGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
                Place = n.Place,
                CategoryFirstId = n.CategoryFirstId,
                CategoryFirstName = n.CategoryFirst.Name,
                CategoryFirstCode = n.CategoryFirst.Code,
                CategorySecondId = n.CategorySecondId,
                CategorySecondName = n.CategorySecond.Name,
                CategorySecondCode = n.CategorySecond.Code,
                CategoryThirdId = n.CategoryThirdId,
                CategoryThirdName = n.CategoryThird.Name,
                CategoryThirdCode = n.CategoryThird.Code,
                No = n.No,
                Code = n.Code,
                EntryId = n.EntryId,

                FiEntryNo = n.Entry.No,
                FiEntryDescription = n.Entry.Description,
                FiEntryDate = n.Entry.Date,
                FiEntryCreditTotal = n.Entry.CreditTotal,
                FiEntryDebitTotal = n.Entry.DebitTotal,
                FiEntryBalance = n.Entry.Balance,
                FiEntryState = n.Entry.State,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                CostCenterCode = n.CostCenter.Code,
                State = n.State,
                BuyDate = n.BuyDate,
                WorkDate = n.WorkDate,
                InitialValue = n.InitialValue,
                BookValue = n.BookValue,
                DepreciationRate = n.DepreciationRate,
                SpeculateDate = n.SpeculateDate,
                SpeculateValue = n.SpeculateValue,



                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);
        //auto code
        public string GetLastNo(int CategoryFirstId, int CategorySecondId, int CategoryThirdId)
        {
            string maxNo = _context.FaFixedAsset
             .Where(item => item.CategoryFirstId == CategoryFirstId && item.CategorySecondId == CategorySecondId && item.CategoryThirdId == CategoryThirdId)
             .Select(item => item.No)
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
                maxNo = "000" + intmaxNo;
            }
            if (maxNo.Length == 2)
            {
                maxNo = "00" + intmaxNo;
            }
            if (maxNo.Length == 3)
            {
                maxNo = "0" + intmaxNo;
            }
            return maxNo;

        }
        //search
        public List<FaFixedAssetGetVM> Search(SearchGeneral searchModel)
        {
            var query = _context.FaFixedAsset.AsQueryable();
            if (searchModel.CategoryFirstId.HasValue)
            {
                query = query.Where(p => p.CategoryFirstId == searchModel.CategoryFirstId);
            }
            if (searchModel.CategorySecondId.HasValue)
            {
                query = query.Where(p => p.CategorySecondId == searchModel.CategorySecondId);
            }

            if (searchModel.CategoryThirdId.HasValue)
            {
                query = query.Where(p => p.CategoryThirdId == searchModel.CategoryThirdId);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.EntryId.HasValue)
            {
                query = query.Where(p => p.EntryId == searchModel.EntryId);
            }
            if (searchModel.BuyDate.HasValue)
            {
                query = query.Where(p => p.BuyDate == searchModel.BuyDate);
            }
            if (searchModel.WorkDate.HasValue)
            {
                query = query.Where(p => p.WorkDate == searchModel.WorkDate);
            }
            if (searchModel.SpeculateDate.HasValue)
            {
                query = query.Where(p => p.SpeculateDate == searchModel.SpeculateDate);
            }


            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Place))
            {
                query = query.Where(p => p.Place == searchModel.Place);
            }
            if (!string.IsNullOrEmpty(searchModel.Code))
            {
                query = query.Where(p => p.Code == searchModel.Code);
            }

            var results = query.Select(n => new FaFixedAssetGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
                Place = n.Place,
                CategoryFirstId = n.CategoryFirstId,
                CategoryFirstName = n.CategoryFirst.Name,
                CategoryFirstCode = n.CategoryFirst.Code,
                CategorySecondId = n.CategorySecondId,
                CategorySecondName = n.CategorySecond.Name,
                CategorySecondCode = n.CategorySecond.Code,
                CategoryThirdId = n.CategoryThirdId,
                CategoryThirdName = n.CategoryThird.Name,
                CategoryThirdCode = n.CategoryThird.Code,
                No = n.No,
                Code = n.Code,
                EntryId = n.EntryId,

                FiEntryNo = n.Entry.No,
                FiEntryDescription = n.Entry.Description,
                FiEntryDate = n.Entry.Date,
                FiEntryCreditTotal = n.Entry.CreditTotal,
                FiEntryDebitTotal = n.Entry.DebitTotal,
                FiEntryBalance = n.Entry.Balance,
                FiEntryState = n.Entry.State,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                CostCenterCode = n.CostCenter.Code,
                State = n.State,
                BuyDate = n.BuyDate,
                WorkDate = n.WorkDate,
                InitialValue = n.InitialValue,
                BookValue = n.BookValue,
                DepreciationRate = n.DepreciationRate,
                SpeculateDate = n.SpeculateDate,
                SpeculateValue = n.SpeculateValue,



                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();


            return results;

        }
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<FaFixedAssetGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FaFixedAsset.Count();
            List<FaFixedAssetGetVM> Item = _context.FaFixedAsset
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FaFixedAssetGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Place = n.Place,
                    CategoryFirstId = n.CategoryFirstId,
                    CategoryFirstName = n.CategoryFirst.Name,
                    CategoryFirstCode = n.CategoryFirst.Code,
                    CategorySecondId = n.CategorySecondId,
                    CategorySecondName = n.CategorySecond.Name,
                    CategorySecondCode = n.CategorySecond.Code,
                    CategoryThirdId = n.CategoryThirdId,
                    CategoryThirdName = n.CategoryThird.Name,
                    CategoryThirdCode = n.CategoryThird.Code,
                    No = n.No,
                    Code = n.Code,
                    EntryId = n.EntryId,

                    FiEntryNo = n.Entry.No,
                    FiEntryDescription = n.Entry.Description,
                    FiEntryDate = n.Entry.Date,
                    FiEntryCreditTotal = n.Entry.CreditTotal,
                    FiEntryDebitTotal = n.Entry.DebitTotal,
                    FiEntryBalance = n.Entry.Balance,
                    FiEntryState = n.Entry.State,
                    CostCenterId = n.CostCenterId,
                    CostCenterName = n.CostCenter.Name,
                    CostCenterCode = n.CostCenter.Code,
                    State = n.State,
                    BuyDate = n.BuyDate,
                    WorkDate = n.WorkDate,
                    InitialValue = n.InitialValue,
                    BookValue = n.BookValue,
                    DepreciationRate = n.DepreciationRate,
                    SpeculateDate = n.SpeculateDate,
                    SpeculateValue = n.SpeculateValue,



                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id


                })
                .ToList();

            var paginatedResult = new PaginatedResult<FaFixedAssetGetVM>
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



