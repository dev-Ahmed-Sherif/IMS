using DAL.STR.Add;
using DAL.STR.StoreOpen;
using Entities.ExtensionMethods;
using Entities.ExtensionMethods.STR.General;
using Entities.ExtensionMethods.STR.StoreOpen;
using Entities.Models.STR.Add;
using Entities.Models.STR.General;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using Entities.ReportViewModel;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.STR.General
{
    public class StrItemRepository
    {
        private AppDbContext _context;
        public StrStoreRepository _StrStoreRepository;
        public StrAddDetailsRepository _StrAddDetailsRepository;
        public StrItemRepository
            (AppDbContext context,
            StrStoreRepository StrStoreRepository,
            StrAddDetailsRepository StrAddDetailsRepository
            )
        {
            _context = context;
            _StrStoreRepository = StrStoreRepository;
            _StrAddDetailsRepository = StrAddDetailsRepository;
        }
        public string GetLastNo(int GroupId)
        {
            string maxNo = _context.StrItem
             .Where(item => item.GroupId == GroupId)
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

            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }
        public string Add(StrItemVM item)
        {
           
                bool exists = _context.StrItem.Any(s => s.Name == item.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _item = new StrItem()
                {
                    Name = item.Name,
                    No = item.No,
                    FullCode = item.FullCode,
                    Type = item.Type,
                    IsActive = item.IsActive,
                    CommodityId = item.CommodityId,
                    GradeId = item.GradeId,
                    PlatoonId = item.PlatoonId,
                    GroupId = item.GroupId,
                    UnitId = item.UnitId,

                    CreatedByID = item.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrItem.Add(_item);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(StrItemVM item)
        {
            
                bool exists = _context.StrItem.Any(s => s.Name == item.Name && s.Id != item.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _item = _context.StrItem.Single(n => n.Id == item.Id);
               
                    _item.Name = item.Name;
                    _item.No = item.No;
                    _item.FullCode = item.FullCode;
                    _item.Type = item.Type;
                    _item.IsActive = item.IsActive;
                    _item.CommodityId = item.CommodityId;
                    _item.GradeId = item.GradeId;
                    _item.PlatoonId = item.PlatoonId;
                    _item.GroupId = item.GroupId;
                    _item.UnitId = item.UnitId;

                    _item.UpdateByID = item.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }

        public string Delete(int itemId)
        {
           
                var _item = _context.StrItem.Single(n => n.Id == itemId);
               
                    _context.StrItem.Remove(_item);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        public List<StrItemGetVM> GetAll() => _context.StrItem.Include(e => e.STR_Commodity).Select(n => new StrItemGetVM
        {
            Id = n.Id,
            No = n.No,
            Name = n.Name,
            FullCode = n.FullCode,
            Type = n.Type,
            IsActive = n.IsActive,
            CommodityId = n.CommodityId,
            Commoditycode = n.STR_Commodity.Code,
            CommodityName = n.STR_Commodity.Name,
            GradeId = n.GradeId,
            Gradecode = n.STR_Grade.Code,
            GradeName = n.STR_Grade.Name,
            PlatoonId = n.PlatoonId,
            Platooncode = n.STR_Platoon.Code,
            PlatoonName = n.STR_Platoon.Name,
            GroupId = n.GroupId,
            Groupcode = n.STR_Group.Code,
            GroupName = n.STR_Group.Name,
            UnitId = n.UnitId,
            UnitName = n.STR_Unit.Name,
            CreateUserName = n.CreatedBy.Name,
            TransactionUserId = n.CreatedBy.Id
        }).ToList();
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        //public PaginatedResult<StrItemGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.StrItem.Count();
        //    List<StrItemGetVM> Item = _context.StrItem
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new StrItemGetVM
        //        {
        //            Id = n.Id,
        //            No = n.No,
        //            Name = n.Name,
        //            FullCode = n.FullCode,
        //            Type = n.Type,
        //            IsActive = n.IsActive,
        //            CommodityId = n.CommodityId,
        //            Commoditycode = n.STR_Commodity.Code,
        //            CommodityName = n.STR_Commodity.Name,
        //            GradeId = n.GradeId,
        //            Gradecode = n.STR_Grade.Code,
        //            GradeName = n.STR_Grade.Name,
        //            PlatoonId = n.PlatoonId,
        //            Platooncode = n.STR_Platoon.Code,
        //            PlatoonName = n.STR_Platoon.Name,
        //            GroupId = n.GroupId,
        //            Groupcode = n.STR_Group.Code,
        //            GroupName = n.STR_Group.Name,
        //            UnitId = n.UnitId,
        //            UnitName = n.STR_Unit.Name,
        //        })
        //        .ToList();


        //    var paginatedResult = new PaginatedResult<StrItemGetVM>
        //    {
        //        Items = Item,
        //        TotalItems = totalCount,
        //        Page = page,
        //        PageSize = pageSize
        //    };

        //    return paginatedResult;
        //}
        public PaginatedResult<StrItemGetVM> GetAllByPagination(int page, int pageSize)
        {
            var Entries = _context.StrItem
                .OrderByDescending(Entry => Entry.CreationDate);

            return Entries.ToPaginatedResult(page, pageSize, e => e.ToStrItemGetVM());
        }
       // public class PaginatedResult<T>
        //{
        //    public List<T> Items { get; set; }
        //    public int TotalItems { get; set; }
        //    public int Page { get; set; } 
        //    public int PageSize { get; set; }
        //}
        public StrItemGetVM GetById(int itemId) => _context.StrItem.Select(n => new StrItemGetVM { Id = n.Id, No = n.No, Name = n.Name, FullCode = n.FullCode, Type = n.Type, IsActive = n.IsActive, CommodityId = n.CommodityId, Commoditycode = n.STR_Commodity.Code, CommodityName = n.STR_Commodity.Name, GradeId = n.GradeId, Gradecode = n.STR_Grade.Code, GradeName = n.STR_Grade.Name, PlatoonId = n.PlatoonId, Platooncode = n.STR_Platoon.Code, PlatoonName = n.STR_Platoon.Name, GroupId = n.GroupId, Groupcode = n.STR_Group.Code, GroupName = n.STR_Group.Name, UnitId = n.UnitId, UnitName = n.STR_Unit.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);

        // public StrItemGetVM GetItemByName(string itemName) => _context.StrItem.Select(n => new StrItemGetVM { Id = n.Id, No = n.No, Name = n.Name, FullCode = n.FullCode, Type = n.Type, IsActive = n.IsActive, CommodityId = n.CommodityId, Commoditycode = n.STR_Commodity.Code, CommodityName = n.STR_Commodity.Name, GradeId = n.GradeId, Gradecode = n.STR_Grade.Code, GradeName = n.STR_Grade.Name, PlatoonId = n.PlatoonId, Platooncode = n.STR_Platoon.Code, PlatoonName = n.STR_Platoon.Name, GroupId = n.GroupId, Groupcode = n.STR_Group.Code, GroupName = n.STR_Group.Name, UnitId = n.UnitId, UnitName = n.STR_Unit.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Name.Contains.(itemName));
        public List<StrItemGetVM> Search(searchgeneral searchModel)
        {
            var query = _context.StrItem.AsQueryable();
            if (searchModel.PlatoonId.HasValue)
            {
                query = query.Where(p => p.PlatoonId == searchModel.PlatoonId);
            }
            if (searchModel.GradeId.HasValue)
            {
                query = query.Where(p => p.GradeId == searchModel.GradeId);
            }
            if (searchModel.GroupId.HasValue)
            {
                query = query.Where(p => p.GroupId == searchModel.GroupId);
            }

            if (searchModel.CommodityId.HasValue)
            {
                query = query.Where(p => p.CommodityId == searchModel.CommodityId);
            }
            if (searchModel.UnitId.HasValue)
            {
                query = query.Where(p => p.UnitId == searchModel.UnitId);
            }
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Type))
            {
                query = query.Where(p => p.Type == searchModel.Type);
            }
            if (!string.IsNullOrEmpty(searchModel.FullCode))
            {
                query = query.Where(p => p.FullCode == searchModel.FullCode);
            }

            var results = query.Select(p => new StrItemGetVM
            {
                Id = p.Id,
                Name = p.Name,
                No = p.No,
                FullCode = p.FullCode,
                IsActive = p.IsActive,
                Type = p.Type,
                CommodityId = p.CommodityId,
                CommodityName = p.STR_Commodity.Name,
                Commoditycode = p.STR_Commodity.Code,
                Gradecode = p.STR_Grade.Code,
                GradeName = p.STR_Grade.Name,
                Platooncode = p.STR_Platoon.Code,
                PlatoonName = p.STR_Platoon.Name,
                Groupcode = p.STR_Group.Code,
                GroupName = p.STR_Group.Name,
                UnitName = p.STR_Unit.Name,
                GradeId = p.GradeId,
                PlatoonId = p.PlatoonId,
                GroupId = p.GroupId,
                UnitId = p.UnitId,
                TransactionUserId = p.CreatedBy.Id,
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")

            }).ToList();


            return results;


        }
        public PaginatedResult<StrItemGetVM> SearchPagination(searchgeneral searchModel, int page, int pageSize)
        {
            var query = _context.StrItem.AsQueryable();
            if (searchModel.PlatoonId.HasValue)
            {
                query = query.Where(p => p.PlatoonId == searchModel.PlatoonId);
            }
            if (searchModel.GradeId.HasValue)
            {
                query = query.Where(p => p.GradeId == searchModel.GradeId);
            }
            if (searchModel.GroupId.HasValue)
            {
                query = query.Where(p => p.GroupId == searchModel.GroupId);
            }

            if (searchModel.CommodityId.HasValue)
            {
                query = query.Where(p => p.CommodityId == searchModel.CommodityId);
            }
            if (searchModel.UnitId.HasValue)
            {
                query = query.Where(p => p.UnitId == searchModel.UnitId);
            }
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Type))
            {
                query = query.Where(p => p.Type == searchModel.Type);
            }
            if (!string.IsNullOrEmpty(searchModel.FullCode))
            {
                query = query.Where(p => p.FullCode == searchModel.FullCode);
            }

         
            return query.ToPaginatedResult(page, pageSize,e => e.ToStrItemGetVM());



        }
        public List<StrItemGetVM> GetByName(string itemName)
        {
            return _context.StrItem
                .Where(n => n.Name.Contains(itemName))
                .Select(n => new StrItemGetVM
                {
                    Id = n.Id,
                    No = n.No,
                    Name = n.Name,
                    FullCode = n.FullCode,
                    Type = n.Type,
                    IsActive = n.IsActive,
                    CommodityId = n.CommodityId,
                    Commoditycode = n.STR_Commodity.Code,
                    CommodityName = n.STR_Commodity.Name,
                    GradeId = n.GradeId,
                    Gradecode = n.STR_Grade.Code,
                    GradeName = n.STR_Grade.Name,
                    PlatoonId = n.PlatoonId,
                    Platooncode = n.STR_Platoon.Code,
                    PlatoonName = n.STR_Platoon.Name,
                    GroupId = n.GroupId,
                    Groupcode = n.STR_Group.Code,
                    GroupName = n.STR_Group.Name,
                    UnitId = n.UnitId,
                    UnitName = n.STR_Unit.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
               .ToList();
        }
        public List<dynamic> GetTransactions(int soreId, int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            var addQuery = (
                from strAddDetails in _context.StrAddDetails
                join strItem in _context.StrItem on strAddDetails.ItemId equals strItem.Id
                join strAdd in _context.StrAdd on strAddDetails.AddId equals strAdd.Id into addGroup
                from strAdd in addGroup.DefaultIfEmpty()
                where strAdd.StoreId == soreId && strAdd.FiscalYearId == FiscalYearId && strItem.Id == itemId ||
                (strAdd.Date >= startdate && strAdd.Date <= enddate &&
                strAdd.Date.AddSeconds(-strAdd.Date.Second) >= startdate &&
                strAdd.Date.AddSeconds(-strAdd.Date.Second) <= enddate)
                select new TransactionDetail
                {
                    StartDate = startdate.ToString("dd/MM/yyyy"),
                    EndDate = enddate.ToString("dd/MM/yyyy"),
                    Billid = strAdd.Id,
                    StoreName = strAdd.STR_Store.Name,
                    ItemCode = strItem.FullCode,
                    Name = strItem.Name,
                    Unit = strItem.STR_Unit.Name,
                    Qty = strAddDetails.Qty,
                    //outcomeQty = 0f,
                    Price = strAddDetails.Price,
                    AvgPrice = _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                    BillNo = strAdd.No,
                    Total = strAddDetails.Price * strAddDetails.Qty,
                    TransactionName = "اضافة",
                    TransactionID = strAdd.CreatedBy.Id,
                    CreatUsername = strAdd.CreatedBy.Name,
                    Date = strAdd.Date,
                    TheDate = strAdd.Date.ToString("dd/MM/yyyy"),
                    ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                    Section = strAdd.STR_Store.Section.Name
                }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ToList();

            var withdrawQuery = (
                        from strWithdrawDetails in _context.StrWithDrawDetails
                        join strItem in _context.StrItem on strWithdrawDetails.ItemId equals strItem.Id
                        join strWithdraw in _context.StrWithDraw on strWithdrawDetails.STR_WithdrawId equals strWithdraw.Id into withdrawGroup
                        from strWithdraw in withdrawGroup.DefaultIfEmpty()
                        where strWithdraw.StoreId == soreId && strWithdraw.FiscalYearId == FiscalYearId && strItem.Id == itemId
                        || (strWithdraw.Date >= startdate && strWithdraw.Date <= enddate &&
                        strWithdraw.Date.AddSeconds(-strWithdraw.Date.Second) >= startdate &&
                        strWithdraw.Date.AddSeconds(-strWithdraw.Date.Second) <= enddate)

                        select new TransactionDetail
                        {
                            StartDate = startdate.ToString("dd/MM/yyyy"),
                            EndDate = enddate.ToString("dd/MM/yyyy"),
                            Billid = strWithdraw.Id,
                            StoreName = strWithdraw.STR_Store.Name,
                            ItemCode = strItem.FullCode,
                            Name = strItem.Name,
                            Unit = strItem.STR_Unit.Name,
                            //IncomeQty = 0f,
                            Qty = strWithdrawDetails.Qty,
                            Price = strWithdrawDetails.Price,
                            AvgPrice = _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                            BillNo = strWithdraw.No,
                            Total = strWithdrawDetails.Price * strWithdrawDetails.Qty,
                            TransactionName = "صرف",
                            TransactionID = strWithdraw.CreatedBy.Id,
                            CreatUsername = strWithdraw.CreatedBy.Name,
                            Date = strWithdraw.Date,
                            TheDate = strWithdraw.Date.ToString("dd/MM/yyyy"),
                            ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                            Section = strWithdraw.STR_Store.Section.Name
                        }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ToList();

            var openingStockQuery = (
               from StrOpeningStockDetails in _context.StrOpeningStockDetails
               join strItem in _context.StrItem on StrOpeningStockDetails.ItemId equals strItem.Id
               join StrOpeningStock in _context.StrOpeningStock on StrOpeningStockDetails.STR_Opening_StockId equals StrOpeningStock.Id into StrOpeningStockGroup
               from StrOpeningStock in StrOpeningStockGroup.DefaultIfEmpty()
               where StrOpeningStock.StoreId == soreId && StrOpeningStock.FiscalYearId == FiscalYearId && strItem.Id == itemId
               ||
               (StrOpeningStock.Date >= startdate && StrOpeningStock.Date <= enddate
               && StrOpeningStock.Date.AddSeconds(-StrOpeningStock.Date.Second) >= startdate &&
               StrOpeningStock.Date.AddSeconds(-StrOpeningStock.Date.Second) <= enddate)

               select new TransactionDetail
               {
                   StartDate = startdate.ToString("dd/MM/yyyy"),
                   EndDate = enddate.ToString("dd/MM/yyyy"),
                   Billid = StrOpeningStock.Id,
                   StoreName = StrOpeningStock.STR_Store.Name,
                   ItemCode = strItem.FullCode,
                   Name = strItem.Name,
                   Unit = strItem.STR_Unit.Name,
                   //IncomeQty = 0f,
                   Qty = StrOpeningStockDetails.Qty,
                   Price = StrOpeningStockDetails.Price,
                   AvgPrice = _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                   BillNo = StrOpeningStock.No,
                   Total = StrOpeningStockDetails.Price * StrOpeningStockDetails.Qty,
                   TransactionName = "افتتاحي",
                   TransactionID = StrOpeningStock.CreatedBy.Id,
                   CreatUsername = StrOpeningStock.CreatedBy.Name,
                   //EmployeeId = StrOpeningStock.EmployeeId,
                   Date = StrOpeningStock.Date,
                   TheDate = StrOpeningStock.Date.ToString("dd/MM/yyyy"),
                   ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                   Section = StrOpeningStock.STR_Store.Section.Name
               }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ToList();

            var result = openingStockQuery
               .Union(addQuery)
               .Union(withdrawQuery);

            List<dynamic> dynamicResult = result.Cast<dynamic>().ToList();
            return dynamicResult;


        }
        public List<object> GetSumOfQtyBetweenTwoDate(int storeId, DateTime startdate, DateTime enddate)
        {
            var itemDetails = _context.StrItem
        .Select(strItem => new
        {
            Item = strItem,

            OpeningStockQty = _context.StrOpeningStockDetails
                .Where(osd => osd.ItemId == strItem.Id && osd.STR_Opening_Stock.StoreId == storeId && osd.STR_Opening_Stock.Date >= startdate && osd.STR_Opening_Stock.Date <= enddate)
                .Sum(osd => osd.Qty),
            AddQty = _context.StrAddDetails
                .Where(ad => ad.ItemId == strItem.Id && ad.STR_Add.StoreId == storeId && ad.STR_Add.Date >= startdate && ad.STR_Add.Date <= enddate)
                .Sum(ad => ad.Qty),
            WithdrawQty = _context.StrWithDrawDetails
                .Where(wd => wd.ItemId == strItem.Id && wd.STR_Withdraw.StoreId == storeId && wd.STR_Withdraw.Date >= startdate && wd.STR_Withdraw.Date <= enddate)
                .Sum(wd => wd.Qty),
            StoreName = _context.StrAdd
                .Where(ad => ad.StoreId == storeId && ad.Date >= startdate && ad.Date <= enddate)
                .Select(ad => ad.STR_Store.Name).FirstOrDefault(),
            Section = _context.StrAdd
                .Where(ad => ad.StoreId == storeId && ad.Date >= startdate && ad.Date <= enddate)
                .Select(ad => ad.STR_Store.Section.Name).FirstOrDefault(),

        })
        .Where(result => result.OpeningStockQty > 0 || result.AddQty > 0 || result.WithdrawQty > 0)
        .Select(result => new
        {
            ItemId = result.Item.Id,
            Name = result.Item.Name,
            FullCode = result.Item.FullCode,
            CommodityName = result.Item.STR_Commodity.Name,
            GradeName = result.Item.STR_Grade.Name,
            GroupName = result.Item.STR_Group.Name,
            StoreName = result.StoreName,
            OpeningStockQty = result.OpeningStockQty,
            AddQty = result.AddQty,
            WithdrawQty = result.WithdrawQty,
            TotalQty = result.OpeningStockQty + result.AddQty - result.WithdrawQty,
            ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
            Section = result.Section
        })
        .ToList<object>();

            return itemDetails;

        }
        public List<object> GetItemsWithPositiveTotalQty(int storeId, int fiscalyearId)
        {
            var itemDetails = _context.StrItem
                .Select(strItem => new
                {
                    Item = strItem,
                    OpeningStockQty = _context.StrOpeningStockDetails
                        .Where(osd => osd.ItemId == strItem.Id && osd.STR_Opening_Stock.StoreId == storeId)
                        .Sum(osd => osd.Qty),
                    AddQty = _context.StrAddDetails
                        .Where(ad => ad.ItemId == strItem.Id && ad.STR_Add.StoreId == storeId)
                        .Sum(ad => ad.Qty),
                    WithdrawQty = _context.StrWithDrawDetails
                        .Where(wd => wd.ItemId == strItem.Id && wd.STR_Withdraw.StoreId == storeId)
                        .Sum(wd => wd.Qty),
                    StoreName = _context.StrAdd
                        .Where(ad => ad.StoreId == storeId)
                        .Select(ad => ad.STR_Store.Name)
                        .FirstOrDefault()
                })
                .Where(result => result.OpeningStockQty > 0 || result.AddQty > 0 || result.WithdrawQty > 0)
                .Select(result => new
                {
                    ItemId = result.Item.Id,
                    Name = result.Item.Name,
                    FullCode = result.Item.FullCode,
                    CommodityName = result.Item.STR_Commodity.Name,
                    GradeName = result.Item.STR_Grade.Name,
                    GroupName = result.Item.STR_Group.Name,
                    StoreName = result.StoreName,
                    OpeningStockQty = result.OpeningStockQty,
                    AddQty = result.AddQty,
                    WithdrawQty = result.WithdrawQty,
                    TotalQty = result.OpeningStockQty + result.AddQty - result.WithdrawQty
                })
                .Where(result => result.TotalQty > 0)
                .Select(result => new
                {
                    Name = result.Name,
                    ItemId = result.ItemId,
                    FullCode = result.FullCode
                })
                .ToList<object>();

            return itemDetails;
        }
        public List<dynamic> GetItemInStores(int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            var addQuery = (
                 from strAddDetails in _context.StrAddDetails
                 join strItem in _context.StrItem on strAddDetails.ItemId equals strItem.Id
                 join strAdd in _context.StrAdd on strAddDetails.AddId equals strAdd.Id into addGroup
                 from strAdd in addGroup.DefaultIfEmpty()
                 where strAdd.FiscalYearId == FiscalYearId && strItem.Id == itemId ||
                 (strAdd.Date >= startdate && strAdd.Date <= enddate &&
                 strAdd.Date.AddSeconds(-strAdd.Date.Second) >= startdate &&
                 strAdd.Date.AddSeconds(-strAdd.Date.Second) <= enddate)
                 select new TransactionDetail
                 {
                     StartDate = startdate.ToString("dd/MM/yyyy"),
                     EndDate = enddate.ToString("dd/MM/yyyy"),
                     Billid = strAdd.Id,
                     StoreId = strAdd.StoreId,
                     StoreName = strAdd.STR_Store.Name,
                     Section = strAdd.STR_Store.Section.Name,
                     ItemCode = strItem.FullCode,
                     Name = strItem.Name,
                     Unit = strItem.STR_Unit.Name,
                     Qty = strAddDetails.Qty,
                     //outcomeQty = 0f,
                     Price = strAddDetails.Price,
                     AvgPrice =  _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                     BillNo = strAdd.No,
                     Total = strAddDetails.Price * strAddDetails.Qty,
                     TransactionName = "اضافة",
                     TransactionID = strAdd.CreatedBy.Id,
                     CreatUsername = strAdd.CreatedBy.Name,
                     Date = strAdd.Date,
                     TheDate = strAdd.Date.ToString("dd/MM/yyyy"),
                     ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                 }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ThenBy(x => x.StoreId).ToList();

            var withdrawQuery = (
                        from strWithdrawDetails in _context.StrWithDrawDetails
                        join strItem in _context.StrItem on strWithdrawDetails.ItemId equals strItem.Id
                        join strWithdraw in _context.StrWithDraw on strWithdrawDetails.STR_WithdrawId equals strWithdraw.Id into withdrawGroup
                        from strWithdraw in withdrawGroup.DefaultIfEmpty()
                        where strWithdraw.FiscalYearId == FiscalYearId && strItem.Id == itemId
                        || (strWithdraw.Date >= startdate && strWithdraw.Date <= enddate &&
                        strWithdraw.Date.AddSeconds(-strWithdraw.Date.Second) >= startdate &&
                        strWithdraw.Date.AddSeconds(-strWithdraw.Date.Second) <= enddate)

                        select new TransactionDetail
                        {
                            StartDate = startdate.ToString("dd/MM/yyyy"),
                            EndDate = enddate.ToString("dd/MM/yyyy"),
                            Billid = strWithdraw.Id,
                            StoreId = strWithdraw.StoreId,
                            StoreName = strWithdraw.STR_Store.Name,
                            ItemCode = strItem.FullCode,
                            Name = strItem.Name,
                            Unit = strItem.STR_Unit.Name,
                            Section = strWithdraw.STR_Store.Section.Name,
                            //IncomeQty = 0f,
                            Qty = strWithdrawDetails.Qty,
                            Price = strWithdrawDetails.Price,   
                            AvgPrice = _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                            BillNo = strWithdraw.No,
                            Total = strWithdrawDetails.Price * strWithdrawDetails.Qty,
                            TransactionName = "صرف",
                            TransactionID = strWithdraw.CreatedBy.Id,
                            CreatUsername = strWithdraw.CreatedBy.Name,
                            Date = strWithdraw.Date,
                            TheDate = strWithdraw.Date.ToString("dd/MM/yyyy"),
                            ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                        }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ThenBy(x => x.StoreId).ToList();

            var openingStockQuery = (
               from StrOpeningStockDetails in _context.StrOpeningStockDetails
               join strItem in _context.StrItem on StrOpeningStockDetails.ItemId equals strItem.Id
               join StrOpeningStock in _context.StrOpeningStock on StrOpeningStockDetails.STR_Opening_StockId equals StrOpeningStock.Id into StrOpeningStockGroup
               from StrOpeningStock in StrOpeningStockGroup.DefaultIfEmpty()
               where StrOpeningStock.FiscalYearId == FiscalYearId && strItem.Id == itemId
               ||
               (StrOpeningStock.Date >= startdate && StrOpeningStock.Date <= enddate
               && StrOpeningStock.Date.AddSeconds(-StrOpeningStock.Date.Second) >= startdate &&
               StrOpeningStock.Date.AddSeconds(-StrOpeningStock.Date.Second) <= enddate)

               select new TransactionDetail
               {
                   StartDate = startdate.ToString("dd/MM/yyyy"),
                   EndDate = enddate.ToString("dd/MM/yyyy"),
                   Billid = StrOpeningStock.Id,
                   StoreId = StrOpeningStock.StoreId,
                   StoreName = StrOpeningStock.STR_Store.Name,
                   ItemCode = strItem.FullCode,
                   Name = strItem.Name,
                   Unit = strItem.STR_Unit.Name,
                   Section = StrOpeningStock.STR_Store.Section.Name,
                   //IncomeQty = 0f,
                   Qty = StrOpeningStockDetails.Qty,
                   Price = StrOpeningStockDetails.Price,
                   AvgPrice = _StrAddDetailsRepository.GetAvgPrice(FiscalYearId, strItem.Id, startdate, enddate),
                   BillNo = StrOpeningStock.No,
                   Total = StrOpeningStockDetails.Price * StrOpeningStockDetails.Qty,
                   TransactionName = "افتتاحي",
                   TransactionID = StrOpeningStock.CreatedBy.Id,
                   CreatUsername = StrOpeningStock.CreatedBy.Name,
                   //EmployeeId = StrOpeningStock.EmployeeId,
                   Date = StrOpeningStock.Date,
                   TheDate = StrOpeningStock.Date.ToString("dd/MM/yyyy"),
                   ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
               }).OrderBy(x => x.Date).ThenBy(x => x.Billid).ThenBy(x => x.StoreId).ToList();

            var result = openingStockQuery
               .Union(addQuery)
               .Union(withdrawQuery);

            List<dynamic> dynamicResult = result.Cast<dynamic>().ToList();
            return dynamicResult;

        }

        readonly List<int> CommodityStock = new() { 1, 2, 3, 4, 5, 7 };
        readonly int OpeningInvestCode = 6;
        public async Task<List<BalanceStoreViewModel>> GetBalanceStoreAsync (int storeId, DateTime startDate, DateTime endDate, int fiscalYearId)
        {
            List<StrOpeningStockDetails> openStockCommodity = await _context
                .StrOpeningStockDetails
                .Where(e =>
                    e.STR_Opening_Stock.StoreId == storeId &&
                    e.STR_Opening_Stock.FiscalYearId == fiscalYearId &&
                    CommodityStock.Contains(e.STR_Item.STR_Commodity.Code))
                    .OrderBy(e => e.STR_Item.FullCode).ToListAsync();

            List<StrOpeningStockDetails> openStockInvest = await
                _context
                .StrOpeningStockDetails
                .Where(e =>
                e.STR_Opening_Stock.StoreId == storeId &&
                e.STR_Opening_Stock.FiscalYearId == fiscalYearId &&
                e.STR_Item.STR_Grade.CommodityId == OpeningInvestCode)
                .OrderBy(e => e.STR_Item.FullCode).ToListAsync();

            List<StrOpeningStockDetails> unionedList =
                openStockCommodity.Union(openStockInvest).ToList();

            return unionedList.Select(e =>
                e.ToBalanceStoreViewModel(
                    startDate,
                    endDate,
                    StrAddQtyAndTotal
                        (e.ItemId,
                        storeId,
                        fiscalYearId,
                        startDate,
                        endDate),
                    StrWithdrawQtyAndTotal
                    (
                        e.ItemId,
                        storeId,
                        fiscalYearId,
                        startDate,
                        endDate
                     ), _StrAddDetailsRepository.GetAvgPrice(fiscalYearId, e.ItemId, startDate, endDate)))
                .ToList();
        }

        public QuantityAndTotal StrAddQtyAndTotal(int itemId, int storeId, int fiscalYearId, DateTime startDate, DateTime endDate)
        {
            //List<int> addingTypes = new() { 1, 11, 13, 14 };

            // add where SourceStore == null
            QuantityAndTotal result = new();

            IQueryable<StrAddDetails> MainSourceCommodity =
                _context
                .StrAddDetails.
                Where(e =>
                    e.ItemId == itemId &&
                    e.STR_Add.StoreId == storeId &&
                    e.STR_Add.FiscalYearId == fiscalYearId &&
                    (e.STR_Add.Date >= startDate && e.STR_Add.Date <= endDate) &&
                    CommodityStock.Contains(e.STR_Item.STR_Commodity.Code));

            result.QtyCommoditiesFromStore =
                MainSourceCommodity
                .Where(e => e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.QtyCommoditiesNotFromStore =
                MainSourceCommodity
                .Where(e => !e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.TotalCommoditiesFromStore =
                 MainSourceCommodity
                 .Where(e => e.STR_Add.SourceStoreId.HasValue)
                 .Select(e => e.Total).Sum();

            result.TotalCommoditiesNotFromStore =
                 MainSourceCommodity
                 .Where(e => !e.STR_Add.SourceStoreId.HasValue)
                 .Select(e => e.Total).Sum();

            IQueryable<StrAddDetails> MainSourceInvest =
                _context
                .StrAddDetails.
                Where(e =>
                    e.ItemId == itemId &&
                    e.STR_Add.StoreId == storeId &&
                    e.STR_Add.FiscalYearId == fiscalYearId &&
                    (e.STR_Add.Date >= startDate && e.STR_Add.Date <= endDate) &&
                    e.STR_Item.CommodityId == OpeningInvestCode);

            result.QtyInvestFromStore =
                MainSourceInvest
                .Where(e => e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.QtyInvestNotFromStore =
                MainSourceInvest
                .Where(e => !e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Qty).Sum();
            result.TotalInvestFromStore =

                MainSourceInvest
                .Where(e => e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Total).Sum();

            result.TotalInvestNotFromStore =
                MainSourceInvest
                .Where(e => !e.STR_Add.SourceStoreId.HasValue)
                .Select(e => e.Total).Sum();

            return result;

        }

        public QuantityAndTotal StrWithdrawQtyAndTotal
            (int itemId, int storeId, int fiscalYearId, DateTime startDate, DateTime endDate)
        {
            //List<int> addingTypes = new() { 1, 11, 13, 14 };

            // add where SourceStore == null
            QuantityAndTotal result = new();

            IQueryable<StrWithDrawDetails> MainSourceCommodity =
                _context
                .StrWithDrawDetails.
                Where(e =>
                    e.ItemId == itemId &&
                    e.STR_Withdraw.StoreId == storeId &&
                    e.STR_Withdraw.FiscalYearId == fiscalYearId &&
                    (e.STR_Withdraw.Date >= startDate && e.STR_Withdraw.Date <= endDate) &&
                    CommodityStock.Contains(e.STR_Item.STR_Commodity.Code));

            result.QtyCommoditiesFromStore =
                MainSourceCommodity
                .Where(e => e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.TotalCommoditiesFromStore =
                 MainSourceCommodity
                 .Where(e => e.STR_Withdraw.DestStoreId.HasValue)
                 .Select(e => e.Total).Sum();

            result.QtyCommoditiesNotFromStore =
                MainSourceCommodity
                .Where(e => !e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.TotalCommoditiesNotFromStore =
                 MainSourceCommodity
                 .Where(e => !e.STR_Withdraw.DestStoreId.HasValue)
                 .Select(e => e.Total).Sum();

            IQueryable<StrWithDrawDetails> MainSourceInvest =
                _context
                .StrWithDrawDetails.
                Where(e =>
                    e.ItemId == itemId &&
                    e.STR_Withdraw.StoreId == storeId &&
                    e.STR_Withdraw.FiscalYearId == fiscalYearId &&
                    (e.STR_Withdraw.Date >= startDate && e.STR_Withdraw.Date <= endDate) &&
                    e.STR_Item.CommodityId == OpeningInvestCode);

            result.QtyInvestFromStore =
                MainSourceInvest
                .Where(e => e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.TotalInvestFromStore =
                MainSourceInvest
                .Where(e => e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Total).Sum();

            result.QtyInvestNotFromStore =
                MainSourceInvest
                .Where(e => !e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Qty).Sum();

            result.TotalInvestNotFromStore =
                MainSourceInvest
                .Where(e => !e.STR_Withdraw.DestStoreId.HasValue)
                .Select(e => e.Total).Sum();

            return result;

        }
    }
}
