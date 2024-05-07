using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;


namespace DAL.STR.StoreOpen
{
    public class StrStockTakingDetailsRepository
    {
        private AppDbContext _context;
        public StrStockTakingDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrStockTakingDetailsGeneralVM StockTakingDetails)
        {
            bool exists = _context.StrStockTakingDetails.Any(s => s.ItemId == StockTakingDetails.ItemId && s.STRStockTakingId == StockTakingDetails.STRStockTakingId);
            if (exists)
            {
                throw new Exception("store already exists.");
            }
            var _StockTakingDetails = new StrStockTakingDetails()
            {


                //ProductId = StockTakingDetails.ProductId,
                SystemQty = StockTakingDetails.SystemQty,
                Balance = StockTakingDetails.Balance,

                Qty = StockTakingDetails.Qty,
                Price = StockTakingDetails.Price,
                Total = StockTakingDetails.Total,
                Notes = StockTakingDetails.Notes,
                STRStockTakingId = StockTakingDetails.STRStockTakingId,
                ItemId = StockTakingDetails.ItemId,


                CreatedByID = StockTakingDetails.TransactionUserId,
                LastUpdateDate = DateTime.Now
            };
            _context.StrStockTakingDetails.Add(_StockTakingDetails);
            _context.SaveChanges();
            return "Succeeded";
        }
        public string Update( StrStockTakingDetailsVM StockTakingDetails)
        {
            bool exists = _context.StrStockTakingDetails.Any(s => s.ItemId == StockTakingDetails.ItemId && s.STRStockTakingId == StockTakingDetails.STRStockTakingId && s.Id != StockTakingDetails.Id);
            if (exists)
            {
                throw new Exception("store already exists.");
            }
            var _StockTakingDetails = _context.StrStockTakingDetails.Single(n => n.Id == StockTakingDetails.Id);
        
                //_opening_Stock_Details.STR_Opening_StockId = opening_Stock_Details.STR_Opening_StockId;
                _StockTakingDetails.ItemId = StockTakingDetails.ItemId;
                //_opening_Stock_Details.ProductId = opening_Stock_Details.ProductId;
                _StockTakingDetails.Qty = StockTakingDetails.Qty;
                _StockTakingDetails.Price = StockTakingDetails.Price;
                _StockTakingDetails.Total = StockTakingDetails.Total;
                _StockTakingDetails.Notes = StockTakingDetails.Notes;

                _StockTakingDetails.UpdateByID = StockTakingDetails.TransactionUserId;
                _StockTakingDetails.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";
        }
        public string Delete(int StockTakingDetailsId)
        {
           
                var _StockTakingDetails = _context.StrStockTakingDetails.Single(n => n.Id == StockTakingDetailsId);
            
                    _context.StrStockTakingDetails.Remove(_StockTakingDetails);
                    _context.SaveChanges();
                    return "Succeeded";
              
          
        }
        public List<StrStockTakingDetailsGetVM> GetAll()
            => _context.StrStockTakingDetails.Select(n => new StrStockTakingDetailsGetVM
            {
                Id = n.Id,
                Qty = n.Qty,
                Balance = n.Balance,
                SystemQty = n.SystemQty,
                ItemId = n.ItemId,
                ItemName = n.Item.Name,
                Price = n.Price,
                Notes = n.Notes,
                Total = n.Total,
                STRStockTakingId = n.STRStockTakingId,
                STRStockTakingNo = n.StockTaking.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrStockTakingDetailsGetVM> GetAllByPagination(int StockTakingid, int page, int pageSize)
        {
            var totalCount = _context.StrStockTakingDetails.Where(ssd => ssd.STRStockTakingId == StockTakingid).Count();
            List<StrStockTakingDetailsGetVM> Item = _context.StrStockTakingDetails
                .OrderByDescending(Item => Item.CreationDate)
                .Where(ssd => ssd.STRStockTakingId == StockTakingid)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(ssd => new StrStockTakingDetailsGetVM
                {
                    STRStockTakingId = ssd.STRStockTakingId,
                    HeaderNo = ssd.StockTaking.No,
                    HeaderDate = ssd.StockTaking.Date.ToString("dd/MM/yyyy", new CultureInfo("ar-EG")),
                    HeaderTotal = ssd.StockTaking.Total,
                    HeaderCreateUserName = ssd.StockTaking.CreatedBy.Name,
                    HeaderFiscalYear = ssd.StockTaking.fiscalyear.fiscalyear,
                    HeaderStore = ssd.StockTaking.Store.Name,
                    Id = ssd.Id,
                    ItemId = ssd.ItemId,
                    Qty = ssd.Qty,
                    Price = ssd.Price,
                    Total = ssd.Total,
                    Notes = ssd.Notes,
                    TransactionUserId = ssd.CreatedBy.Id,
                    CreateUserName = ssd.CreatedBy.Name,
                    Balance = ssd.Balance,
                    SystemQty = ssd.SystemQty,
                    ItemName = ssd.Item.Name,
                    FullCode = ssd.Item.FullCode,
                }).ToList();

            var paginatedResult = new PaginatedResult<StrStockTakingDetailsGetVM>
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
        public StrStockTakingDetailsGetVM GetById(int StockTakingDetailsId) => _context.StrStockTakingDetails.Select(n => new StrStockTakingDetailsGetVM { Id = n.Id, Qty = n.Qty, Balance = n.Balance, SystemQty = n.SystemQty, ItemId = n.ItemId, ItemName = n.Item.Name, Price = n.Price, Notes = n.Notes, Total = n.Total, STRStockTakingId = n.STRStockTakingId, STRStockTakingNo = n.StockTaking.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == StockTakingDetailsId);
        public List<StrStockTakingDetailsGetVM> GetByHeader(int StockTakingid) => _context.StrStockTakingDetails
                        .Where(ssd => ssd.STRStockTakingId == StockTakingid)
                        .Select(ssd => new StrStockTakingDetailsGetVM
                        {
                            STRStockTakingId = ssd.STRStockTakingId,
                            HeaderNo = ssd.StockTaking.No,
                            HeaderDate = ssd.StockTaking.Date.ToString("dd/MM/yyyy",new CultureInfo("ar-EG")),
                            ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG")),
                            HeaderTotal = ssd.StockTaking.Total,
                            HeaderCreateUserName = ssd.StockTaking.CreatedBy.Name,
                            HeaderFiscalYear = ssd.StockTaking.fiscalyear.fiscalyear,
                            HeaderStore = ssd.StockTaking.Store.Name,
                            Id = ssd.Id,
                            ItemId = ssd.ItemId,
                            Qty = ssd.Qty,
                            Price = ssd.Price,
                            Unit = ssd.Item.STR_Unit.Name,
                            Total = ssd.Total,
                            Notes = ssd.StockTaking.Notes,
                            TransactionUserId = ssd.CreatedBy.Id,
                            CreateUserName = ssd.CreatedBy.Name,
                            Balance = ssd.Balance,
                            SystemQty = ssd.SystemQty,
                            ItemName = ssd.Item.Name,
                            FullCode = ssd.Item.FullCode,
                            CommodityId = ssd.Item.CommodityId,
                            CommodityName = ssd.Item.STR_Commodity.Name,
                            GradeId = ssd.Item.GradeId,
                            GradeName = ssd.Item.CommodityId == 6 ? ssd.Item.STR_Grade.Name : "",
                            //Section = ssd.StockTaking.Store.Section.Name,
                        }).OrderBy(x => x.CommodityId).ThenBy(x => x.GradeId).ThenBy(x => x.FullCode).ToList();
        public List<StrStockTakingDetailsGetVM> Search(Search searchModel)
        {
            var query = _context.StrStockTaking.AsQueryable();
            if (searchModel.StoreId.HasValue)
            {
                query = query.Where(p => p.StoreId == searchModel.StoreId);
            }
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
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
                query = query.Where(p => p.StrStockTakingDetails.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.Store.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrStockTakingGetVM
            {
                Id = p.Id,
                Section = searchModel.SectionId != null ? p.Store.Section.Name : "",
            }).ToList();
            List<StrStockTakingDetailsGetVM> items = new List<StrStockTakingDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item.Id);
                if (isNotNull != null)
                {
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].Section = item.Section;
                        isNotNull[item2].StartDate = searchModel.StartDate.HasValue ? ((DateTime)searchModel.StartDate).ToString("dd/MM/yyyy", new CultureInfo("ar-EG")) : "";
                        isNotNull[item2].EndDate = searchModel.EndDate.HasValue ? ((DateTime)searchModel.EndDate).ToString("dd/MM/yyyy", new CultureInfo("ar-EG")) : "";
                        items.Add(isNotNull[item2]);
                    }
                }
            }
            return items;

        }
        public List<StrStockTakingDetailsSumByStore> GetCommodityStockSum(Search searchModel)
        {
            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.CommodityId != null)
            {
                var sumTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                from item in itemJoin.DefaultIfEmpty()
                                join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                from commodity in commodityJoin.DefaultIfEmpty()
                                join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                from store in storeJoin.DefaultIfEmpty()
                                join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                from section in sectionJoin.DefaultIfEmpty()
                                where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                                && commodity.Id != 8 && commodity.Id != 6
                                select (stockTakingDetails.Total)).Sum();

                var result = (from stockTakingDetails in _context.StrStockTakingDetails
                              join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                              from stockTaking in stockTakingJoin.DefaultIfEmpty()
                              where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                              join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                              from item in itemJoin.DefaultIfEmpty()
                              join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                              from commodity in commodityJoin.DefaultIfEmpty()
                              join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                              from store in storeJoin.DefaultIfEmpty()
                              join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                              from section in sectionJoin.DefaultIfEmpty()
                              where commodity.Id == searchModel.CommodityId && store.SectionId == searchModel.SectionId
                              group stockTakingDetails by new
                              {
                                  Sec = section.Name,
                                  commodityId = commodity.Id,
                                  c = commodity.Name,
                                  s = store.Name,
                                  storeId = store.Id,
                                  itemId = item.Id,
                                  itemCode = item.FullCode,
                                  itemName = item.Name,
                                  qty = stockTakingDetails.Qty,
                                  price = stockTakingDetails.Price,
                                  total = stockTakingDetails.Total,
                              }
                                  into grouped
                              select new StrStockTakingDetailsSumByStore
                              {
                                  ReportHeaderName = "ارصدة المخزون السلعي",
                                  ItemId = grouped.Key.itemId,
                                  ItemCode = grouped.Key.itemCode,
                                  ItemName = grouped.Key.itemName,
                                  CommodityId = grouped.Key.commodityId,
                                  CommodityName = grouped.Key.c,
                                  StoreId = grouped.Key.storeId,
                                  Store = grouped.Key.s,
                                  Section = grouped.Key.Sec,
                                  Qty = grouped.Key.qty,
                                  Price = grouped.Key.price,
                                  Total = grouped.Key.total,
                                  SumTotal = sumTotal,
                                  ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG"))
                              });

                preOrderedResult = result.ToList();

                orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
            }
            else
            {

                var sumTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                from item in itemJoin.DefaultIfEmpty()
                                join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                from commodity in commodityJoin.DefaultIfEmpty()
                                join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                from store in storeJoin.DefaultIfEmpty()
                                join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                from section in sectionJoin.DefaultIfEmpty()
                                where store.SectionId == searchModel.SectionId && commodity.Id != 8 && commodity.Id != 6
                                select (stockTakingDetails.Total)).Sum();

                var resultTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                   join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                   from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                   where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                   join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                   from item in itemJoin.DefaultIfEmpty()
                                   join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                                   from commodity in commodityJoin.DefaultIfEmpty()
                                   join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                   from store in storeJoin.DefaultIfEmpty()
                                   join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                   from section in sectionJoin.DefaultIfEmpty()
                                   where store.SectionId == searchModel.SectionId
                                   group stockTakingDetails by new
                                   {
                                       Sec = section.Name,
                                       commodityId = commodity.Id,
                                       c = commodity.Name,
                                       s = store.Name,
                                       storeId = store.Id,
                                       itemCode = item.FullCode,
                                       itemName = item.Name,
                                       qty = stockTakingDetails.Qty,
                                       price = stockTakingDetails.Price,
                                       total = stockTakingDetails.Total,
                                   }
                                       into grouped
                                   select new StrStockTakingDetailsSumByStore
                                   {
                                       ReportHeaderName = "ارصدة المخزون السلعي",
                                       ItemCode = grouped.Key.itemCode,
                                       ItemName = grouped.Key.itemName,
                                       CommodityId = grouped.Key.commodityId,
                                       CommodityName = grouped.Key.c,
                                       StoreId = grouped.Key.storeId,
                                       Store = grouped.Key.s,
                                       Section = grouped.Key.Sec,
                                       Qty = grouped.Key.qty,
                                       Price = grouped.Key.price,
                                       Total = grouped.Key.total,
                                       SumTotal = sumTotal,
                                       ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG"))
                                   });

                preOrderedResult = resultTotal.ToList();

                orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
            }

            return orderedResult;
        }
        public List<StrStockTakingDetailsSumByStore> GetInvestComponentSum(Search searchModel)
        {
            //var ReportHeaderName = _context.StrCommodity
            //    .Where(n => n.Id == searchModel.Id)
            //    .Select(n => new StrStockTakingDetailsSumByStore
            //    {
            //        ReportHeaderName = n.Name
            //    })
            //    .FirstOrDefault();

            List<StrStockTakingDetailsSumByStore> preOrderedResult = new List<StrStockTakingDetailsSumByStore>();

            List<StrStockTakingDetailsSumByStore> orderedResult = new List<StrStockTakingDetailsSumByStore>();

            if (searchModel.GradeId != null)
            {
                var sumTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                from item in itemJoin.DefaultIfEmpty()
                                join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                from Grade in GradeJoin.DefaultIfEmpty()
                                join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                from store in storeJoin.DefaultIfEmpty()
                                join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                from section in sectionJoin.DefaultIfEmpty()
                                where Grade.Id == searchModel.GradeId && store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                select (stockTakingDetails.Total)).Sum();

                var result = (from stockTakingDetails in _context.StrStockTakingDetails
                              join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                              from stockTaking in stockTakingJoin.DefaultIfEmpty()
                              where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                              join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                              from item in itemJoin.DefaultIfEmpty()
                              join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                              from Grade in GradeJoin.DefaultIfEmpty()
                              join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                              from store in storeJoin.DefaultIfEmpty()
                              join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                              from section in sectionJoin.DefaultIfEmpty()
                              where Grade.Id == searchModel.GradeId && store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                              group stockTakingDetails by new
                              {
                                  Sec = section.Name,
                                  commidIdGrade = Grade.CommodityId,
                                  commodityId = Grade.Id,
                                  c = Grade.Name,
                                  s = store.Name,
                                  storeId = store.Id,
                                  itemCode = item.FullCode,
                                  itemName = item.Name,
                                  qty = stockTakingDetails.Qty,
                                  price = stockTakingDetails.Price,
                                  total = stockTakingDetails.Total
                              }
                              into grouped
                              select new StrStockTakingDetailsSumByStore
                              {
                                  ReportHeaderName = "ارصدة المكون الاستثماري",
                                  CommodityName = grouped.Key.c,
                                  Store = grouped.Key.s,
                                  Section = grouped.Key.Sec,
                                  Qty = grouped.Key.qty,
                                  Price = grouped.Key.price,
                                  Total = grouped.Key.total,
                                  SumTotal = sumTotal,
                                  ItemCode = grouped.Key.itemCode,
                                  ItemName = grouped.Key.itemName,
                                  CommodityId = grouped.Key.commodityId,
                                  CommidIdGrade = grouped.Key.commidIdGrade,
                                  StoreId = grouped.Key.storeId,
                                  ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG"))
                              });

                preOrderedResult = result.ToList();

                orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();

            }
            else
            {
                var sumTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                from item in itemJoin.DefaultIfEmpty()
                                join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                from Grade in GradeJoin.DefaultIfEmpty()
                                join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                from store in storeJoin.DefaultIfEmpty()
                                join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                from section in sectionJoin.DefaultIfEmpty()
                                where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                select (stockTakingDetails.Total)).Sum();

                var resultTotal = (from stockTakingDetails in _context.StrStockTakingDetails
                                   join stockTaking in _context.StrStockTaking on stockTakingDetails.STRStockTakingId equals stockTaking.Id into stockTakingJoin
                                   from stockTaking in stockTakingJoin.DefaultIfEmpty()
                                   where stockTaking.Date >= searchModel.StartDate && stockTaking.Date <= searchModel.EndDate
                                   join item in _context.StrItem on stockTakingDetails.ItemId equals item.Id into itemJoin
                                   from item in itemJoin.DefaultIfEmpty()
                                   join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
                                   from Grade in GradeJoin.DefaultIfEmpty()
                                   join store in _context.StrStore on stockTaking.StoreId equals store.Id into storeJoin
                                   from store in storeJoin.DefaultIfEmpty()
                                   join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
                                   from section in sectionJoin.DefaultIfEmpty()
                                   where store.SectionId == searchModel.SectionId && Grade.CommodityId == 6
                                   group stockTakingDetails by new
                                   {
                                       Sec = section.Name,
                                       commodityId = Grade.Id,
                                       commidIdGrade = Grade.CommodityId,
                                       c = Grade.Name,
                                       s = store.Name,
                                       storeId = store.Id,
                                       itemCode = item.FullCode,
                                       itemName = item.Name,
                                       qty = stockTakingDetails.Qty,
                                       price = stockTakingDetails.Price,
                                       total = stockTakingDetails.Total
                                   }
                               into grouped
                                   select new StrStockTakingDetailsSumByStore
                                   {
                                       ReportHeaderName = "ارصدة المكون الاستثماري",
                                       CommodityName = grouped.Key.c,
                                       Store = grouped.Key.s,
                                       Section = grouped.Key.Sec,
                                       Qty = grouped.Key.qty,
                                       Price = grouped.Key.price,
                                       Total = grouped.Key.total,
                                       SumTotal = sumTotal,
                                       ItemCode = grouped.Key.itemCode,
                                       ItemName = grouped.Key.itemName,
                                       CommodityId = grouped.Key.commodityId,
                                       CommidIdGrade = grouped.Key.commidIdGrade,
                                       StoreId = grouped.Key.storeId,
                                       ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG"))
                                   });

                preOrderedResult = resultTotal.ToList();

                orderedResult = preOrderedResult.OrderBy(x => x.CommodityId).ThenBy(x => x.StoreId).ThenBy(x => x.ItemCode).ToList();
            }

            return orderedResult;
        }


    }
}
