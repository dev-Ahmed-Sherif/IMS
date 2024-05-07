using Entities.ExtensionMethods;
using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.ViewModels;
using Entities.ExtensionMethods.STR.Employee;
using DAL.Helpers;
using System.Threading.Tasks;
using Entities.Enums;

namespace DAL.STR.Employee
{
    public class StrEmployeeExchangeRepository
    {
        private AppDbContext _context;
        public StrEmployeeExchangeRepository(AppDbContext context)
        {
            _context = context;
        }
        public int GetLastNo()
        {
            int maxNo = _context.StrEmployeeExchange.Select(item => item.No).DefaultIfEmpty().Max();
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
        public async Task<string> Add(StrEmployeeExchangeGeneralVM exch)
        {

            var _exch = new StrEmployeeExchange()
            {
                No = exch.No,
                Date = exch.Date,
                Total = exch.Total,
                Notes = exch.Notes,
                EmployeeId = exch.EmployeeId,
                DestEmployeeId = exch.DestEmployeeId,
                CostCenterId = exch.CostCenterId,
                FiscalYearId = exch.FiscalYearId,
                CreatedByID = exch.TransactionUserId,
                CreationDate = DateTime.Now,
                Attachment = 
                await 
                FileHelper
                .UploadFile
                    (exch.File,
                    FileHelper.GetDirectoryName(DirectoriesEnum.STREmployeeExchange))
            };
            _context.StrEmployeeExchange.Add(_exch);
            _context.SaveChanges();
            return _exch.Id.ToString();

        }
        public async Task<string> Update(StrEmployeeExchangeVM exch)
        {

            var _exch = _context.StrEmployeeExchange.Single(n => n.Id == exch.Id);

            _exch.No = exch.No;
            _exch.Date = exch.Date;
            _exch.Total = exch.Total;
            _exch.Notes = exch.Notes;
            _exch.EmployeeId = exch.EmployeeId;
            _exch.DestEmployeeId = exch.DestEmployeeId;
            _exch.CostCenterId = exch.CostCenterId;
            _exch.FiscalYearId = exch.FiscalYearId;
            _exch.UpdateByID = exch.TransactionUserId;
            _exch.LastUpdateDate = DateTime.Now;
            _exch.Attachment = 
                await 
                FileHelper
                .UploadFile
                    (exch.File,
                    FileHelper.GetDirectoryName(DirectoriesEnum.STREmployeeExchange));
            _context.SaveChanges();
            return "Succeeded";




        }
        public string Delete(int exchId)
        {
            var _exch = _context.StrEmployeeExchange.Single(n => n.Id == exchId);

            var DetailsToDelete = _context.StrEmployeeExchangeDetails.Where(p => p.Employee_ExchangeId == exchId).ToList();
            if (DetailsToDelete != null)
            {
                _context.StrEmployeeExchangeDetails.RemoveRange(DetailsToDelete);
                _context.SaveChanges();
            }



            _context.StrEmployeeExchange.Remove(_exch);
            _context.SaveChanges();
            return "Succeeded";

        }
        public List<StrEmployeeExchangeGetVM> GetAll()
            => _context.StrEmployeeExchange.Select(n => new StrEmployeeExchangeGetVM
            {
                Id = n.Id,
                No = n.No,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                DestEmployeeId = n.DestEmployeeId,
                DestEmployeeName = n.DestEmployee.Name,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                FiscalYearId = n.FiscalYearId,
                fiscalyear = n.Fiscalyear.fiscalyear,
                Date = n.Date,
                Notes = n.Notes,
                Total = n.Total,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public StrEmployeeExchangeGetVM GetById(int exchId) => _context.StrEmployeeExchange.Select(n => new StrEmployeeExchangeGetVM { Id = n.Id, No = n.No, EmployeeId = n.EmployeeId, EmployeeName = n.Employee.Name, DestEmployeeId = n.DestEmployeeId, DestEmployeeName = n.DestEmployee.Name, CostCenterId = n.CostCenterId, CostCenterName = n.CostCenter.Name, FiscalYearId = n.FiscalYearId, fiscalyear = n.Fiscalyear.fiscalyear, Date = n.Date, Notes = n.Notes, Total = n.Total, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == exchId);
        public List<StrEmployeeExchangeGetVM> search(searchemployeeexchange searchModel)
        {
            var query = _context.StrEmployeeExchange.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
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
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
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
                //ItemName = p.STR_Employee_Exchange_Details.FirstOrDefault(e => e.STR_Item.Name),
                Date = p.Date,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                No = p.No,
                Total = p.Total,
                Notes = p.Notes,
                CostCenterId = p.CostCenterId,
                DestEmployeeId = p.DestEmployeeId,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.Name,
                CostCenterName = p.CostCenter.Name,
                CreateUserName = p.CreatedBy.Name,
                DestEmployeeName = p.DestEmployee.Name,
                FiscalYearId = p.FiscalYearId,
                fiscalyear = p.Fiscalyear.fiscalyear,
                TransactionUserId = p.CreatedBy.Id,
                Section = p.Employee.SectionId.HasValue ? p.Employee.Section.Name : "",
                StartDate = searchModel.StartDate.HasValue ? searchModel.StartDate.Value.ToString("dd/MM/yyyy") : "",
                EndDate = searchModel.EndDate.HasValue ? searchModel.EndDate.Value.ToString("dd/MM/yyyy") : ""
            }).ToList();
            return results;
        }

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrEmployeeExchangeGetVM> GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            var Item = _context.StrEmployeeExchange
                .Where(e => e.FiscalYearId == fiscalYearId)
                .OrderByDescending(Item => Item.CreationDate)
                .ToPaginatedResult(page, pageSize, e => e.ToStrEmployeeExchangeGetVM());

            return Item;
        }
    }
}
