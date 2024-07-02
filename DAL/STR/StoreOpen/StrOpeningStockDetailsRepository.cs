using DAL.STR.General;
using Entities.ExtensionMethods.STR.StoreOpen;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.General;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.StoreOpen
{
    public class StrOpeningStockDetailsRepository
    {
        private AppDbContext _context;
        public StrFiscalYearRepository _strFiscalRepository;
        public StrOpeningStockDetailsRepository
            (AppDbContext context,
            StrFiscalYearRepository strFiscalRepository)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
        }
        public string Add(StrOpeningStockDetailsGeneralVM opening_Stock_Details)
        {
            bool exists = _context.StrOpeningStockDetails.Any(s => s.ItemId == opening_Stock_Details.ItemId && s.STR_Opening_StockId == opening_Stock_Details.STR_Opening_StockId);
            if (exists)
            {
                throw new Exception("store already exists.");
            }
            var _opening_Stock_Details = new StrOpeningStockDetails()
            {
                STR_Opening_StockId = opening_Stock_Details.STR_Opening_StockId,
                ItemId = opening_Stock_Details.ItemId,
                //ProductId = opening_Stock_Details.ProductId,
                Qty = opening_Stock_Details.Qty,
                Price = opening_Stock_Details.Price,
                Total = opening_Stock_Details.Total,
                Notes = opening_Stock_Details.Notes,
                CreatedByID = opening_Stock_Details.TransactionUserId,
                LastUpdateDate = DateTime.Now
            };
            _context.StrOpeningStockDetails.Add(_opening_Stock_Details);
            _context.SaveChanges();
            return "Succeeded";
        }
        public string Update(StrOpeningStockDetailsVM opening_Stock_Details)
        {
            bool exists = _context.StrOpeningStockDetails.Any(s => s.ItemId == opening_Stock_Details.ItemId && s.STR_Opening_StockId == opening_Stock_Details.STR_Opening_StockId && s.Id != opening_Stock_Details.Id);
            if (exists)
            {
                throw new Exception("store already exists.");
            }
            var _opening_Stock_Details = _context.StrOpeningStockDetails.Single(n => n.Id == opening_Stock_Details.Id);
          
                //_opening_Stock_Details.STR_Opening_StockId = opening_Stock_Details.STR_Opening_StockId;
                _opening_Stock_Details.ItemId = opening_Stock_Details.ItemId;
                //_opening_Stock_Details.ProductId = opening_Stock_Details.ProductId;
                _opening_Stock_Details.Qty = opening_Stock_Details.Qty;
                _opening_Stock_Details.Price = opening_Stock_Details.Price;
                _opening_Stock_Details.Total = opening_Stock_Details.Total;
                _opening_Stock_Details.Notes = opening_Stock_Details.Notes;

                _opening_Stock_Details.UpdateByID = opening_Stock_Details.TransactionUserId;
                _opening_Stock_Details.LastUpdateDate = DateTime.Now;

             
            _context.SaveChanges();
            return "Succeeded";
        }
        public string Delete(int opening_Stock_DetailsId)
        {
          
                var _opening_Stock_Details = _context.StrOpeningStockDetails.Single(n => n.Id == opening_Stock_DetailsId);
        
                _context.StrOpeningStockDetails.Remove(_opening_Stock_Details);
                _context.SaveChanges();
                return "Succeeded";
     
        }
        public List<StrOpeningStockDetailsGetVM> GetAll() => _context.StrOpeningStockDetails.Select(
            n => new StrOpeningStockDetailsGetVM
            {
                Id = n.Id,
                Qty = n.Qty,
                FullCode = n.STR_Item.FullCode,
                ItemId = n.ItemId,
                ItemName = n.STR_Item.Name,
                Price = n.Price,
                Notes = n.Notes,
                Total = n.Total,
                STR_Opening_StockId = n.STR_Opening_StockId,
                STR_Opening_StockNo = n.STR_Opening_Stock.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrOpeningStockDetailsGetVM> GetAllByPagination(int page, int pageSize, int Id)
        {
            var totalCount = _context.StrOpeningStockDetails.Where(n => n.STR_Opening_StockId == Id).Count();
            List<StrOpeningStockDetailsGetVM> Item = _context.StrOpeningStockDetails
                .OrderByDescending(Item => Item.CreationDate)
                .Where(n => n.STR_Opening_StockId == Id)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new StrOpeningStockDetailsGetVM
                {
                    //Add Header
                    STR_Opening_StockId = n.STR_Opening_StockId,
                    HeaderStoreName = n.STR_Opening_Stock.STR_Store.Name,
                    HeaderCreateUserName = n.STR_Opening_Stock.CreatedBy.Name,
                    HeaderFiscalYear = n.STR_Opening_Stock.fiscalyear.fiscalyear,
                    HeaderNo = n.STR_Opening_Stock.No,
                    HeaderTotal = n.STR_Opening_Stock.Total,
                    HeaderDate = n.STR_Opening_Stock.Date.ToString(),
                    //Details
                    Id = n.Id,
                    Qty = n.Qty,
                    Price = n.Price,
                    Total = n.Total,
                    Notes = n.Notes,
                    ItemId = n.ItemId,
                    ItemName = n.STR_Item.Name,
                    FullCode = n.STR_Item.FullCode,
                    STR_Opening_StockNo = n.STR_Opening_Stock.No,
                    CreateUserName = n.CreatedBy.Name,
                })
                .ToList();

            var paginatedResult = new PaginatedResult<StrOpeningStockDetailsGetVM>
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
        public StrOpeningStockDetailsGetVM GetById(int opening_StockDetailsId) => _context.StrOpeningStockDetails.Select(n => new StrOpeningStockDetailsGetVM { Id = n.Id, Qty = n.Qty, ItemId = n.ItemId, ItemName = n.STR_Item.Name, Price = n.Price, Notes = n.Notes, Total = n.Total, STR_Opening_StockId = n.STR_Opening_StockId, STR_Opening_StockNo = n.STR_Opening_Stock.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == opening_StockDetailsId);
        public List<StrOpeningStockDetailsGetVM> Search(searchopeningstock searchModel)
        {
            if (!searchModel.FiscalYearId.HasValue) throw new Exception("FiscalYearId Is Required!");
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById((int)searchModel.FiscalYearId);

            string startDate, endDate;
            startDate = fiscalYear.StartDate.ToString("dd/MM/yyyy");
            endDate = fiscalYear.EndDate.ToString("dd/MM/yyyy");

            //DateTime startDateTime = new DateTime();
            //DateTime endDateTime = new DateTime();
            //if (searchModel.StartDate != null && searchModel.EndDate != null)
            //{
            //    startDateTime = (DateTime)searchModel.StartDate;
            //    endDateTime = (DateTime)searchModel.EndDate;
            //}

            var query = _context.StrOpeningStock.AsQueryable();
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.StoreId.HasValue)
            {
                query = query.Where(p => p.StoreId == searchModel.StoreId);
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
                query = query.Where(p => p.STR_Opening_Stock_Details.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.STR_Store.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrOpeningStockGetVM
            {
                Id = p.Id,
                Section = searchModel.SectionId != null ? p.STR_Store.Section.Name : ""
            }).ToList();
            List<StrOpeningStockDetailsGetVM> items = new List<StrOpeningStockDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item.Id);
                if (isNotNull != null)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].Section = item.Section;
                        isNotNull[item2].StartDate = startDate != null ? startDate : "";
                        isNotNull[item2].EndDate = endDate != null ? endDate : "";
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;
        }
        public List<StrOpeningStockDetailsGetVM> GetByHeader(int Id)
      => _context.StrOpeningStockDetails.Where(n => n.STR_Opening_StockId == Id)
            .Select(n => new StrOpeningStockDetailsGetVM
            {
                //Add Header
                STR_Opening_StockId = n.STR_Opening_StockId,
                HeaderStoreName = n.STR_Opening_Stock.STR_Store.Name,
                HeaderCreateUserName = n.STR_Opening_Stock.CreatedBy.Name,
                HeaderFiscalYear = n.STR_Opening_Stock.fiscalyear.fiscalyear,
                HeaderNo = n.STR_Opening_Stock.No,
                HeaderTotal = n.STR_Opening_Stock.Total,
                HeaderDate = n.STR_Opening_Stock.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                //Details
                Id = n.Id,
                Qty = n.Qty,
                Unit = n.STR_Item.STR_Unit.Name,
                Price = n.Price,
                Total = n.Total,
                Notes = n.Notes,
                ItemId = n.ItemId,
                ItemName = n.STR_Item.Name,
                FullCode = n.STR_Item.FullCode,
                STR_Opening_StockNo = n.STR_Opening_Stock.No,
                CreateUserName = n.CreatedBy.Name,

            }).ToList();
        public List<StrStockTakingDetailsSumByStore> OpenStockCommodityStock(searchopeningstock searchModel)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById((int)searchModel.FiscalYearId);

            string startDate, endDate;

            startDate = fiscalYear.StartDate.ToString("dd/MM/yyyy");
            endDate = fiscalYear.EndDate.ToString("dd/MM/yyyy");


            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.CommodityId != null)
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                                    select (openStockDetails.Total)).Sum();

                    var result = (from openStockDetails in _context.StrOpeningStockDetails
                                  join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                  from openStock in strWithDrawJoin.DefaultIfEmpty()
                                  where openStock.FiscalYearId == searchModel.FiscalYearId
                                  join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                  from commodity in commodityJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                                  group openStockDetails by new
                                  {
                                      fiscalYearId = searchModel.FiscalYearId,
                                      Sec = section.Name,
                                      commodityId = commodity.Id,
                                      c = commodity.Name,
                                      s = store.Name,
                                      storeId = store.Id,
                                      itemId = item.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = openStockDetails.Qty,
                                      price = openStockDetails.Price,
                                      total = openStockDetails.Total,
                                  }
                                   into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      FiscalYearId = (int)grouped.Key.fiscalYearId,
                                      ItemId = grouped.Key.itemId,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommodityName = grouped.Key.c,
                                      StoreId = grouped.Key.storeId,
                                      Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Id == searchModel.CommodityId
                                    select (openStockDetails.Total)).Sum();

                    var result = (from openStockDetails in _context.StrOpeningStockDetails
                                  join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                  from openStock in strWithDrawJoin.DefaultIfEmpty()
                                  where openStock.FiscalYearId == searchModel.FiscalYearId
                                  join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                  from commodity in commodityJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where commodity.Id == searchModel.CommodityId
                                  group openStockDetails by new
                                  {
                                      fiscalYearId = searchModel.FiscalYearId,
                                      Sec = "",
                                      commodityId = commodity.Id,
                                      c = commodity.Name,
                                      s = store.Name,
                                      storeId = store.Id,
                                      itemId = item.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = openStockDetails.Qty,
                                      price = openStockDetails.Price,
                                      total = openStockDetails.Total,
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      FiscalYearId = (int)grouped.Key.fiscalYearId,
                                      ItemId = grouped.Key.itemId,
                                      ItemCode = grouped.Key.itemCode,
                                      ItemName = grouped.Key.itemName,
                                      Unit = grouped.Key.itemUnit,
                                      CommodityId = grouped.Key.commodityId,
                                      CommodityName = grouped.Key.c,
                                      StoreId = grouped.Key.storeId,
                                      Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where store.SectionId == searchModel.SectionId && commodity.Code != 9 && commodity.Code != 6
                                    select (openStockDetails.Total)).Sum();

                    var resultTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                       join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                       from openStock in strWithDrawJoin.DefaultIfEmpty()
                                       where openStock.FiscalYearId == searchModel.FiscalYearId
                                       join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                       from commodity in commodityJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where store.SectionId == searchModel.SectionId && commodity.Code != 9 && commodity.Code != 6
                                       group openStockDetails by new
                                       {
                                           fiscalYearId = searchModel.FiscalYearId,
                                           Sec = section.Name,
                                           commodityId = commodity.Id,
                                           c = commodity.Name,
                                           s = store.Name,
                                           storeId = store.Id,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = openStockDetails.Qty,
                                           price = openStockDetails.Price,
                                           total = openStockDetails.Total,
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           FiscalYearId = (int)grouped.Key.fiscalYearId,
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommodityName = grouped.Key.c,
                                           StoreId = grouped.Key.storeId,
                                           Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                    from commodity in commodityJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where commodity.Code != 9 && commodity.Code != 6
                                    select (openStockDetails.Total)).Sum();

                    var resultTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                       join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                       from openStock in strWithDrawJoin.DefaultIfEmpty()
                                       where openStock.FiscalYearId == searchModel.FiscalYearId
                                       join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                       from commodity in commodityJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where commodity.Code != 9 && commodity.Code != 6
                                       group openStockDetails by new
                                       {
                                           fiscalYearId = searchModel.FiscalYearId,
                                           Sec = "",
                                           commodityId = commodity.Id,
                                           c = commodity.Name,
                                           s = store.Name,
                                           storeId = store.Id,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = openStockDetails.Qty,
                                           price = openStockDetails.Price,
                                           total = openStockDetails.Total,
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           FiscalYearId = (int)grouped.Key.fiscalYearId,
                                           ItemCode = grouped.Key.itemCode,
                                           ItemName = grouped.Key.itemName,
                                           Unit = grouped.Key.itemUnit,
                                           CommodityId = grouped.Key.commodityId,
                                           CommodityName = grouped.Key.c,
                                           StoreId = grouped.Key.storeId,
                                           Store = grouped.Key.s,
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
        public List<StrStockTakingDetailsSumByStore> OpenStockInvestComponent(searchopeningstock searchModel)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById((int)searchModel.FiscalYearId);

            string startDate, endDate;

            startDate = fiscalYear.StartDate.ToString("dd/MM/yyyy");
            endDate = fiscalYear.EndDate.ToString("dd/MM/yyyy");

            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.GradeId != null)
            {
                if (searchModel.SectionId != null)
                {
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.Id == searchModel.GradeId && store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                    select (openStockDetails.Total)).Sum();

                    var result = (from openStockDetails in _context.StrOpeningStockDetails
                                  join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                  from openStock in strWithDrawJoin.DefaultIfEmpty()
                                  where openStock.FiscalYearId == searchModel.FiscalYearId
                                  join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                  from Grade in GradeJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where Grade.Id == searchModel.GradeId && store.SectionId == searchModel.SectionId
                                  group openStockDetails by new
                                  {
                                      fiscalYearId = searchModel.FiscalYearId,
                                      Sec = section.Name,
                                      commidIdGrade = Grade.CommodityId,
                                      commodityId = Grade.Id,
                                      c = Grade.Name,
                                      s = store.Name,
                                      storeId = store.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = openStockDetails.Qty,
                                      price = openStockDetails.Price,
                                      total = openStockDetails.Total
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      FiscalYearId = (int)grouped.Key.fiscalYearId,
                                      CommodityName = grouped.Key.c,
                                      Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6
                                    select (openStockDetails.Total)).Sum();

                    var result = (from openStockDetails in _context.StrOpeningStockDetails
                                  join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                  from openStock in strWithDrawJoin.DefaultIfEmpty()
                                  where openStock.FiscalYearId == searchModel.FiscalYearId
                                  join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                  from item in itemJoin.DefaultIfEmpty()
                                  join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                  from unit in unitJoin.DefaultIfEmpty()
                                  join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                  from Grade in GradeJoin.DefaultIfEmpty()
                                  join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                  from store in storeJoin.DefaultIfEmpty()
                                  join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                  from section in sectionJoin.DefaultIfEmpty()
                                  where Grade.Id == searchModel.GradeId && Grade.CommodityId == 6
                                  group openStockDetails by new
                                  {
                                      fiscalYearId = searchModel.FiscalYearId,
                                      Sec = "",
                                      commidIdGrade = Grade.CommodityId,
                                      commodityId = Grade.Id,
                                      c = Grade.Name,
                                      s = store.Name,
                                      storeId = store.Id,
                                      itemCode = item.FullCode,
                                      itemName = item.Name,
                                      itemUnit = unit.Name,
                                      qty = openStockDetails.Qty,
                                      price = openStockDetails.Price,
                                      total = openStockDetails.Total
                                  }
                                  into grouped
                                  select new StrStockTakingDetailsSumByStore
                                  {
                                      FiscalYearId = (int)grouped.Key.fiscalYearId,
                                      CommodityName = grouped.Key.c,
                                      Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                    select (openStockDetails.Total)).Sum();

                    var resultTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                       join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                       from openStock in strWithDrawJoin.DefaultIfEmpty()
                                       where openStock.FiscalYearId == searchModel.FiscalYearId
                                       join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                       from Grade in GradeJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                       group openStockDetails by new
                                       {
                                           fiscalYearId = searchModel.FiscalYearId,
                                           Sec = section.Name,
                                           commodityId = Grade.Id,
                                           commidIdGrade = Grade.CommodityId,
                                           c = Grade.Name,
                                           s = store.Name,
                                           storeId = store.Id,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = openStockDetails.Qty,
                                           price = openStockDetails.Price,
                                           total = openStockDetails.Total
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           FiscalYearId = (int)grouped.Key.fiscalYearId,
                                           CommodityName = grouped.Key.c,
                                           Store = grouped.Key.s,
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
                    var sumTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                    join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                    from openStock in strWithDrawJoin.DefaultIfEmpty()
                                    where openStock.FiscalYearId == searchModel.FiscalYearId
                                    join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                    from item in itemJoin.DefaultIfEmpty()
                                    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                    from Grade in GradeJoin.DefaultIfEmpty()
                                    join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                    from store in storeJoin.DefaultIfEmpty()
                                    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                    from section in sectionJoin.DefaultIfEmpty()
                                    where Grade.CommodityId == 6
                                    select (openStockDetails.Total)).Sum();

                    var resultTotal = (from openStockDetails in _context.StrOpeningStockDetails
                                       join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strWithDrawJoin
                                       from openStock in strWithDrawJoin.DefaultIfEmpty()
                                       where openStock.FiscalYearId == searchModel.FiscalYearId
                                       join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                                       from item in itemJoin.DefaultIfEmpty()
                                       join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                                       from unit in unitJoin.DefaultIfEmpty()
                                       join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                       from Grade in GradeJoin.DefaultIfEmpty()
                                       join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                                       from store in storeJoin.DefaultIfEmpty()
                                       join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                       from section in sectionJoin.DefaultIfEmpty()
                                       where Grade.CommodityId == 6
                                       group openStockDetails by new
                                       {
                                           fiscalYearId = searchModel.FiscalYearId,
                                           Sec = "",
                                           commodityId = Grade.Id,
                                           commidIdGrade = Grade.CommodityId,
                                           c = Grade.Name,
                                           s = store.Name,
                                           storeId = store.Id,
                                           itemCode = item.FullCode,
                                           itemName = item.Name,
                                           itemUnit = unit.Name,
                                           qty = openStockDetails.Qty,
                                           price = openStockDetails.Price,
                                           total = openStockDetails.Total
                                       }
                                       into grouped
                                       select new StrStockTakingDetailsSumByStore
                                       {
                                           FiscalYearId = (int)grouped.Key.fiscalYearId,
                                           CommodityName = grouped.Key.c,
                                           Store = grouped.Key.s,
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
        public decimal GetItemTotalAddAndWithdraw(int StoreId, int FiscalYearId, DateTime? StartDate, DateTime? EndDate, int ItemId)
        {
            var addTotal = (from addDetails in _context.StrAddDetails
                            join add in _context.StrAdd on addDetails.AddId equals add.Id into addJoin
                            from add in addJoin.DefaultIfEmpty()
                            where (add.StoreId == StoreId && add.FiscalYearId == FiscalYearId
                            && addDetails.ItemId == ItemId)
                            || (add.Date >= StartDate && add.Date <= EndDate)
                            select (addDetails.Total)).Sum();

            var withdrawTotal = (from withdrawDetails in _context.StrWithDrawDetails
                                 join withdraw in _context.StrWithDraw on withdrawDetails.STR_WithdrawId equals withdraw.Id into withdrawJoin
                                 from withdraw in withdrawJoin.DefaultIfEmpty()
                                 where (withdraw.StoreId == StoreId && withdraw.FiscalYearId == FiscalYearId
                                 && withdrawDetails.ItemId == ItemId)
                                 || (withdraw.Date >= StartDate && withdraw.Date <= EndDate)
                                 select (withdrawDetails.Total)).Sum();

            return addTotal - withdrawTotal;
        }
        public decimal GetItemQtyAddAndWithdraw(int StoreId, int FiscalYearId, DateTime? StartDate, DateTime? EndDate, int ItemId)
        {
            var addQty = (from addDetails in _context.StrAddDetails
                          join add in _context.StrAdd on addDetails.AddId equals add.Id into addJoin
                          from add in addJoin.DefaultIfEmpty()
                          where (add.StoreId == StoreId && add.FiscalYearId == FiscalYearId
                          && addDetails.ItemId == ItemId)
                          || (add.Date >= StartDate && add.Date <= EndDate)
                          select (addDetails.Qty)).Sum();

            var withdrawQty = (from withdrawDetails in _context.StrWithDrawDetails
                               join withdraw in _context.StrWithDraw on withdrawDetails.STR_WithdrawId equals withdraw.Id into withdrawJoin
                               from withdraw in withdrawJoin.DefaultIfEmpty()
                               where (withdraw.StoreId == StoreId && withdraw.FiscalYearId == FiscalYearId
                               && withdrawDetails.ItemId == ItemId)
                               || (withdraw.Date >= StartDate && withdraw.Date <= EndDate)
                               select (withdrawDetails.Qty)).Sum();

            return addQty - withdrawQty;
        }
        public StrOpeningStockDetailsGetVM GetopenstockdetailsByStore(int storeid, int itemid, int fiscalyearid)
        {
            var openingStockQuery =
                _context
                .StrOpeningStockDetails
                .Single(e =>
                    e.STR_Opening_Stock.StoreId == storeid &&
                    e.ItemId == itemid &&
                    e.STR_Opening_Stock.FiscalYearId == fiscalyearid);
                   

            return openingStockQuery.ToStrOpeningStockDetailsGetVM();

        }



    }
}

