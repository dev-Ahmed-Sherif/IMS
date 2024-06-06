using Entities.Helpers;
using Entities.Enums;
using Entities.ExtensionMethods.STR.Withdraw;
using Entities.Models.STR.WithDraw;
using Entities.ViewModels;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.STR.WithDraw
{
    public class StrWithDrawRepository
    {
        private AppDbContext _context;
        public StrWithDrawRepository(AppDbContext context)
        {
            _context = context;
        }
        public int GetLastNo(int StoreId, int FiscalYearId)
        {
            int maxNo = _context.StrWithDraw.Where(item => item.StoreId == StoreId && item.FiscalYearId == FiscalYearId).Select(item => item.No).DefaultIfEmpty().Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {
                maxNo = maxNo + 1;
            }

            return maxNo;
        }
        public async Task<string> Add(StrWithdrawGeneralVM types)
        {
            if (!types.CostCenterId.HasValue &&!types.DestStoreId.HasValue) throw new Exception("CostCenterId or DestStoreId is required");
                var _withdraw = new StrWithDraw()
                {
                    Type = types.Type,
                    No = types.No,
                    Date = types.Date,
                    Total = types.Total,
                    Notes = types.Notes,
                    CommodityId = types.CommodityId,
                    WithDrawTypeId = types.WithDrawTypeId,
                    StoreId = types.StoreId,
                    DestStoreConfirm = types.DestStoreConfirm,
                    Attachment = await FileHelper.UploadFile(types.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRWithdraw)),
                    CostCenterId = types.CostCenterId,
                    EmployeeId = types.EmployeeId,

                    DestStoreId = types.DestStoreId,

                    DestStoreUserId = types.DestStoreUserId,

                    FiscalYearId = types.FiscalYearId,

                    CreatedByID = types.TransactionUserId,
                    CreationDate = DateTime.Now
                };

                _context.StrWithDraw.Add(_withdraw);
                _context.SaveChanges();
                return _withdraw.Id.ToString();

        
        }
        public async Task<string> Update(StrWithdrawVM item)
        {
            
                var _item = _context.StrWithDraw.Single(n => n.Id == item.Id);
               

                    _item.No = item.No;

                    _item.Type = item.Type;
                    _item.Date = item.Date;
                    _item.Total = item.Total;
                    _item.Notes = item.Notes;
                    _item.DestStoreConfirm = item.DestStoreConfirm;
                    _item.Attachment = await FileHelper.UploadFile(item.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRWithdraw));
                    _item.DestStoreId = item.DestStoreId;
                    _item.StoreId = item.StoreId;
                    _item.EmployeeId = item.EmployeeId;
                    _item.CostCenterId = item.CostCenterId;
                    _item.CommodityId = item.CommodityId;
                    _item.WithDrawTypeId = item.WithDrawTypeId;
                    _item.UpdateByID = item.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _item.FiscalYearId = item.FiscalYearId;
                    _context.SaveChanges();
                    return "Succeeded";
              
           
        }
        public string Delete(int withdrawId)
        {
            
                var _item = _context.StrWithDraw.Single(n => n.Id == withdrawId);
               

                    var DetailsToDelete = _context.StrWithDrawDetails.Where(n => n.STR_WithdrawId == withdrawId).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.StrWithDrawDetails.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.StrWithDraw.Remove(_item);
                    _context.SaveChanges();
                    return "Succeeded";
              
          
        }
        public List<StrWithdrawGetVM> GetAll()
        {
            var all = _context.StrWithDraw.Select(n => n.ToStrWithdrawGetVM());
            return all.ToList();
        }

        public StrWithdrawGetVM GetById(int withdrawId)
        {

            return _context.StrWithDraw.Single(e => e.Id == withdrawId).ToStrWithdrawGetVM();
        }
        public List<StrWithdrawGetVM> Search(searchwithdraw searchModel)
        {
            var query = _context.StrWithDraw.AsQueryable();

            if (searchModel.StoreId.HasValue)
            {
                query = query.Where(p => p.StoreId == searchModel.StoreId);
            }
            if (searchModel.id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.id);
            }
            if (searchModel.DestStoreId.HasValue)
            {
                query = query.Where(p => p.DestStoreId == searchModel.DestStoreId);
            }
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.ItemId.HasValue)
            {
                query = query.Where(p => p.STR_Withdraw_Details.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.DestStoreId.HasValue)
            {
                query = query.Where(p => p.DestStoreId == searchModel.DestStoreId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.STR_Store.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrWithdrawGetVM
            {
                Id = p.Id,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                StartDate = searchModel.StartDate.HasValue ? searchModel.StartDate.Value.ToString("dd/MM/yyyy") : "",
                EndDate = searchModel.EndDate.HasValue ? searchModel.EndDate.Value.ToString("dd/MM/yyyy") : "",
                Date = p.Date,
                No = p.No,
                Total = p.Total,
                Notes = p.Notes,
                Type = p.Type,
                DestStoreConfirm = p.DestStoreConfirm,
                Attachment = p.Attachment,
                StoreId = p.StoreId,
                EmployeeId = p.EmployeeId,
                CostCenterId = p.CostCenterId,
                DestStoreUserId = p.DestStoreUserId,
                DestStoreId = p.DestStoreId,
                storeName = p.STR_Store.Name,
                EmployeeName = p.HR_Employee.Name,
                CostCenterName = p.CostCenter.Name,
                DesstoreName = p.DestStore.Name,
                DesstoreUserName = p.DestStoreUser.Name,
                CommodityId = p.CommodityId,
                CommodityName = p.STR_Commodity.Name,
                WithDrawTypeId = p.WithDrawTypeId,
                WithDrawTypeName = p.WithDrawType.Name,
                fiscalyear = p.Fiscalyear.fiscalyear,
                TransactionUserId = p.CreatedBy.Id,
                FiscalYearId = p.FiscalYearId,
                CreateUserName = p.CreatedBy.Name,
                Section = searchModel.SectionId != null ? p.STR_Store.Section.Name : "",
            }).OrderBy(x => x.Date).ThenBy(x => x.Id).ToList();

            return results;
        }
        public List<GetWithDrawDetailsByWithDrawDetailsId> GetByDestStore(int DestStoreId, int fiscalYearId)
        {
            var result =
            _context.
            StrWithDraw
                .Where(e =>
                    e.DestStoreId == DestStoreId &&
                    e.DestStoreConfirm == false &&
                    e.FiscalYearId == fiscalYearId)
                .Select(e => e.ToGetWithDrawDetailsByWithDrawDetailsId())
                .ToList();

            //return result != null ? new List<GetWithDrawDetailsByWithDrawDetailsId> { result } : new List<GetWithDrawDetailsByWithDrawDetailsId>();
            return result;
        }
        //------------------------------------------------
        // Select data form Withdraw by page and page size 
        //------------------------------------------------
        public PaginatedResult<StrWithdrawGetVM> GetByEmployeeStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            List<int> storeIds = _context.StrStore
                .Where(store => store.StorekeeperId == employeeId)
                .Select(store => store.Id)
                .ToList();

            var totalCount = _context.StrWithDraw.Where(sa => storeIds.Contains(sa.StoreId) && sa.FiscalYearId == fiscalYearId).Count();
            List<StrWithdrawGetVM> withDraw;
            if (storeIds.Count > 0)
            {
                 withDraw = _context.StrWithDraw
                    .Where(sa => storeIds.Contains(sa.StoreId) && sa.FiscalYearId == fiscalYearId)
                    .OrderByDescending(Add => Add.Date)
                    .Skip((page) * pageSize)
                    .Take(pageSize)
                    .Select(n => n.ToStrWithdrawGetVM())
                    .ToList();
            }
            else
            {
                withDraw = _context.StrWithDraw
                    .Where(sa => sa.FiscalYearId == fiscalYearId)
                    .OrderByDescending(Add => Add.Date)
                    .Skip((page) * pageSize)
                    .Take(pageSize)
                    .Select(n => n.ToStrWithdrawGetVM())
                    .ToList();

                totalCount = _context.StrWithDraw
                    .Where(sa => sa.FiscalYearId == fiscalYearId).Count();
            }

            var paginatedResult = new PaginatedResult<StrWithdrawGetVM>
            {
                Items = withDraw,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
    }
}
