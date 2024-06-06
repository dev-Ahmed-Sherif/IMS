using DAL.STR.General;
using Entities.ExtensionMethods;
using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.ViewModels;
using Entities.ExtensionMethods.STR.Employee;
using Entities.ViewModels.STR.General;
using Entities.Helpers;
using Entities.Enums;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DAL.STR.Employee
{
    public class StrEmployeeOpeningCustodyRepository
    {
        private AppDbContext _context;
        public StrFiscalYearRepository _strFiscalRepository;
        public StrEmployeeOpeningCustodyRepository
            (AppDbContext context,
            StrFiscalYearRepository strFiscalRepository)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
        }
        public int GetLastNo()
        {

            try
            {
                int maxNo = _context.StrEmployeeOpeningCustody.Select(item => item.No).DefaultIfEmpty().Max();
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
            catch (Exception)
            {
                int maxNo = 1;
                return maxNo;
            }



        }
        public async Task<string> Add(StrEmployeeOpeningCustodyVM employee_Opening_Custody)
        {
            bool exists = _context.StrEmployeeOpeningCustody.Any(s => s.EmployeeId == employee_Opening_Custody.EmployeeId && s.FiscalYearId == employee_Opening_Custody.FiscalYearId);
            if (exists)
            {
                throw new Exception("employee already exists in this fiscalyear" +
                    ".");
            }

            var _sTR_Employee_Opening_Custody = new StrEmployeeOpeningCustody()
            {
                No = employee_Opening_Custody.No,
                Date = employee_Opening_Custody.Date,
                Total = employee_Opening_Custody.Total,
                Notes = employee_Opening_Custody.Notes,
                EmployeeId = employee_Opening_Custody.EmployeeId,
                CostCenterId = employee_Opening_Custody.CostCenterId,
                FiscalYearId = employee_Opening_Custody.FiscalYearId,
                Attachment =
                await
                FileHelper
                .UploadFile
                    (employee_Opening_Custody.File,
                    FileHelper.GetDirectoryName(DirectoriesEnum.StrEmployeeOpeningCustody)),
                CreatedByID = employee_Opening_Custody.TransactionUserId,
                CreationDate = DateTime.Now

            };
            _context.StrEmployeeOpeningCustody.Add(_sTR_Employee_Opening_Custody);
            _context.SaveChanges();
            return _sTR_Employee_Opening_Custody.Id.ToString();

        }
        public async Task<string> Update(StrEmployeeOpeningCustodyVM STR_Employee_Opening_Custody)
        {
            bool exists = _context.StrEmployeeOpeningCustody.Any(s => s.EmployeeId == STR_Employee_Opening_Custody.EmployeeId && s.FiscalYearId == STR_Employee_Opening_Custody.FiscalYearId && s.Id != STR_Employee_Opening_Custody.Id);
            if (exists)
            {
                throw new Exception("store already exists.");
            }

            var _item = _context.StrEmployeeOpeningCustody.Single(n => n.Id == STR_Employee_Opening_Custody.Id);

            _item.No = STR_Employee_Opening_Custody.No;
            _item.Date = STR_Employee_Opening_Custody.Date;
            _item.Total = STR_Employee_Opening_Custody.Total;
            _item.Notes = STR_Employee_Opening_Custody.Notes;
            _item.EmployeeId = STR_Employee_Opening_Custody.EmployeeId;
            _item.CostCenterId = STR_Employee_Opening_Custody.CostCenterId;
            _item.FiscalYearId = STR_Employee_Opening_Custody.FiscalYearId;
            _item.Attachment =
                await
                FileHelper
                .UploadFile
                    (STR_Employee_Opening_Custody.File,
                    FileHelper.GetDirectoryName(DirectoriesEnum.StrEmployeeOpeningCustody));
            _item.UpdateByID = STR_Employee_Opening_Custody.TransactionUserId;
            _item.LastUpdateDate = DateTime.Now;
            _context.SaveChanges();
            return "Succeeded";


        }
        public string Delete(int itemId)
        {

            var _item = _context.StrEmployeeOpeningCustody.Single(n => n.Id == itemId);

            var DetailsToDelete = _context.StrEmployeeOpeningCustodyDetails.Where(p => p.CustodyId == itemId).ToList();
            if (DetailsToDelete != null)
            {
                _context.StrEmployeeOpeningCustodyDetails.RemoveRange(DetailsToDelete);
                _context.SaveChanges();
            }
            _context.StrEmployeeOpeningCustody.Remove(_item);
            _context.SaveChanges();
            return "Succeeded";

        }
        public List<StrEmployeeOpeningCustodyGetVM> GetAll() => _context.StrEmployeeOpeningCustody.Select(n => new StrEmployeeOpeningCustodyGetVM
        {
            Id = n.Id,
            No = n.No,
            Date = n.Date,
            Total = n.Total,
            Notes = n.Notes,
            EmployeeId = n.EmployeeId,
            EmployeeName = n.HR_Employee.Name,
            CostCenterName = n.CostCenter.Name,
            CostCenterId = n.CostCenterId,
            CreateUserName = n.CreatedBy.Name,
            FiscalYearId = n.FiscalYearId,
            fiscalyear = n.Fiscalyear.fiscalyear,
            TransactionUserId = n.CreatedBy.Id
        }).ToList();
        public StrEmployeeOpeningCustodyGetVM GetById(int itemId) => _context.StrEmployeeOpeningCustody.Select(n => new StrEmployeeOpeningCustodyGetVM { Id = n.Id, No = n.No, Date = n.Date, Total = n.Total, Notes = n.Notes, EmployeeId = n.EmployeeId, EmployeeName = n.HR_Employee.Name, CostCenterId = n.CostCenterId, CostCenterName = n.CostCenter.Name, CreateUserName = n.CreatedBy.Name, FiscalYearId = n.FiscalYearId, fiscalyear = n.Fiscalyear.fiscalyear, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        public List<StrEmployeeOpeningCustodyGetVM> search(searchemployeeopeningcustody searchModel)
        {

            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById((int)searchModel.FiscalYearId);

            string startDate, endDate;
            startDate = fiscalYear.StartDate.ToString("dd/MM/yyyy");
            endDate = fiscalYear.EndDate.ToString("dd/MM/yyyy");


            var query = _context.StrEmployeeOpeningCustody.AsQueryable();
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
                Date = p.Date,
                No = p.No,
                Total = p.Total,
                Notes = p.Notes,
                CostCenterId = p.CostCenterId,
                fiscalyear = p.Fiscalyear.fiscalyear,
                TransactionUserId = p.CreatedBy.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.HR_Employee.Name,
                CostCenterName = p.CostCenter.Name,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                StartDate = startDate != null ? startDate : "",
                EndDate = endDate != null ? endDate : "",
                FiscalYearId = p.FiscalYearId,
                CreateUserName = p.CreatedByID.HasValue ? p.CreatedBy.Name : "",
                Id = p.Id,
                Section = p.HR_Employee.SectionId.HasValue ? p.HR_Employee.Section.Name : "",
            }).ToList();


            return results;


        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<StrEmployeeOpeningCustodyGetVM> GetAllByPagination
            (int page, int pageSize, int fiscalYearId)
        {
            var Items =
                _context
                .StrEmployeeOpeningCustody
                .Where(e => e.FiscalYearId == fiscalYearId)
                .OrderByDescending(Item => Item.CreationDate)
                .ToPaginatedResult(page, pageSize, e => e.ToStrEmployeeOpeningCustodyGetVM());
            return Items;
        }
    }
}
