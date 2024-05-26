using Entities.Models.STR.Add;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Entities.ViewModels.STR.AddDetails.StrAddDetailsGeneralVM;

namespace DAL.STR.Add
{
    public class StrAddDetailsRepository
    {
        private AppDbContext _context;

        public StrAddDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrAddWithavgprice Add_Details)
        {
            StrAddVM strAdd = new StrAddVM();
            bool exists = _context.StrAddDetails.Any(s => s.ItemId == Add_Details.ItemId && s.AddId == Add_Details.AddId);
            if (exists)
            {
                return "item already exists.";
            }

            var _Add_Details = new StrAddDetails()
            {
                AddId = Add_Details.AddId,
                State = Add_Details.State,
                ItemId = Add_Details.ItemId,
                //ProductId = Add_Details.ProductId,
                Qty = Add_Details.Qty,
                Price = Add_Details.Price,
                Total = Add_Details.Total,
                Notes = Add_Details.Notes,

                //AvgPrice = Add_Details.AvgPrice,
                // newavgavprice(Add_Details.storeid, Add_Details.ItemId, Add_Details.Qty, Add_Details.Price, Add_Details.FiscalYearId, Add_Details.date),
                AvgPrice = NewAvgPrice(Add_Details.ItemId, Add_Details.Price,Add_Details.FiscalYearId),
                BalanceQty = GetSumOfQty(Add_Details.storeid, Add_Details.ItemId),
                Percentage = Add_Details.Percentage,
                CreatedByID = Add_Details.TransactionUserId,
                LastUpdateDate = DateTime.Now
            };
            _context.StrAddDetails.Add(_Add_Details);
            _context.SaveChanges();
            return _Add_Details.Id.ToString();

        }
        public string Update(StrAddWithavgprice add_Details)
        {
            bool exists = _context.StrAddDetails.Any(s => s.ItemId == add_Details.ItemId && s.AddId == add_Details.AddId && s.Id != add_Details.Id);
            if (exists)
            {
                return "item already exists.";
            }
            var _add_Details = _context.StrAddDetails.Single(n => n.Id == add_Details.Id);


            _add_Details.ItemId = add_Details.ItemId;
            //_add_Details.ProductId = add_Details.ProductId;
            _add_Details.Qty = add_Details.Qty;
            _add_Details.Price = add_Details.Price;
            _add_Details.Total = add_Details.Total;
            _add_Details.Notes = add_Details.Notes;
            _add_Details.State = add_Details.State;
            _add_Details.AvgPrice = NewAvgPrice(_add_Details.ItemId, _add_Details.Price, _add_Details.STR_Add.FiscalYearId);
            //_add_Details.AvgPrice = add_Details.AvgPrice; newavgavprice(add_Details.storeid, add_Details.ItemId, add_Details.Qty, add_Details.Price, add_Details.FiscalYearId, add_Details.date);
            _add_Details.BalanceQty = GetSumOfQty(add_Details.storeid, add_Details.ItemId);
            _add_Details.UpdateByID = add_Details.TransactionUserId;
            _add_Details.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();

            return "Succeeded";

        }
        public string Delete(int add_DetailsId)
        {

            var _add_Details = _context.StrAddDetails.Single(n => n.Id == add_DetailsId);

            _context.StrAddDetails.Remove(_add_Details);
            _context.SaveChanges();
            return "Succeeded";

        }
        public List<StrAddDetailsGetVM> GetAll() => _context.StrAddDetails.Select(
            n => new StrAddDetailsGetVM
            {
                Id = n.Id,
                Qty = n.Qty,
                Price = n.Price,
                State = n.State,
                Percentage = n.Percentage,
                Notes = n.Notes,
                ItemName = n.STR_Item.Name,
                ItemId = n.STR_Item.Id,
                AddId = n.AddId,
                AddNo = n.STR_Add.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Total = n.Total
            }).ToList();
        public StrAddDetailsGetVM GetById(int add_DetailsId)
            => _context.StrAddDetails.Select(
                n => new StrAddDetailsGetVM
                {
                    Id = n.Id,
                    Qty = n.Qty,
                    Price = n.Price,
                    State = n.State,
                    Percentage = n.Percentage,
                    Notes = n.Notes,
                    ItemName = n.STR_Item.Name,
                    ItemId = n.STR_Item.Id,
                    AddId = n.AddId,
                    AddNo = n.STR_Add.No,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    Total = n.Total
                }).Single(n => n.Id == add_DetailsId);
        //public List<GetAddDetailsByAddIdVM> GetAddGeTAddDetailsByAddId(int strAddId)
        //{
        //    var result = _context.StrAdd
        //        .Where(sa => sa.Id == strAddId)
        //        .Select(sa => new GetAddDetailsByAddIdVM
        //        {
        //            StrAddGetVM = new StrAddGetVM
        //            {
        //                Id = sa.Id,
        //                Date = sa.Date,
        //                No = sa.No,
        //                Total = sa.Total,
        //                Notes = sa.Notes,
        //                SellerId = sa.SellerId,
        //                SourceStoreId = sa.SourceStoreId,
        //                StoreId = sa.StoreId,
        //                EmployeeId = sa.EmployeeId,
        //                StoreName = sa.STR_Store.Name,
        //                SellerName = sa.PRO_Seller.Name,
        //                EmployeeName = sa.HR_Employee.Name,
        //                fiscalyear = sa.fiscalyear.fiscalyear,
        //                SourceStoreName = sa.STR_Store1.Name,
        //                CreateUserName = sa.CreatedBy.Name,
        //                TransactionUserId = sa.CreatedBy.Id
        //            },
        //            StrAddDetailsGetVM = sa.STR_Add_Details
        //                .Where(ssd => ssd.AddId == strAddId)
        //                .Select(ssd => new StrAddDetailsGetVM
        //                {
        //                    Id = ssd.Id,
        //                    ItemId = ssd.ItemId,
        //                    Qty = ssd.Qty,
        //                    Price = ssd.Price,
        //                    Total = ssd.Total,
        //                    Notes = ssd.Notes,
        //                    TransactionUserId = ssd.CreatedBy.Id,
        //                    ItemName = ssd.STR_Item.Name,
        //                    FullCode = ssd.STR_Item.FullCode,
        //                    AddId = ssd.AddId,
        //                    AddNo = ssd.STR_Add.No,
        //                    CreateUserName = ssd.CreatedBy.Name
        //                })
        //                .ToList()
        //        })
        //        .FirstOrDefault();

        //    return result != null ? new List<GetAddDetailsByAddIdVM> { result } : new List<GetAddDetailsByAddIdVM>();

        //}
        public List<StrAddDetailsGetVM> Search(searchadd searchModel)

        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
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
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
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
                Section = searchModel.SectionId != null ? p.STR_Store.Section.Name : "",
            }).OrderBy(x => x.Date).ThenBy(x => x.Id).ToList();
            List<StrAddDetailsGetVM> items = new List<StrAddDetailsGetVM>();
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
        public List<StrAddDetailsGetVM> GetByHeader(int AddId)
      => _context.StrAddDetails.Where(n => n.AddId == AddId).Select(n => new StrAddDetailsGetVM
          {
              //Add Header
              AddId = n.AddId,
              HeaderStoreName = n.STR_Add.STR_Store.Name,
              HeaderSourceName =
                  n.STR_Add.Seller.Name == null ?
                      (n.STR_Add.SourceStore.Name == null ?
                          (n.STR_Add.Employee.Name == null ? ""
                           : n.STR_Add.Employee.Name)
                      : n.STR_Add.SourceStore.Name)
                  : n.STR_Add.Seller.Name,
              //HeaderSellerName = n.STR_Add.PRO_Seller.Name,
              //HeaderSourceStoreName = n.STR_Add.STR_Store1.Name,
              HeaderEmployeeName = n.STR_Add.Employee.Name,
              HeaderCreateUserName = n.STR_Add.CreatedBy.Name,
              HeaderFiscalYear = n.STR_Add.fiscalyear.fiscalyear,
              HeaderDate = n.STR_Add.Date.ToString("dd/MM/yyyy"),
              HeaderType = n.STR_Add.AddType.Name,
              HeaderTotal = n.STR_Add.Total,
              ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
              //Details
              Id = n.Id,
              Unit = n.STR_Item.STR_Unit.Name,
              Qty = n.Qty,
              Price = n.Price,
              State = n.State,
              Percentage = n.Percentage,
              Notes = n.Notes,
              ItemId = n.STR_Item.Id,
              ItemName = n.STR_Item.Name,
              FullCode = n.STR_Item.FullCode,
              //ProductId = n.ProductId,
              //ProductName = n.Product.Name,
              AddNo = n.STR_Add.No,
              TransactionUserId = n.CreatedBy.Id,
              CreateUserName = n.CreatedBy.Name,
              Total = n.Total,



          }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrAddDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.StrAddDetails.Where(n => n.AddId == HeaderId).Count();
            List<int> fientryD = _context.StrAddDetails
                .Where(sus => sus.AddId == HeaderId)
                .Select(sus => sus.AddId)
                .ToList();
            List<StrAddDetailsGetVM> Item = _context.StrAddDetails
                .Where(n => fientryD.Contains(n.AddId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new StrAddDetailsGetVM
                {

                    //Add Header
                    AddId = n.AddId,
                    HeaderStoreName = n.STR_Add.STR_Store.Name,
                    HeaderSourceName = n.STR_Add.Seller.Name == null ? n.STR_Add.SourceStore.Name : n.STR_Add.Seller.Name,
                    //HeaderSellerName = n.STR_Add.PRO_Seller.Name,
                    //HeaderSourceStoreName = n.STR_Add.STR_Store1.Name,
                    HeaderEmployeeName = n.STR_Add.Employee.Name,
                    HeaderCreateUserName = n.STR_Add.CreatedBy.Name,
                    HeaderFiscalYear = n.STR_Add.fiscalyear.fiscalyear,
                    HeaderDate = n.STR_Add.Date.ToString("dd/MM/yyyy"),
                    //Details
                    Id = n.Id,
                    Qty = n.Qty,
                    Price = n.Price,
                    State = n.State,
                    Percentage = n.Percentage,
                    Notes = n.Notes,
                    ItemId = n.STR_Item.Id,
                    ItemName = n.STR_Item.Name,
                    FullCode = n.STR_Item.FullCode,
                    //ProductId = n.ProductId,
                    //ProductName = n.Product.Name,
                    AddNo = n.STR_Add.No,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    Total = n.Total,

                })
                .ToList();

            var paginatedResult = new PaginatedResult<StrAddDetailsGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
        public decimal GetSumOfQty(int storeid, int itemid, DateTime? startDate = null, DateTime? endDate = null)
        {

            decimal sumwithdrawdetails = (from b in _context.StrWithDrawDetails
                                        join a in _context.StrWithDraw
                                        on b.STR_WithdrawId equals a.Id
                                        where a.StoreId == storeid & b.ItemId == itemid
                                        select b.Qty).Sum();
            decimal sumstradd = (from b in _context.StrAddDetails
                                 join a in _context.StrAdd
                                 on b.AddId equals a.Id
                                 where a.StoreId == storeid & b.ItemId == itemid && (a.Date >= startDate && a.Date <= endDate &&
                                 a.Date.AddSeconds(-a.Date.Second) >= startDate &&
                                 a.Date.AddSeconds(-a.Date.Second) <= endDate)
                                 select b.Qty).Sum();
            decimal sumopeningstock = (from b in _context.StrOpeningStockDetails
                                       join a in _context.StrOpeningStock
                                       on b.STR_Opening_StockId equals a.Id
                                       where a.StoreId == storeid & b.ItemId == itemid && (a.Date >= startDate && a.Date <= endDate &&
                                       a.Date.AddSeconds(-a.Date.Second) >= startDate &&
                                       a.Date.AddSeconds(-a.Date.Second) <= endDate)
                                       select b.Qty).Sum();
            decimal totalsum = (sumstradd + sumopeningstock) - sumwithdrawdetails;

            return totalsum;

        }
        public decimal GetAvgPrice(int FiscalYearid, int itemid, DateTime? startDate = null, DateTime? endDate = null)
        {
            StrAddDetails lastStrAddDetails = _context
                .StrAddDetails
                .OrderBy(sd => sd.STR_Add.Date)
                .LastOrDefault(sd =>
                    sd.ItemId == itemid &&
                    sd.STR_Add.FiscalYearId == FiscalYearid &&
                    (!startDate.HasValue && !endDate.HasValue
                    ||
                    sd.STR_Add.Date >= startDate.Value && sd.STR_Add.Date <= endDate.Value));
            decimal avgPrice = lastStrAddDetails != null ?
                lastStrAddDetails.AvgPrice : 0;

            //decimal avgprice = (from stradddetails in _context.StrAddDetails
            //                  join stradd in _context.StrAdd
            //                  on stradddetails.AddId equals stradd.Id
            //                  where stradd.Date <= Date && stradddetails.ItemId == itemid
            //                  && stradd.StoreId == storeid
            //                  && stradd.FiscalYearId == FiscalYearid
            //                  select stradddetails.AvgPrice).FirstOrDefault();

            if (avgPrice != 0)
            {
                return avgPrice;
            }
            else
            {
                StrOpeningStockDetails lastStrOpeningStockDetails =
                    _context
                    .StrOpeningStockDetails
                    .OrderBy(sd => sd.CreationDate)
                    .LastOrDefault(e =>
                        e.STR_Opening_Stock.FiscalYearId == FiscalYearid && e.ItemId == itemid);
                avgPrice = lastStrOpeningStockDetails != null ?
                    lastStrOpeningStockDetails.Price : 0;
                //decimal openavgprice = (from strOpeningStockDetails in _context.StrOpeningStockDetails
                //                      join strOpeningStock in _context.StrOpeningStock
                //                      on strOpeningStockDetails.STR_Opening_StockId equals strOpeningStock.Id
                //                      where strOpeningStock.Date <= Date && strOpeningStockDetails.ItemId == itemid
                //                      && strOpeningStock.StoreId == storeid
                //                      && strOpeningStock.FiscalYearId == FiscalYearid
                //                      select strOpeningStockDetails.Price).FirstOrDefault();
                return avgPrice;

            }

            // return avgprice;




        }
        public decimal NewAvgPrice(int itemid, decimal newprice, int FiscalYearId)
        {
            //decimal BalanceQuantity;
            //decimal totaladddetails;
            //decimal totalqty;

            //decimal totalnewqtyprice;
            decimal OldAvgPrice = GetAvgPrice(FiscalYearId, itemid);
            if (OldAvgPrice == 0)
            {
                return newprice;
            }
            else
            {
                //BalanceQuantity = GetSumOfQty(storeid, itemid);
                //totaladddetails = BalanceQuantity * OldAvgPrice;

                //totalnewqtyprice = newprice * qty;
                //totalqty = qty + BalanceQuantity;
                decimal newavgprice = (newprice + OldAvgPrice) / 2;
                return newavgprice;
            }

        }

        //public decimal GetSumOfQtyadd(int storeid, int addtypeid ,int commodityId,int sectionId, DateTime startdate ,DateTime enddate)
        //{

        //    decimal sumstradd = (

        //    from b in _context.StrAddDetails
        //    join a in _context.StrAdd on b.AddId equals a.Id 
        //    where a.StoreId == storeid & a.AddTypeId == addtypeid && a.Date >= startdate && a.Date <= enddate &&
        //    a.Date.AddSeconds(-a.Date.Second) >= startdate &&
        //    a.Date.AddSeconds(-a.Date.Second) <= enddate
        //    join item in _context.StrItem on b.ItemId equals item.Id into itemJoin
        //    from item in itemJoin.DefaultIfEmpty()
        //    join Grade in _context.StrGrade on item.GradeId equals Grade.Id into GradeJoin
        //    from Grade in GradeJoin.DefaultIfEmpty()
        //    join store in _context.StrStore on a.StoreId equals store.Id into storeJoin
        //    from store in storeJoin.DefaultIfEmpty()
        //    join section in _context.ImsSection on store.SectionId equals section.Id into sectionJoin
        //    from section in sectionJoin.DefaultIfEmpty()
        //    join commodity in _context.StrCommodity on item.CommodityId equals commodity.Id into commodityJoin
        //    from commodity in commodityJoin.DefaultIfEmpty()
        //    where commodity.Id == commodityId && store.SectionId == sectionId && Grade.CommodityId == 6
        //    select (b.Qty)).Sum();

        //    decimal totalsum = sumstradd ;

        //    return totalsum;

        //}


        public (decimal sumOfQty, decimal sumOfTotal) GetSumOfQtyaddtype(int storeid, int addtypeid, DateTime startdate, DateTime enddate)
        {

            decimal sumOfQty = (from b in _context.StrAddDetails
                              join a in _context.StrAdd on b.AddId equals a.Id
                              where a.StoreId == storeid && a.AddTypeId == addtypeid && a.Date >= startdate && a.Date <= enddate &&
                                  a.Date.AddSeconds(-a.Date.Second) >= startdate &&
                                  a.Date.AddSeconds(-a.Date.Second) <= enddate
                              select b.Qty).Sum();

            decimal sumOfTotal = (
                from b in _context.StrAddDetails
                join a in _context.StrAdd on b.AddId equals a.Id
                where a.StoreId == storeid && a.AddTypeId == addtypeid && a.Date >= startdate && a.Date <= enddate &&
                    a.Date.AddSeconds(-a.Date.Second) >= startdate &&
                    a.Date.AddSeconds(-a.Date.Second) <= enddate
                select b.Total
            ).Sum();

            return (sumOfQty, sumOfTotal);
        }
        public (decimal sumOfQty, decimal sumOfTotal) GetSumOfQtywithdrawtype(int storeid, int WithDrawTypeId, DateTime startdate, DateTime enddate)
        {
            decimal sumOfQty = (
                from b in _context.StrWithDrawDetails
                join a in _context.StrWithDraw
                on b.STR_WithdrawId equals a.Id
                where a.StoreId == storeid && a.WithDrawTypeId == WithDrawTypeId && a.Date >= startdate && a.Date <= enddate &&
              a.Date.AddSeconds(-a.Date.Second) >= startdate &&
              a.Date.AddSeconds(-a.Date.Second) <= enddate
                select b.Qty
            ).Sum();

            decimal sumOfTotal = (
                from b in _context.StrWithDrawDetails
                join a in _context.StrWithDraw
                on b.STR_WithdrawId equals a.Id
                where a.StoreId == storeid && a.WithDrawTypeId == WithDrawTypeId && a.Date >= startdate && a.Date <= enddate &&
              a.Date.AddSeconds(-a.Date.Second) >= startdate &&
              a.Date.AddSeconds(-a.Date.Second) <= enddate
                select b.Total
            ).Sum();

            return (sumOfQty, sumOfTotal);
        }

    }

}
