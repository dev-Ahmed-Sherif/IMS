using DAL.STR.General;
using Entities.ExtensionMethods;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.General;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using Entities.ViewModels;
using Entities.ExtensionMethods.STR.StoreOpen;
using System.Threading.Tasks;
using DAL.Helpers;
using Entities.Enums;

namespace DAL.STR.StoreOpen
{
    public class StrOpeningStockRepository
    {
        private AppDbContext _context;
        private StrFiscalYearRepository _strFiscalRepository;
        public StrOpeningStockRepository
            (AppDbContext context, StrFiscalYearRepository strFiscalRepository)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
        }
        public int GetLastNo(int StoreId, int FiscalYearId)
        {
            int maxNo = _context.StrOpeningStock.Where(item => item.StoreId == StoreId && item.FiscalYearId == FiscalYearId).Select(item => item.No).DefaultIfEmpty().Max();

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
        public async Task<string> Add(StrOpeningStockVM opening_Stock)
        {
           

                bool exists = _context.StrOpeningStock.Any(s => s.StoreId == opening_Stock.StoreId && s.FiscalYearId == opening_Stock.FiscalYearId);
                if (exists)
                {
                    throw new Exception("store already exists.");
                }
            string fileName = await FileHelper.UploadFile(opening_Stock.File, FileHelper.GetDirectoryName(DirectoriesEnum.STROpenStock));
            var _opening_Stock = new StrOpeningStock()
                {
                    No = opening_Stock.No,
                    Date = opening_Stock.Date,
                    StoreId = opening_Stock.StoreId,
                    Total = opening_Stock.Total,
                    Attachment = fileName,
                    Notes = opening_Stock.Notes,
                    FiscalYearId = opening_Stock.FiscalYearId,
                    CreatedByID = opening_Stock.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrOpeningStock.Add(_opening_Stock);
                _context.SaveChanges();

                return _opening_Stock.Id.ToString();
          
        }
        public async Task<string> Update(StrOpeningStockVM opening_Stock)
        {
           
                bool exists = 
                _context
                .StrOpeningStock
                .Any(s => 
                    s.StoreId == opening_Stock.StoreId && 
                    s.FiscalYearId == opening_Stock.FiscalYearId &&
                    s.Id != opening_Stock.Id);

                if (exists) throw new Exception("store already exists.");

                var _opening_Stock = _context.StrOpeningStock.Single(n => n.Id == opening_Stock.Id);
               
                    _opening_Stock.No = opening_Stock.No;
                    _opening_Stock.Date = opening_Stock.Date;
                    _opening_Stock.StoreId = opening_Stock.StoreId;
                    _opening_Stock.Total = opening_Stock.Total;
                    _opening_Stock.Notes = opening_Stock.Notes;
                   _opening_Stock.Attachment = await FileHelper.UploadFile(opening_Stock.File, FileHelper.GetDirectoryName(DirectoriesEnum.STROpenStock));
                   _opening_Stock.FiscalYearId = opening_Stock.FiscalYearId;
                    _opening_Stock.UpdateByID = opening_Stock.TransactionUserId;
                    _opening_Stock.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
          
        }
        public string Delete(int opening_StockId)
        {
            
                var _opening_Stock = _context.StrOpeningStock.Single(n => n.Id == opening_StockId);
             
                    var DetailsToDelete = _context.StrOpeningStockDetails.Where(p => p.STR_Opening_StockId == opening_StockId).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.StrOpeningStockDetails.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.StrOpeningStock.Remove(_opening_Stock);
                    _context.SaveChanges();
                    return "Succeeded";
           
          
        }
        public List<StrOpeningStockGetVM> GetAll()
        {
            return _context.StrOpeningStock.Select(
               n => n.ToStrOpeningStockGetVM()).ToList();

        }
        public StrOpeningStockGetVM GetById(int opening_StockId)
        {
            StrOpeningStock strOpeningStock = _context
                .StrOpeningStock
                .Find(opening_StockId);
            if (strOpeningStock == null) throw new ObjectNotFoundException();
            return strOpeningStock.ToStrOpeningStockGetVM();
        }

        public List<StrOpeningStockGetVM> Search(searchopeningstock searchModel)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(searchModel.FiscalYearId.Value);

            var query = _context.StrOpeningStock.AsQueryable();

            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
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
            var results = query.Select(p => p.ToStrOpeningStockGetVM(fiscalYear.StartDate, fiscalYear.EndDate)).ToList();



            return results;


        }
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<StrOpeningStockGetVM> GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            var Item = _context.StrOpeningStock
                .Where(e=>e.FiscalYearId == fiscalYearId)       
                .OrderByDescending(Item => Item.CreationDate)
                .ToPaginatedResult(page, pageSize, e => e.ToStrOpeningStockGetVM());
            return Item;
        }

    }
}
