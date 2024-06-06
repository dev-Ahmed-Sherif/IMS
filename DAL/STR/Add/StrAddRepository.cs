using Entities.Helpers;
using Entities.Enums;
using Entities.ExtensionMethods.STR.Add;
using Entities.Models.STR.Add;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.STR.Add
{
    public class StrAddRepository
    {
        private AppDbContext _context;
        public StrAddRepository(AppDbContext context)
        {
            _context = context;
        }

        public int GetLastNo(int StoreId, int FiscalYearId)
        {
            int maxNo = _context.StrAdd.Where(item => item.StoreId == StoreId && item.FiscalYearId == FiscalYearId).Select(item => item.No).DefaultIfEmpty().Max();
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
        public async Task<string> Add(StrAddVM sTR_Add)
        {

            var _sTR_Add = new StrAdd()
            {
                No = sTR_Add.No,
                Date = sTR_Add.Date,
                Total = sTR_Add.Total,
                Notes = sTR_Add.Notes,
                Attachment = await FileHelper.UploadFile(sTR_Add.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRAdd)),
                EntryNo = sTR_Add.EntryNo,
                StoreId = sTR_Add.StoreId,
                FiscalYearId = sTR_Add.FiscalYearId,
                EmployeeId = sTR_Add.EmployeeId,
                SellerId = sTR_Add.SellerId,
                AddTypeId = sTR_Add.AddTypeId,
                CommodityId = sTR_Add.CommodityId,
                Type = sTR_Add.Type,
                //ApprovalStatusId=sTR_Add.ApprovalStatusId,
                //withdrawId=sTR_Add.withdrawId,
                SourceStoreId = sTR_Add.SourceStoreId,
                CreatedByID = sTR_Add.TransactionUserId,
                CreationDate = DateTime.Now

            };
            _context.StrAdd.Add(_sTR_Add);
            _context.SaveChanges();
            return _sTR_Add.Id.ToString();

        }
        public string AddFromStore(AddFromStoreVM item)
        {
            
                switch (item.State)
                {
                    case 1:
                        {
                            //get withdraw data
                            var WithDraw = (from data in _context.StrWithDraw
                                            where data.Id == item.WithDrawId
                                            select new StrWithdrawGeneralVM
                                            {
                                                Date = data.Date,
                                                No = data.No,
                                                Total = data.Total,

                                                Notes = data.Notes,
                                                Type = data.Type,
                                                FiscalYearId = data.FiscalYearId,
                                                DestStoreConfirm = data.DestStoreConfirm,
                                                Attachment = data.Attachment,
                                                StoreId = data.StoreId,
                                                EmployeeId = data.EmployeeId,
                                                CostCenterId = data.CostCenterId,
                                                WithDrawTypeId = data.WithDrawTypeId,
                                                CommodityId = data.CommodityId,
                                                DestStoreUserId = data.DestStoreUserId,
                                                DestStoreId = data.DestStoreId,
                                            }).FirstOrDefault();
                            //insert withdraw data into add data
                            var _sTR_Add = new StrAdd()
                            {
                                No = WithDraw.No,
                                Date = WithDraw.Date,
                                Total = WithDraw.Total,
                                Notes = WithDraw.Notes,
                                Attachment = WithDraw.Attachment,
                                StoreId = (int)WithDraw.DestStoreId,
                                FiscalYearId = WithDraw.FiscalYearId,
                                EmployeeId = WithDraw.EmployeeId,
                                Type = WithDraw.Type,
                                withdrawId = item.WithDrawId,
                                SourceStoreId = WithDraw.StoreId,

                                CreatedByID = item.UserId,
                                CreationDate = DateTime.Now

                            };
                            _context.StrAdd.Add(_sTR_Add);
                            _context.SaveChanges();
                            //insert withdraw details as add details
                            var WithDrawDetails = (from DetailsTable in _context.StrWithDrawDetails
                                                   where DetailsTable.STR_WithdrawId == item.WithDrawId
                                                   select new StrWithDrawDetailsGetVM
                                                   {
                                                       Qty = DetailsTable.Qty,
                                                       Price = DetailsTable.Price,
                                                       Total = DetailsTable.Total,
                                                       State = DetailsTable.State,
                                                       Percentage = DetailsTable.Percentage,
                                                       Notes = DetailsTable.Notes,
                                                       ItemId = DetailsTable.ItemId,
                                                   }).ToList();
                            foreach (var detail in WithDrawDetails)
                            {
                                var _detail = new StrAddDetails()
                                {
                                    Qty = detail.Qty,
                                    Price = detail.Price,
                                    Total = detail.Total,
                                    //BalanceQty = ,
                                    //AvgPrice = ,
                                    State = detail.State,
                                    Percentage = detail.Percentage,
                                    Notes = detail.Notes,
                                    AddId = _sTR_Add.Id,
                                    ItemId = detail.ItemId,
                                    CreatedByID = item.UserId,
                                    CreationDate = DateTime.Now
                                };
                                _context.StrAddDetails.Add(_detail);
                                _context.SaveChanges();
                                //_context.SaveChangesAsync();
                            }
                            //update withdraw confirmation into true
                            var _item = _context.StrWithDraw.Single(n => n.Id == item.WithDrawId);
                            _item.DestStoreConfirm = true;
                            _context.SaveChanges();
                            return _sTR_Add.Id.ToString();
                            //break;
                        }
                    case 0:
                        {
                            var _drawItem = _context.StrWithDraw.FirstOrDefault(n => n.Id == item.WithDrawId);
                            _drawItem.DestStoreConfirm = false;
                            _context.SaveChanges();
                            return "declined";
                            //break;
                        }
                    default:
                        return "wrong status";
                }
            


        }
        public async Task<string> Update(StrAddVM sTR_Add)
        {


            var _sTR_Add = _context.StrAdd.Single(n => n.Id == sTR_Add.Id);

            _sTR_Add.No = sTR_Add.No;
            _sTR_Add.Date = sTR_Add.Date;
            _sTR_Add.Total = sTR_Add.Total;
            _sTR_Add.EntryNo = sTR_Add.EntryNo;
            _sTR_Add.Type = sTR_Add.Type;
            _sTR_Add.StoreId = sTR_Add.StoreId;
            _sTR_Add.Notes = sTR_Add.Notes;
            if (sTR_Add.File != null)
            {
                _sTR_Add.Attachment = await FileHelper.UploadFile(sTR_Add.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRAdd));
            }
            _sTR_Add.EmployeeId = sTR_Add.EmployeeId;
            _sTR_Add.FiscalYearId = sTR_Add.FiscalYearId;
            _sTR_Add.SellerId = sTR_Add.SellerId;
            _sTR_Add.ApprovalStatusId = sTR_Add.ApprovalStatusId;
            _sTR_Add.withdrawId = sTR_Add.withdrawId;
            _sTR_Add.CommodityId = sTR_Add.CommodityId;
            _sTR_Add.AddTypeId = sTR_Add.AddTypeId;
            _sTR_Add.SourceStoreId = sTR_Add.SourceStoreId;
            _sTR_Add.UpdateByID = sTR_Add.TransactionUserId;
            _sTR_Add.CreationDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";

        }
        public string Delete(int sTR_Add_Id)
        {

            var _sTR_Add = _context.StrAdd.Single(n => n.Id == sTR_Add_Id);

            var DetailsToDelete = _context.StrAddDetails.Where(p => p.AddId == sTR_Add_Id).ToList();
          
                _context.StrAddDetails.RemoveRange(DetailsToDelete);
                _context.SaveChanges();
            
            _context.StrAdd.Remove(_sTR_Add);
            _context.SaveChanges();
            return "Succeeded";


        }
        public List<StrAddGetVM> GetAll() => _context.StrAdd.Select(n => n.ToStrAddGetVM()).ToList();
       // public StrAddGetVM GetById(int sTR_AddId) => _context.StrAdd.Select(n => n.ToStrAddGetVM()).(n => n.Id == sTR_AddId);
        public StrAddGetVM GetById(int sTR_AddId)
        {

            return _context.StrAdd.Single(e => e.Id ==sTR_AddId).ToStrAddGetVM();
        }
        public List<StrAddGetVM> Search(searchadd searchModel)
        {

            var query = _context.StrAdd.AsQueryable();
            if (searchModel.id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.id);
            }
            if (searchModel.StoreId.HasValue)
            {
                query = query.Where(p => p.StoreId == searchModel.StoreId);
            }
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.EntryNo.HasValue)
            {
                query = query.Where(p => p.EntryNo == searchModel.EntryNo);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
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
                query = query.Where(p => p.STR_Add_Details.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.SourceStoreId.HasValue)
            {
                query = query.Where(p => p.SourceStoreId == searchModel.SourceStoreId);
            }
            if (searchModel.SellerId.HasValue)
            {
                query = query.Where(p => p.SellerId == searchModel.SellerId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.STR_Store.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrAddGetVM
            {
                Id = p.Id,
                Date = p.Date,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),
                StartDate = searchModel.StartDate.HasValue ? searchModel.StartDate.Value.ToString("dd/MM/yyyy") : "",
                EndDate = searchModel.EndDate.HasValue ? searchModel.EndDate.Value.ToString("dd/MM/yyyy") : "",
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                No = p.No,
                Total = p.Total,
                Notes = p.Notes,
                SellerId = p.SellerId,
                SourceStoreId = p.SourceStoreId,
                StoreId = p.StoreId,
                EmployeeId = p.EmployeeId,
                EntryNo = p.EntryNo,
                CreateUserName = p.CreatedBy.Name,
                StoreName = p.STR_Store.Name,
                EmployeeName = p.Employee.Name,
                fiscalyear = p.fiscalyear.fiscalyear,
                TransactionUserId = p.CreatedBy.Id,
                SellerName = p.Seller.Name,
                SourceStoreName = p.SourceStore.Name,
                ApprovalStatusId = p.ApprovalStatusId,
                ApprovalStatusName = p.ApprovalStatus.Name,
                withdrawId = p.withdrawId,
                WithDrawNo = p.withdraw.No,
                AddTypeId = p.AddTypeId,
                AddTypeName = p.AddType.Name,
                CommodityId = p.CommodityId,
                CommodityName = p.STR_Commodity.Name,
                Type = p.Type,
                Section = searchModel.SectionId != null ? p.STR_Store.Section.Name : ""
            }).OrderBy(x => x.Date).ThenBy(x => x.Id).ToList();


            return results;


        }
        public PaginatedResult<StrAddGetVM> GetByEmployeeStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            var totalCount = _context.StrAdd.Count();
            List<int> storeIds = _context.StrStore
                .Where(store => store.StorekeeperId == employeeId)
                .Select(store => store.Id)
                .ToList();
            //var x = _context.StrAdd
            //    .Where(sa => storeIds.Contains(sa.StoreId) && sa.Id == 1121)
            //    .OrderByDescending(Add => Add.Date).Select(e=>e.ToStrAddGetVM()).ToList();
            List<StrAddGetVM> Add;
            if (storeIds.Count > 0)
            {
                 Add = _context.StrAdd
                .Where(sa => storeIds.Contains(sa.StoreId) && sa.FiscalYearId == fiscalYearId)
                .OrderByDescending(Add => Add.Date)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => n.ToStrAddGetVM())
                .ToList();
            }
            else
            {
                Add = _context.StrAdd
                .Where(sa => sa.FiscalYearId == fiscalYearId)
                .OrderByDescending(Add => Add.Date)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => n.ToStrAddGetVM())
                .ToList();
            }
             

            var paginatedResult = new PaginatedResult<StrAddGetVM>
            {
                Items = Add,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
    }
}
