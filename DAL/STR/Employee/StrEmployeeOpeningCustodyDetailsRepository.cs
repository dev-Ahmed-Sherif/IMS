using DAL.STR.General;
using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Employee
{
    public class StrEmployeeOpeningCustodyDetailsRepository
    {
        private AppDbContext _context;
        public StrFiscalYearRepository _strFiscalRepository;
        public StrEmployeeOpeningCustodyDetailsRepository(AppDbContext context, StrFiscalYearRepository strFiscalRepository)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
        }
        public string Add(StrEmployeeOpeningCustodyDetailsVM STR_Employee_Opening_Custody_Details)
        {
            bool exists = _context.StrEmployeeOpeningCustodyDetails.Any(s => s.ItemId == STR_Employee_Opening_Custody_Details.ItemId && s.CustodyId == STR_Employee_Opening_Custody_Details.CustodyId && s.Id != STR_Employee_Opening_Custody_Details.Id);
            if (exists)
            {
                return "item already exists.";
            }

            var _STR_Employee_Opening_Custody_Details = new StrEmployeeOpeningCustodyDetails()
                {
                    Qty = STR_Employee_Opening_Custody_Details.Qty,
                    Price = STR_Employee_Opening_Custody_Details.Price,
                    Total = STR_Employee_Opening_Custody_Details.Total,
                    State = STR_Employee_Opening_Custody_Details.State,
                    Percentage = STR_Employee_Opening_Custody_Details.Percentage,
                    Notes = STR_Employee_Opening_Custody_Details.Notes,
                    CustodyId = STR_Employee_Opening_Custody_Details.CustodyId,
                    ItemId = STR_Employee_Opening_Custody_Details.ItemId,
                    //ProductId = STR_Employee_Opening_Custody_Details.ProductId,

                    CreatedByID = STR_Employee_Opening_Custody_Details.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.StrEmployeeOpeningCustodyDetails.Add(_STR_Employee_Opening_Custody_Details);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(StrEmployeeOpeningCustodyDetailsVM STR_Employee_Opening_Custody_Details)
        {
            bool exists = _context.StrEmployeeOpeningCustodyDetails.Any(s => s.ItemId == STR_Employee_Opening_Custody_Details.ItemId && s.CustodyId == STR_Employee_Opening_Custody_Details.CustodyId && s.Id != STR_Employee_Opening_Custody_Details.Id);
            if (exists)
            {
                throw new Exception("store already exists.");
            }
            var _item = _context.StrEmployeeOpeningCustodyDetails.Single(n => n.Id == STR_Employee_Opening_Custody_Details.Id);
               
                    _item.Qty = STR_Employee_Opening_Custody_Details.Qty;
                    _item.Price = STR_Employee_Opening_Custody_Details.Price;
                    _item.Total = STR_Employee_Opening_Custody_Details.Total;
                    _item.State = STR_Employee_Opening_Custody_Details.State;
                    _item.Percentage = STR_Employee_Opening_Custody_Details.Percentage;
                    _item.Notes = STR_Employee_Opening_Custody_Details.Notes;
                    _item.CustodyId = STR_Employee_Opening_Custody_Details.CustodyId;
                    _item.ItemId = STR_Employee_Opening_Custody_Details.ItemId;
                    //_item.ProductId = STR_Employee_Opening_Custody_Details.ProductId;

                    _item.UpdateByID = STR_Employee_Opening_Custody_Details.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }
        public string Delete(int itemId)
        {
          
                var _item = _context.StrEmployeeOpeningCustodyDetails.Single(n => n.Id == itemId);
             

                    _context.StrEmployeeOpeningCustodyDetails.Remove(_item);
                    _context.SaveChanges();
                    return "Succeeded";
                
             
            
           
        }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> GetAll() => _context.StrEmployeeOpeningCustodyDetails.Select(n => new StrEmployeeOpeningCustodyDetailsGetVM { Id = n.Id, Qty = n.Qty, Price = n.Price, Total = n.Total, Notes = n.Notes, State = n.State, Percentage = n.Percentage, CustodyId = n.CustodyId, ItemId = n.ItemId, ItemName = n.STR_Item.Name, CustodyNO = n.STR_Employee_Opening_Custody.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrEmployeeOpeningCustodyDetailsGetVM GetById(int itemId) => _context.StrEmployeeOpeningCustodyDetails.Select(n => new StrEmployeeOpeningCustodyDetailsGetVM { Id = n.Id, Qty = n.Qty, Price = n.Price, Total = n.Total, Notes = n.Notes, State = n.State, Percentage = n.Percentage, CustodyId = n.CustodyId, ItemId = n.ItemId, ItemName = n.STR_Item.Name, CustodyNO = n.STR_Employee_Opening_Custody.No }).Single(n => n.Id == itemId);
        public List<StrEmployeeOpeningCustodyDetailsGetVM> search(searchemployeeopeningcustody searchModel)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById((int)searchModel.FiscalYearId);

            string startDate, endDate;
            startDate = fiscalYear.StartDate.ToString("dd/MM/yyyy");
            endDate = fiscalYear.EndDate.ToString("dd/MM/yyyy");


            var query = _context.StrEmployeeOpeningCustody.AsQueryable();
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
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.ItemId.HasValue)
            {
                query = query.Where(p => p.STR_Employee_Opening_Custody_Details.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.HR_Employee.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrEmployeeOpeningCustodyGetVM
            {
                Id = p.Id,
                Section = p.HR_Employee.SectionId.HasValue ? p.HR_Employee.Section.Name : "",
            }).ToList();
            List<StrEmployeeOpeningCustodyDetailsGetVM> items = new List<StrEmployeeOpeningCustodyDetailsGetVM>();
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
        public List<StrEmployeeOpeningCustodyDetailsGetVM> GetByHeader(int headerId) =>
            _context.StrEmployeeOpeningCustodyDetails
            .Where(n => n.CustodyId == headerId)
            .Select(n => new StrEmployeeOpeningCustodyDetailsGetVM
            {
                //Header Data
                CustodyId = n.CustodyId,
                HeaderEmployeeName = n.STR_Employee_Opening_Custody.HR_Employee.Name,
                HeaderCostCenterName = n.STR_Employee_Opening_Custody.CostCenter.Name,
                HeaderCreateUserName = n.STR_Employee_Opening_Custody.CreatedBy.Name,
                HeaderFiscalYear = n.STR_Employee_Opening_Custody.Fiscalyear.fiscalyear,
                HeaderDate = n.STR_Employee_Opening_Custody.Date,
                ShortHeaderDate = n.STR_Employee_Opening_Custody.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                HeaderNo = n.STR_Employee_Opening_Custody.No,
                HeaderTotal = n.STR_Employee_Opening_Custody.Total,
                //Section = n.STR_Employee_Opening_Custody.HR_Employee.Section.Name,
                //Details Data
                Id = n.Id,
                Unit = n.STR_Item.STR_Unit.Name,
                Qty = n.Qty,
                Price = n.Price,
                Total = n.Total,
                Notes = n.Notes,
                State = n.State,
                Percentage = n.Percentage,
                ItemId = n.ItemId,
                ItemName = n.STR_Item.Name,
                FullCode = n.STR_Item.FullCode,
                CustodyNO = n.STR_Employee_Opening_Custody.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrEmployeeOpeningCustodyDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.StrEmployeeOpeningCustodyDetails.Where(n => n.CustodyId == HeaderId).Count();
            List<int> fientryD = _context.StrEmployeeOpeningCustodyDetails
                .Where(sus => sus.CustodyId == HeaderId)
                .Select(sus => sus.CustodyId)
                .ToList();
            List<StrEmployeeOpeningCustodyDetailsGetVM> Item = _context.StrEmployeeOpeningCustodyDetails
                .Where(n => fientryD.Contains(n.CustodyId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new StrEmployeeOpeningCustodyDetailsGetVM
                {
                    //Header Data
                    CustodyId = n.CustodyId,
                    HeaderEmployeeName = n.STR_Employee_Opening_Custody.HR_Employee.Name,
                    HeaderCostCenterName = n.STR_Employee_Opening_Custody.CostCenter.Name,
                    HeaderCreateUserName = n.STR_Employee_Opening_Custody.CreatedBy.Name,
                    HeaderFiscalYear = n.STR_Employee_Opening_Custody.Fiscalyear.fiscalyear,
                    HeaderDate = n.STR_Employee_Opening_Custody.Date,
                    HeaderNo = n.STR_Employee_Opening_Custody.No,
                    HeaderTotal = n.STR_Employee_Opening_Custody.Total,
                    //Details Data
                    Id = n.Id,
                    Qty = n.Qty,
                    Price = n.Price,
                    Total = n.Total,
                    Notes = n.Notes,
                    State = n.State,
                    Percentage = n.Percentage,
                    ItemId = n.ItemId,
                    ItemName = n.STR_Item.Name,
                    FullCode = n.STR_Item.FullCode,
                    CustodyNO = n.STR_Employee_Opening_Custody.No,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<StrEmployeeOpeningCustodyDetailsGetVM>
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
