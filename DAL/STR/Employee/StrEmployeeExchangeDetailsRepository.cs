using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Employee
{
    public class StrEmployeeExchangeDetailsRepository
    {
        private AppDbContext _context;
        public StrEmployeeExchangeDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrEmployeeExchangeDetailsGeneralVM exchdet)
        {
            bool exists = _context.StrEmployeeExchangeDetails.Any(s => s.ItemId == exchdet.ItemId && s.Employee_ExchangeId== exchdet.Employee_ExchangeId );
            if (exists)
            {
                return "item already exists.";
            }
            var _exchdet = new StrEmployeeExchangeDetails()
            {
                Qty = exchdet.Qty,
                Price = exchdet.Price,
                Total = exchdet.Total,
                Notes = exchdet.Notes,
                State = exchdet.State,
                Percentage = exchdet.Percentage,
                ItemId = exchdet.ItemId,
                //ProductId = exchdet.ProductId,
                Employee_ExchangeId = exchdet.Employee_ExchangeId,

                CreatedByID = exchdet.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.StrEmployeeExchangeDetails.Add(_exchdet);
            _context.SaveChanges();
            return "Succeeded";

        }
        public string Update(StrEmployeeExchangeDetailsVM exchdet)
        {

            bool exists = _context.StrEmployeeExchangeDetails.Any(s => s.ItemId == exchdet.ItemId && s.Employee_ExchangeId == exchdet.Employee_ExchangeId && s.Id != exchdet.Id);
            if (exists)
            {
                return "item already exists.";
            }

            var _exchdet = _context.StrEmployeeExchangeDetails.Single(n => n.Id == exchdet.Id);
            _exchdet.Qty = exchdet.Qty;
            _exchdet.Price = exchdet.Price;
            _exchdet.Total = exchdet.Total;
            _exchdet.Notes = exchdet.Notes;
            _exchdet.State = exchdet.State;
            _exchdet.Percentage = exchdet.Percentage;
            _exchdet.ItemId = exchdet.ItemId;
            //_exchdet.ProductId = exchdet.ProductId;
            _exchdet.Employee_ExchangeId = exchdet.Employee_ExchangeId;

            _exchdet.UpdateByID = exchdet.TransactionUserId;
            _exchdet.LastUpdateDate = DateTime.Now;
            _context.SaveChanges();
            return "Succeeded";

        }
        public string Delete(int exchdetId)
        {

            var _exchdet = _context.StrEmployeeExchangeDetails.Single(n => n.Id == exchdetId);
          
                _context.StrEmployeeExchangeDetails.Remove(_exchdet);

            
            _context.SaveChanges();
            return "Succeeded";
        }
        public List<StrEmployeeExchangeDetailsGetVM> GetAll() => _context.StrEmployeeExchangeDetails.Select(n => new StrEmployeeExchangeDetailsGetVM { Id = n.Id, Qty = n.Qty, Price = n.Price, Total = n.Total, Notes = n.Notes, State = n.State, Percentage = n.Percentage, ItemId = n.ItemId, ItemName = n.STR_Item.Name, Employee_ExchangeId = n.Employee_ExchangeId, Employee_ExchangeNO = n.STR_Employee_Exchange.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrEmployeeExchangeDetailsGetVM GetById(int exchId) => _context.StrEmployeeExchangeDetails.Select(n => new StrEmployeeExchangeDetailsGetVM { Id = n.Id, Qty = n.Qty, Price = n.Price, Total = n.Total, Notes = n.Notes, State = n.State, Percentage = n.Percentage, ItemId = n.ItemId, ItemName = n.STR_Item.Name, Employee_ExchangeId = n.Employee_ExchangeId, Employee_ExchangeNO = n.STR_Employee_Exchange.No, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == exchId);
        public List<StrEmployeeExchangeDetailsGetVM> search(searchemployeeexchange searchModel)
        {

            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            var query = _context.StrEmployeeExchange.AsQueryable();

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
                query = query.Where(p => p.STR_Employee_Exchange_Details.Any(d => d.ItemId == searchModel.ItemId));
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.DestEmployeeId.HasValue)
            {
                query = query.Where(p => p.DestEmployeeId == searchModel.DestEmployeeId);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.Employee.SectionId == searchModel.SectionId);
            }
            var results = query.Select(p => new StrEmployeeExchangeGetVM
            {
                Id = p.Id,
                Section = p.Employee.SectionId.HasValue ? p.Employee.Section.Name : "",
            }).ToList();
            List<StrEmployeeExchangeDetailsGetVM> items = new List<StrEmployeeExchangeDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item.Id);
                if (isNotNull != null)
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
        public List<StrEmployeeExchangeDetailsGetVM> GetByHeader(int exchId) =>
            _context.StrEmployeeExchangeDetails
            .Where(n => n.Employee_ExchangeId == exchId)
            .Select(n => new StrEmployeeExchangeDetailsGetVM
            {
                //Header Data
                Employee_ExchangeId = n.Employee_ExchangeId,
                HeaderEmployeeName = n.STR_Employee_Exchange.Employee.Name,
                DestEmployeeName = n.STR_Employee_Exchange.DestEmployee.Name,
                HeaderCostCenterName = n.STR_Employee_Exchange.CostCenter.Name,
                HeaderCreateUserName = n.STR_Employee_Exchange.CreatedBy.Name,
                HeaderFiscalYear = n.STR_Employee_Exchange.Fiscalyear.fiscalyear,
                ShortHeaderDate = n.STR_Employee_Exchange.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                HeaderNo = n.STR_Employee_Exchange.No,
                HeaderTotal = n.STR_Employee_Exchange.Total,
                //Section = n.STR_Employee_Exchange.Employee.Section.Name,
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
                Employee_ExchangeNO = n.STR_Employee_Exchange.No,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public PaginatedResult<StrEmployeeExchangeDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.StrEmployeeExchangeDetails.Where(n => n.Employee_ExchangeId == HeaderId).Count();
            List<int> fientryD = _context.StrEmployeeExchangeDetails
                .Where(sus => sus.Employee_ExchangeId == HeaderId)
                .Select(sus => sus.Employee_ExchangeId)
                .ToList();
            List<StrEmployeeExchangeDetailsGetVM> Item = _context.StrEmployeeExchangeDetails
                .Where(n => fientryD.Contains(n.Employee_ExchangeId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new StrEmployeeExchangeDetailsGetVM
                {

                    Employee_ExchangeId = n.Employee_ExchangeId,
                    HeaderEmployeeName = n.STR_Employee_Exchange.Employee.Name,
                    DestEmployeeName = n.STR_Employee_Exchange.DestEmployee.Name,
                    HeaderCostCenterName = n.STR_Employee_Exchange.CostCenter.Name,
                    HeaderCreateUserName = n.STR_Employee_Exchange.CreatedBy.Name,
                    HeaderFiscalYear = n.STR_Employee_Exchange.Fiscalyear.fiscalyear,
                    HeaderDate = n.STR_Employee_Exchange.Date,
                    HeaderNo = n.STR_Employee_Exchange.No,
                    HeaderTotal = n.STR_Employee_Exchange.Total,
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
                    Employee_ExchangeNO = n.STR_Employee_Exchange.No,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<StrEmployeeExchangeDetailsGetVM>
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
