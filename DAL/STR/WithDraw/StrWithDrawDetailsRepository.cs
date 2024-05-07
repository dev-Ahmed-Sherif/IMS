using DAL.STR.Add;
using Entities.ExtensionMethods.STR.Withdraw;
using Entities.Models.STR.WithDraw;
using Entities.ViewModels.STR.StoreOpen;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.STR.WithDraw
{
    public class StrWithDrawDetailsRepository
    {
        private AppDbContext _context;
        private StrAddDetailsRepository _strAddDetailsRepository;
        public StrWithDrawDetailsRepository
            (AppDbContext context,
            StrAddDetailsRepository strAddDetailsRepository
            )
        {
            _context = context;
            _strAddDetailsRepository = strAddDetailsRepository;
        }
        public async Task<string> AddAsync(StrWithDrawDetailsGeneralVM types)
        {
            bool exists = _context.StrWithDrawDetails.Any(s => s.ItemId == types.ItemId && s.STR_WithdrawId == types.STR_WithdrawId);
            if (exists)
            {
                return "item already exists.";
            }

            var _type = new StrWithDrawDetails()
            {
                Qty = types.Qty,
                Total = types.Total,
                State = types.State,
                Percentage = types.Percentage,
                Notes = types.Notes,
                STR_WithdrawId = types.STR_WithdrawId,
                ItemId = types.ItemId,
                //ProductId = types.ProductId,
                CreatedByID = types.TransactionUserId,

                CreationDate = DateTime.Now
            };
            StrWithDraw parent = await _context.StrWithDraw.FindAsync(_type.STR_WithdrawId);
            _type.Price = _strAddDetailsRepository.GetAvgPrice(parent.FiscalYearId, _type.ItemId);
            _context.StrWithDrawDetails.Add(_type);
            _context.SaveChanges();
            return "Succeeded";

        }
        public string Update(StrWithDrawDetailsVM item)
        {
            bool exists = _context.StrWithDrawDetails.Any(s => s.ItemId == item.ItemId && s.STR_WithdrawId == item.STR_WithdrawId && s.Id != item.Id);
            if (exists)
            {
                return "item already exists.";
            }
            var _item = _context.StrWithDrawDetails.Single(n => n.Id == item.Id);


            _item.Qty = item.Qty;

            _item.Price = item.Price;
            _item.Total = item.Total;

            _item.State = item.State;
            _item.Percentage = item.Percentage;
            _item.Notes = item.Notes;
            _item.STR_WithdrawId = item.STR_WithdrawId;
            _item.ItemId = item.ItemId;
            //_item.ProductId = item.ProductId;
            _item.UpdateByID = item.TransactionUserId;
            _item.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";


        }
        public string Delete(int itemId)
        {

            var _item = _context.StrWithDrawDetails.Single(n => n.Id == itemId);

            _context.StrWithDrawDetails.Remove(_item);
            _context.SaveChanges();
            return "Succeeded";


        }
        public List<StrWithDrawDetailsGetVM> GetAll() => _context.StrWithDrawDetails.Select(n => new StrWithDrawDetailsGetVM { Id = n.Id, Qty = n.Qty, Price = n.Price, Total = n.Total, State = n.State, Percentage = n.Percentage, Notes = n.Notes, ItemId = n.ItemId, ItemName = n.STR_Item.Name, STR_WithdrawId = n.STR_WithdrawId, WithDrawNo = n.STR_Withdraw.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrWithDrawDetailsGetVM GetById(int itemId) => _context.StrWithDrawDetails.Select(
            n => new StrWithDrawDetailsGetVM
            {
                Id = n.Id,
                Qty = n.Qty,
                Price = n.Price,
                Total = n.Total,
                State = n.State,
                Percentage = n.Percentage,
                Notes = n.Notes,
                ItemId = n.ItemId,
                ItemName = n.STR_Item.Name,
                STR_WithdrawId = n.STR_WithdrawId,
                WithDrawNo = n.STR_Withdraw.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);
        public List<StrWithDrawDetailsGetVM> Search(searchwithdraw searchModel)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            var query = _context.StrWithDraw.AsQueryable();

            if (searchModel.id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.id);
            }
            if (searchModel.StoreId.HasValue)
            {
                query = query.Where(p => p.StoreId == searchModel.StoreId);
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
                startDate = (DateTime)searchModel.StartDate;
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                endDate = (DateTime)searchModel.EndDate;
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
                Date = p.Date,
                CostCenterId = p.CostCenterId,
                Section = searchModel.SectionId != null ? p.STR_Store.Section.Name : ""

            }).OrderBy(x => x.Date).ThenBy(x => x.Id).ToList();

            var filterResult = new List<StrWithdrawGetVM>();
            if (searchModel.WithdrawType == 0)
            {
                filterResult = results;
            }
            else if (searchModel.WithdrawType == 1)
            {
                filterResult = results.Where(n => n.CostCenterId != null).ToList();
            }
            else if (searchModel.WithdrawType == 2)
            {
                filterResult = results.Where(n => n.CostCenterId == null).ToList();
            }

            List<StrWithDrawDetailsGetVM> items = new List<StrWithDrawDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item.Id);
                if (isNotNull.Count != 0)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].Section = item.Section;
                        isNotNull[item2].StartDate = searchModel.StartDate.HasValue ? startDate.ToString("dd/MM/yyyy") : "";
                        isNotNull[item2].EndDate = searchModel.EndDate.HasValue ? endDate.ToString("dd/MM/yyyy") : "";
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;
        }
        public List<StrWithDrawDetailsGetVM> GetByHeader(int Id)
        {
            return
            _context
            .StrWithDrawDetails
            .Where(n => n.STR_WithdrawId == Id)
            .OrderBy(n => n.STR_Withdraw.Date)
            .ThenBy(n => n.STR_WithdrawId)
            .ThenBy(n => n.STR_Item.FullCode)
            .Select(n => n.ToStrWithDrawDetailsGetVM())
            .ToList();
        }
        public List<StrStockTakingDetailsSumByStore> WithdrawCommodityStock(searchwithdraw searchModel)
        {
            string startDate, endDate;
            startDate = ((DateTime)searchModel.StartDate).ToString("dd/MM/yyyy");
            endDate = ((DateTime)searchModel.EndDate).ToString("dd/MM/yyyy");

            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.CommodityId != null)
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                                    select (strWithDrawDetails.Total)).Sum();

                    var result = (from strWithDrawDetails in _context.StrWithDrawDetails
                                  join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                  from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                  where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                  join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                  from costCenter in costCenterJoin.DefaultIfEmpty()
                                  join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                  from commodity in commodityJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                                  group strWithDrawDetails by new
                                  {
                                      Sec = section.Name,
                                      commodityId = commodity.Id,
                                      c = commodity.Name,
                                      s = store.Name,
                                      costCenter = costCenter.Name,
                                      storeId = store.Id,
                                      withdrawNo = strWithDraw.No,
                                      withdrawDate = strWithDraw.Date,
                                      itemId = item.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = strWithDrawDetails.Qty,
                                      price = strWithDrawDetails.Price,
                                      total = strWithDrawDetails.Total,
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      WithdrawNo = grouped.Key.withdrawNo,
                                      Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                      ReportHeaderName = "ارصدة المخزون السلعي",
                                      ItemId = grouped.Key.itemId,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommodityName = grouped.Key.c,
                                      StoreId = grouped.Key.storeId,
                                      Store = grouped.Key.s,
                                      CostCenter = grouped.Key.costCenter,
                                      Section = grouped.Key.Sec,
                                      Qty = grouped.Key.qty,
                                      Price = grouped.Key.price,
                                      Total = grouped.Key.total,
                                      SumTotal = sumTotal,
                                      StartDate = startDate,
                                      EndDate = endDate,
                                      ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                  });

                    preOrderedResult = result.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
                else
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Id == searchModel.CommodityId
                                    select (strWithDrawDetails.Total)).Sum();

                    var result = (from strWithDrawDetails in _context.StrWithDrawDetails
                                  join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                  from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                  where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                  join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                  from costCenter in costCenterJoin.DefaultIfEmpty()
                                  join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                  from commodity in commodityJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where commodity.Id == searchModel.CommodityId
                                  group strWithDrawDetails by new
                                  {
                                      Sec = "",
                                      commodityId = commodity.Id,
                                      c = commodity.Name,
                                      s = store.Name,
                                      costCenter = costCenter.Name,
                                      storeId = store.Id,
                                      withdrawNo = strWithDraw.No,
                                      withdrawDate = strWithDraw.Date,
                                      itemId = item.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = strWithDrawDetails.Qty,
                                      price = strWithDrawDetails.Price,
                                      total = strWithDrawDetails.Total,
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      WithdrawNo = grouped.Key.withdrawNo,
                                      Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                      ReportHeaderName = "ارصدة المخزون السلعي",
                                      ItemId = grouped.Key.itemId,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommodityName = grouped.Key.c,
                                      StoreId = grouped.Key.storeId,
                                      Store = grouped.Key.s,
                                      CostCenter = grouped.Key.costCenter,
                                      Section = grouped.Key.Sec,
                                      Qty = grouped.Key.qty,
                                      Price = grouped.Key.price,
                                      Total = grouped.Key.total,
                                      SumTotal = sumTotal,
                                      StartDate = startDate,
                                      EndDate = endDate,
                                      ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                  });

                    preOrderedResult = result.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }

            }
            else
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where store.SectionId == searchModel.SectionId && commodity.Code != 9 && commodity.Code != 6
                                    select (strWithDrawDetails.Total)).Sum();

                    var resultTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                       join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                       from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                       where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                       join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                       from costCenter in costCenterJoin.DefaultIfEmpty()
                                       join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                       from commodity in commodityJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where store.SectionId == searchModel.SectionId && commodity.Code != 9 && commodity.Code != 6
                                       group strWithDrawDetails by new
                                       {
                                           Sec = section.Name,
                                           commodityId = commodity.Id,
                                           c = commodity.Name,
                                           s = store.Name,
                                           costCenterId = costCenter.Id,
                                           costCenter = costCenter.Name,
                                           storeId = store.Id,
                                           withdrawNo = strWithDraw.No,
                                           withdrawDate = strWithDraw.Date,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = strWithDrawDetails.Qty,
                                           price = strWithDrawDetails.Price,
                                           total = strWithDrawDetails.Total,
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           WithdrawNo = grouped.Key.withdrawNo,
                                           Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                           ReportHeaderName = "ارصدة المخزون السلعي",
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommodityName = grouped.Key.c,
                                           StoreId = grouped.Key.storeId,
                                           Store = grouped.Key.s,
                                           CostCenterId = grouped.Key.costCenterId,
                                           CostCenter = grouped.Key.costCenter,
                                           Section = grouped.Key.Sec,
                                           Qty = grouped.Key.qty,
                                           Price = grouped.Key.price,
                                           Total = grouped.Key.total,
                                           SumTotal = sumTotal,
                                           StartDate = startDate,
                                           EndDate = endDate,
                                           ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                       });

                    preOrderedResult = resultTotal.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
                else
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Code != 9 && commodity.Code != 6
                                    select (strWithDrawDetails.Total)).Sum();

                    var resultTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                       join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                       from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                       where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                       join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                       from costCenter in costCenterJoin.DefaultIfEmpty()
                                       join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                       from commodity in commodityJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where commodity.Code != 9 && commodity.Code != 6
                                       group strWithDrawDetails by new
                                       {
                                           Sec = "",
                                           commodityId = commodity.Id,
                                           c = commodity.Name,
                                           s = store.Name,
                                           costCenterId = costCenter.Id,
                                           costCenter = costCenter.Name,
                                           storeId = store.Id,
                                           withdrawNo = strWithDraw.No,
                                           withdrawDate = strWithDraw.Date,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = strWithDrawDetails.Qty,
                                           price = strWithDrawDetails.Price,
                                           total = strWithDrawDetails.Total,
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           WithdrawNo = grouped.Key.withdrawNo,
                                           Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                           ReportHeaderName = "ارصدة المخزون السلعي",
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommodityName = grouped.Key.c,
                                           StoreId = grouped.Key.storeId,
                                           Store = grouped.Key.s,
                                           CostCenterId = grouped.Key.costCenterId,
                                           CostCenter = grouped.Key.costCenter,
                                           Section = grouped.Key.Sec,
                                           Qty = grouped.Key.qty,
                                           Price = grouped.Key.price,
                                           Total = grouped.Key.total,
                                           SumTotal = sumTotal,
                                           StartDate = startDate,
                                           EndDate = endDate,
                                           ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                       });

                    preOrderedResult = resultTotal.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
            }

            return orderedResult;
        }

        public List<StrStockTakingDetailsSumByStore> WithdrawInvestComponent(searchwithdraw searchModel)
        {
            string startDate, endDate;
            startDate = ((DateTime)searchModel.StartDate).ToString("dd/MM/yyyy");
            endDate = ((DateTime)searchModel.EndDate).ToString("dd/MM/yyyy");

            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.GradeId != null)
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6 && store.SectionId == searchModel.SectionId
                                    select (strWithDrawDetails.Total)).Sum();

                    var result = (from strWithDrawDetails in _context.StrWithDrawDetails
                                  join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                  from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                  where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                  join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                  from costCenter in costCenterJoin.DefaultIfEmpty()
                                  join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                  from Grade in GradeJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6 && store.SectionId == searchModel.SectionId
                                  group strWithDrawDetails by new
                                  {
                                      Sec = section.Name,
                                      commidIdGrade = Grade.CommodityId,
                                      commodityId = Grade.Id,
                                      c = Grade.Name,
                                      s = store.Name,
                                      costCenterId = costCenter.Id,
                                      costCenter = costCenter.Name,
                                      storeId = store.Id,
                                      withdrawNo = strWithDraw.No,
                                      withdrawDate = strWithDraw.Date,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = strWithDrawDetails.Qty,
                                      price = strWithDrawDetails.Price,
                                      total = strWithDrawDetails.Total
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      WithdrawNo = grouped.Key.withdrawNo,
                                      Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                      ReportHeaderName = "ارصدة المكون الاستثماري",
                                      CommodityName = grouped.Key.c,
                                      Store = grouped.Key.s,
                                      CostCenterId = grouped.Key.costCenterId,
                                      CostCenter = grouped.Key.costCenter,
                                      Section = grouped.Key.Sec,
                                      Qty = grouped.Key.qty,
                                      Price = grouped.Key.price,
                                      Total = grouped.Key.total,
                                      SumTotal = sumTotal,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommidIdGrade = grouped.Key.commidIdGrade,
                                      StoreId = grouped.Key.storeId,
                                      StartDate = startDate,
                                      EndDate = endDate,
                                      ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                  });

                    preOrderedResult = result.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
                else
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6
                                    select (strWithDrawDetails.Total)).Sum();

                    var result = (from strWithDrawDetails in _context.StrWithDrawDetails
                                  join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                  from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                  where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                  join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                  from costCenter in costCenterJoin.DefaultIfEmpty()
                                  join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                  from Grade in GradeJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6
                                  group strWithDrawDetails by new
                                  {
                                      Sec = "",
                                      commidIdGrade = Grade.CommodityId,
                                      commodityId = Grade.Id,
                                      c = Grade.Name,
                                      s = store.Name,
                                      costCenterId = costCenter.Id,
                                      costCenter = costCenter.Name,
                                      storeId = store.Id,
                                      withdrawNo = strWithDraw.No,
                                      withdrawDate = strWithDraw.Date,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = strWithDrawDetails.Qty,
                                      price = strWithDrawDetails.Price,
                                      total = strWithDrawDetails.Total
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      WithdrawNo = grouped.Key.withdrawNo,
                                      Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                      ReportHeaderName = "ارصدة المكون الاستثماري",
                                      CommodityName = grouped.Key.c,
                                      Store = grouped.Key.s,
                                      CostCenterId = grouped.Key.costCenterId,
                                      CostCenter = grouped.Key.costCenter,
                                      Section = grouped.Key.Sec,
                                      Qty = grouped.Key.qty,
                                      Price = grouped.Key.price,
                                      Total = grouped.Key.total,
                                      SumTotal = sumTotal,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommidIdGrade = grouped.Key.commidIdGrade,
                                      StoreId = grouped.Key.storeId,
                                      StartDate = startDate,
                                      EndDate = endDate,
                                      ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                  });

                    preOrderedResult = result.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
            }
            else
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                    select (strWithDrawDetails.Total)).Sum();

                    var resultTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                       join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                       from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                       where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                       join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                       from costCenter in costCenterJoin.DefaultIfEmpty()
                                       join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                       from Grade in GradeJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                       group strWithDrawDetails by new
                                       {
                                           Sec = section.Name,
                                           commodityId = Grade.Id,
                                           commidIdGrade = Grade.CommodityId,
                                           c = Grade.Name,
                                           s = store.Name,
                                           costCenterId = costCenter.Id,
                                           costCenter = costCenter.Name,
                                           storeId = store.Id,
                                           withdrawNo = strWithDraw.No,
                                           withdrawDate = strWithDraw.Date,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = strWithDrawDetails.Qty,
                                           price = strWithDrawDetails.Price,
                                           total = strWithDrawDetails.Total
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           WithdrawNo = grouped.Key.withdrawNo,
                                           Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                           ReportHeaderName = "ارصدة المكون الاستثماري",
                                           CommodityName = grouped.Key.c,
                                           Store = grouped.Key.s,
                                           CostCenterId = grouped.Key.costCenterId,
                                           CostCenter = grouped.Key.costCenter,
                                           Section = grouped.Key.Sec,
                                           Qty = grouped.Key.qty,
                                           Price = grouped.Key.price,
                                           Total = grouped.Key.total,
                                           SumTotal = sumTotal,
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommidIdGrade = grouped.Key.commidIdGrade,
                                           StoreId = grouped.Key.storeId,
                                           StartDate = startDate,
                                           EndDate = endDate,
                                           ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                       });

                    preOrderedResult = resultTotal.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
                else
                {
                    var sumTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                    join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                    from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                    where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                    join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                    from costCenter in costCenterJoin.DefaultIfEmpty()
                                    join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.CommodityId == 6
                                    select (strWithDrawDetails.Total)).Sum();

                    var resultTotal = (from strWithDrawDetails in _context.StrWithDrawDetails
                                       join strWithDraw in _context.StrWithDraw on strWithDrawDetails.STR_WithdrawId equals strWithDraw.Id into strWithDrawJoin
                                       from strWithDraw in strWithDrawJoin.DefaultIfEmpty()
                                       where strWithDraw.Date >= searchModel.StartDate && strWithDraw.Date <= searchModel.EndDate && strWithDraw.CostCenterId != null
                                       join costCenter in _context.CcCostCenter on strWithDraw.CostCenterId equals costCenter.Id into costCenterJoin
                                       from costCenter in costCenterJoin.DefaultIfEmpty()
                                       join item in _context.StrItem on strWithDrawDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                       from Grade in GradeJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on strWithDraw.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where Grade.CommodityId == 6
                                       group strWithDrawDetails by new
                                       {
                                           Sec = "",
                                           commodityId = Grade.Id,
                                           commidIdGrade = Grade.CommodityId,
                                           c = Grade.Name,
                                           s = store.Name,
                                           costCenterId = costCenter.Id,
                                           costCenter = costCenter.Name,
                                           storeId = store.Id,
                                           withdrawNo = strWithDraw.No,
                                           withdrawDate = strWithDraw.Date,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = strWithDrawDetails.Qty,
                                           price = strWithDrawDetails.Price,
                                           total = strWithDrawDetails.Total
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           WithdrawNo = grouped.Key.withdrawNo,
                                           Date = grouped.Key.withdrawDate.ToString("dd/MM/yyyy"),
                                           ReportHeaderName = "ارصدة المكون الاستثماري",
                                           CommodityName = grouped.Key.c,
                                           Store = grouped.Key.s,
                                           CostCenterId = grouped.Key.costCenterId,
                                           CostCenter = grouped.Key.costCenter,
                                           Section = grouped.Key.Sec,
                                           Qty = grouped.Key.qty,
                                           Price = grouped.Key.price,
                                           Total = grouped.Key.total,
                                           SumTotal = sumTotal,
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommidIdGrade = grouped.Key.commidIdGrade,
                                           StoreId = grouped.Key.storeId,
                                           StartDate = startDate,
                                           EndDate = endDate,
                                           ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                                       });

                    preOrderedResult = resultTotal.ToList();

                    orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
                }
            }

            return orderedResult;
        }

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrWithDrawDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.StrWithDrawDetails.Where(n => n.STR_WithdrawId == HeaderId).Count();
            List<int> fientryD = _context.StrWithDrawDetails
                .Where(sus => sus.STR_WithdrawId == HeaderId)
                .Select(sus => sus.STR_WithdrawId)
                .ToList();
            List<StrWithDrawDetailsGetVM> Item = _context.StrWithDrawDetails
                .Where(n => fientryD.Contains(n.STR_WithdrawId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new StrWithDrawDetailsGetVM
                {
                    //Add Header
                    STR_WithdrawId = n.STR_WithdrawId,
                    HeaderStoreName = n.STR_Withdraw.STR_Store.Name,
                    HeaderDestinationName = n.STR_Withdraw.DestStore.Name == null ? n.STR_Withdraw.CostCenter.Name : n.STR_Withdraw.DestStore.Name,
                    //HeaderDesstoreName = n.STR_Withdraw.DestStore.Name,
                    //HeaderCostCenterName = n.STR_Withdraw.FI_CostCenter.Name,
                    HeaderEmployeeName = n.STR_Withdraw.HR_Employee.Name,
                    HeaderDesstoreUserName = n.STR_Withdraw.DestStore.Name,
                    HeaderCreateUserName = n.STR_Withdraw.Fiscalyear.fiscalyear,
                    HeaderFiscalYear = n.STR_Withdraw.Fiscalyear.fiscalyear,
                    HeaderNo = n.STR_Withdraw.No,
                    HeaderTotal = n.STR_Withdraw.Total,
                    HeaderDate = n.STR_Withdraw.Date.ToString("dd/MM/yyyy"),
                    //Details
                    Id = n.Id,
                    Qty = n.Qty,
                    Price = n.Price,
                    Total = n.Total,
                    State = n.State,
                    Percentage = n.Percentage,
                    Notes = n.Notes,
                    ItemId = n.ItemId,
                    ItemName = n.STR_Item.Name,
                    FullCode = n.STR_Item.FullCode,
                    WithDrawNo = n.STR_Withdraw.No,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<StrWithDrawDetailsGetVM>
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
