using Entities.Helpers;
using Entities.Enums;
using Entities.ExtensionMethods;
using Entities.ExtensionMethods.STR.StoreOpen;
using Entities.Models.STR.Product;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.STR.StoreOpen
{
    public class StrStockTakingRepository
    {

        private AppDbContext _context;
        public StrStoreRepository _StrStoreRepository;
        public StrStockTakingRepository
            (AppDbContext context, StrStoreRepository StrStoreRepository)
        {
            _context = context;
            _StrStoreRepository = StrStoreRepository;
        }

        public async Task<string> Add(StrStockTakingVM StockTaking)
        {
            //bool exists = _context.StrStockTaking.Any(s => s.StoreId == StockTaking.StoreId && s.FiscalYearId == StockTaking.FiscalYearId);
            //if (exists)
            //{
            //    throw new Exception("store already exists.");
            //}
            string fileName = await FileHelper.UploadFile(StockTaking.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRStockTaking));
            var _StockTaking = new StrStockTaking()
            {
                No = StockTaking.No,
                Date = StockTaking.Date,
                Total = StockTaking.Total,
                Notes = StockTaking.Notes,
                Attachment = fileName,
                FiscalYearId = StockTaking.FiscalYearId,
                StoreId = StockTaking.StoreId,
                CreatedByID = StockTaking.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.StrStockTaking.Add(_StockTaking);
            _context.SaveChanges();

            return _StockTaking.Id.ToString();

        }

        public async Task<string>  Update(StrStockTakingVM StockTaking)
        {
            //bool exists = _context.StrStockTaking.Any(s => s.StoreId == StockTaking.StoreId && s.FiscalYearId == StockTaking.FiscalYearId && s.Id != StockTaking.Id);
            //if (exists)
            //{
            //    throw new Exception("store already exists.");
            //}

            var _StockTaking = _context.StrStockTaking.Single(n => n.Id == StockTaking.Id);

            _StockTaking.No = StockTaking.No;
            _StockTaking.Date = StockTaking.Date;
            _StockTaking.Total = StockTaking.Total;
            _StockTaking.Notes = StockTaking.Notes;
            _StockTaking.Attachment = await FileHelper.UploadFile(StockTaking.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRStockTaking));
            _StockTaking.FiscalYearId = StockTaking.FiscalYearId;
            _StockTaking.StoreId = StockTaking.StoreId;
            _StockTaking.UpdateByID = StockTaking.TransactionUserId;
            _StockTaking.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";


        }
        public string Delete(int StockTakingId)
        {

            var _StockTaking = _context.StrStockTaking.Single(n => n.Id == StockTakingId);

            _context.StrStockTaking.Remove(_StockTaking);
            _context.SaveChanges();
            return "Succeeded";


        }
        public List<StrStockTakingGetVM> GetAll()
        {
            return
            _context
                .StrStockTaking
                .Select(n => n.ToStrStockTakingGetVM()).ToList();
        }

        public PaginatedResult<StrStockTakingGetVM> GetPaginated(int fiscalYearId, int pageIndex, int pageSize)
        {
            return
            _context
            .StrStockTaking
            .Where(e => e.FiscalYearId == fiscalYearId)
            .OrderByDescending(e => e.CreationDate)
            .ToPaginatedResult(pageIndex, pageSize, e => e.ToStrStockTakingGetVM());
        }

        public StrStockTakingGetVM GetById(int StockTakingId)
        {
            return _context.StrStockTaking.First(e => e.Id == StockTakingId).ToStrStockTakingGetVM();
        }
        public List<StrStockTakingGetVM> Search(Search searchModel)
        {
            var query = _context.StrStockTaking.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
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
            List<StrStockTakingGetVM> results;
            if (searchModel.StartDate.HasValue && searchModel.EndDate.HasValue)
            {
                results =
                    query
                    .Select(p =>
                        p.ToStrStockTakingGetVM
                        (searchModel.StartDate.Value,
                        searchModel.EndDate.Value))
                    .ToList();
            }
            else
            {
                results =
                    query
                    .Select(p => p.ToStrStockTakingGetVM())
                    .ToList();
            }
            return results;

        }
        public List<StrStoreTaking> StoreTakingCommodityStock(Search searchModel)
        {
            StrStoreGetVM queryStore = new StrStoreGetVM();
            if (searchModel.StoreId.HasValue)
            {
                queryStore = _StrStoreRepository.GetById(searchModel.StoreId.Value);
            }
            //var result = _context.StrOpeningStockDetails.Where(e=>e.STR_Opening_Stock.StoreId == searchModel.StoreId && e.STR_Item.STR_Commodity.Code != 9 && e.STR_Item.STR_Commodity.Code != 6);
            //result.Select(t => new StrStoreTaking
            //{
            //    FiscalYearId = (int)searchModel.FiscalYearId,
            //    CommodityName = t.STR_Item.STR_Commodity.Name,
            //    CommodityId = t.STR_Item.STR_Commodity.Id,
            //    ItemId = t.STR_Item.Id,
            //    ItemName = t.STR_Item.Name,
            //    ItemCode = t.STR_Item.FullCode,
            //    ItemPrice = t.Price,
            //    ItemQty = t.Qty,
            //    Total = t.Total,
            //    Unit = t.STR_Item.STR_Unit.Name,
            //    StoreName = queryStore.Name,
            //    StoreKeeper = queryStore.StorekeeperName,
            //    Section = queryStore.Section,
            //    ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
            //});
            var result = from openStockDetails in _context.StrOpeningStockDetails
                         join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strpeningStockJoin
                         from openStock in strpeningStockJoin.DefaultIfEmpty()
                         where openStock.FiscalYearId == searchModel.FiscalYearId
                         join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                         from item in itemJoin.DefaultIfEmpty()
                         join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                         from unit in unitJoin.DefaultIfEmpty()
                         join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
                         from commodity in commodityJoin.DefaultIfEmpty()
                         join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                         from store in storeJoin.DefaultIfEmpty()
                         where store.Id == searchModel.StoreId && commodity.Code != 9 && commodity.Code != 6
                         select new StrStoreTaking
                         {
                             FiscalYearId = (int)searchModel.FiscalYearId,
                             CommodityName = commodity.Name,
                             CommodityId = commodity.Id,
                             ItemName = item.Name,
                             ItemCode = item.FullCode,
                             ItemId = item.Id,
                             ItemPrice = openStockDetails.Price,
                             ItemQty = openStockDetails.Qty,
                             Total = openStockDetails.Total,
                             Unit = unit.Name,
                             StoreName = queryStore.Name,
                             StoreKeeper = queryStore.StorekeeperName,
                             Section = queryStore.Section,
                             ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG",false)),
                         };

            var results = result.OrderBy(x => x.CommodityId).ThenBy(x => x.ItemCode).ToList();

            return results;
        }
        public List<StrStoreTaking> StoreTakingInvestComp(Search searchModel)
        {
            StrStoreGetVM queryStore = new StrStoreGetVM();
            if (searchModel.StoreId.HasValue)
            {
                queryStore = _StrStoreRepository.GetById(searchModel.StoreId.Value);
            }

            var result = from openStockDetails in _context.StrOpeningStockDetails
                         join openStock in _context.StrOpeningStock on openStockDetails.STR_Opening_StockId equals openStock.Id into strpeningStockJoin
                         from openStock in strpeningStockJoin.DefaultIfEmpty()
                         where openStock.FiscalYearId == searchModel.FiscalYearId
                         join item in _context.StrItem on openStockDetails.ItemId equals item.Id into itemJoin
                         from item in itemJoin.DefaultIfEmpty()
                         join unit in _context.StrUnit on item.UnitId equals unit.Id into unitJoin
                         from unit in unitJoin.DefaultIfEmpty()
                         join grade in _context.StrGrade on item.GradeId equals grade.Id into gradeJoin
                         from grade in gradeJoin.DefaultIfEmpty()
                         join store in _context.StrStore on openStock.StoreId equals store.Id into storeJoin
                         from store in storeJoin.DefaultIfEmpty()
                         where store.Id == searchModel.StoreId && grade.CommodityId == 6
                         select new StrStoreTaking
                         {
                             CommodityName = grade.Name,
                             CommodityId = grade.Id,
                             ItemName = item.Name,
                             ItemCode = item.FullCode,
                             ItemId = item.Id,
                             ItemPrice = openStockDetails.Price,
                             ItemQty = openStockDetails.Qty,
                             Total = openStockDetails.Total,
                             Unit = unit.Name,
                             StoreName = queryStore.Name,
                             StoreKeeper = queryStore.StorekeeperName,
                             Section = queryStore.Section,
                             ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt", new CultureInfo("ar-EG")),
                         };

            var results = result.OrderBy(x => x.CommodityId).ThenBy(x => x.ItemCode).ToList();

            return results;
        }


    }
}
