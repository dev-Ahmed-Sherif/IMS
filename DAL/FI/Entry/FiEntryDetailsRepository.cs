using Entities.Models.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Entities.ExtensionMethods.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.Entry
{
    public class FiEntryDetailsRepository
    {
        private AppDbContext _context;
        public FiEntryDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        //-------------------------
        // Add new (FI)EntryDetails
        //-------------------------
        public string Add(FiEntryDetailsGeneralVM entryDetail)
        {
            bool exists = _context.FiEntryDetails.Any(s => s.CheckNo == entryDetail.CheckNo || s.AccountId == entryDetail.AccountId);
            if (exists)
            {
                return " ChechNo of entry already exists.";
            }

            var _item = new FiEntryDetails()
                {
                    Credit = entryDetail.Credit,
                    Debit = entryDetail.Debit,
                    Description = entryDetail.Description,
                    CheckNo = entryDetail.CheckNo,
                    AccountId = entryDetail.AccountId,
                    FiAccountItemId = entryDetail.FiAccountItemId,
                    EntryId = entryDetail.EntryId,
                    CostCenterId = entryDetail.CostCenterId,
                    CreatedByID = entryDetail.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiEntryDetails.Add(_item);
                _context.SaveChanges();
                return _item.Id.ToString();
            
        }
        //-------------------------------------------------------
        // Update (FI)EntryDetails { where id == entryDetail.id } 
        //-------------------------------------------------------
        public string Update(FiEntryDetailsVM entryDetail)
        {
            bool exists = _context.FiEntryDetails.Any(s =>( s.CheckNo == entryDetail.CheckNo || s.AccountId == entryDetail.AccountId)&&s.Id!=entryDetail.Id);
            if (exists)
            {
                return " ChechNo of entry already exists.";
            }

            var _item = _context.FiEntryDetails.Single(n => n.Id == entryDetail.Id);
               
                    _item.Credit = entryDetail.Credit;
                    _item.Debit = entryDetail.Debit;
                    _item.Description = entryDetail.Description;
                    _item.CheckNo = entryDetail.CheckNo;
                    _item.AccountId = entryDetail.AccountId;
                    _item.FiAccountItemId = entryDetail.FiAccountItemId;
                    _item.EntryId = entryDetail.EntryId;
                    _item.CostCenterId = entryDetail.CostCenterId;

                    _item.UpdateByID = entryDetail.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //--------------------------------------------------
        // Dellete (FI)EntryDetails { where id == entryDetailId }
        //--------------------------------------------------
        public string Delete(int entryDetailId)
        {
           
                var _item = _context.FiEntryDetails.Single(n => n.Id == entryDetailId);
              
                    _context.FiEntryDetails.Remove(_item);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //-------------------------------------------------------------------
        // Select * (FI)EntryDetails { with CreateUserName , UpdateUserName  }
        //-------------------------------------------------------------------
        public List<FiEntryDetailsGetVM> GetAll()
            => _context.FiEntryDetails.Select(
                n => new FiEntryDetailsGetVM
                {
                    //Id = n.Id,
                    //Credit = n.Credit,
                    //Debit = n.Debit,
                    //Description = n.Description ?? "",
                    //CheckNo = n.CheckNo ??0,
                    //AccountName = n.Account.Name,
                    //FiAccountItemId = n.FiAccountItemId ??0,
                    //AccountItemName = n.FiAccountItem.Name??"",
                    //EntryId = n.EntryId,
                    //AccountId = n.AccountId,
                    //CostCenterId=n.CostCenterId ??0,
                    //CreateUserName = n.CreatedBy.Name,
                    //UpdateUserName = n.UpdateBy.Name?? ""
                    ///
                    Id = n.Id,
                    Credit = n.Credit,
                    Debit = n.Debit,
                    Description = n.Description ?? "",
                    CheckNo = n.CheckNo ?? 0,
                    CostCenterName = n.CostCenterId != null ? n.CostCenter.Name : "",
                    CostCenterId = n.CostCenterId ?? 0,
                    AccountName = n.Account.Name,
                    FiAccountItemId = n.FiAccountItemId ?? 0,
                    AccountItemName = n.FiAccountItemId != null ? n.FiAccountItem.Name : "",
                    EntryId = n.EntryId,
                    AccountId = n.AccountId,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name ?? "",
                }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiEntryDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.FiEntryDetails.Where(n => n.EntryId == HeaderId).Count();
            List<int> fientryD = _context.FiEntryDetails
                .Where(sus => sus.EntryId == HeaderId)
                .Select(sus => sus.EntryId)
                .ToList();
            List<FiEntryDetailsGetVM> Item = _context.FiEntryDetails
                .Where(n => fientryD.Contains(n.EntryId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => n.ToFiEntryDetailsVM())
                .ToList();

            var paginatedResult = new PaginatedResult<FiEntryDetailsGetVM>
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
        //---------------------------------------------------------------------------------------
        // Select * (FI)EntryDetails where {id = itemId} { with CreateUserName , UpdateUserName } 
        //---------------------------------------------------------------------------------------
        public FiEntryDetailsGetVM GetById(int itemId)
            => _context.FiEntryDetails.Select(
                n => new FiEntryDetailsGetVM
                {
                    Id = n.Id,
                    Credit = n.Credit,
                    Debit = n.Debit,
                    Description = n.Description,
                    CheckNo = n.CheckNo,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == itemId);
        public List<FiEntryDetailsGetVM> Search(searchFiEntry searchModel)
        {
            var query = _context.FiEntry.AsQueryable();
            if (searchModel.JournalId.HasValue)
            {
                query = query.Where(p => p.JournalId == searchModel.JournalId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.FiEntrySourceTypeId.HasValue)
            {
                query = query.Where(p => p.FiEntrySourceTypeId == searchModel.FiEntrySourceTypeId);
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.Journal.FiscalYearId == searchModel.FiscalYearId);
            }
            if (!string.IsNullOrEmpty(searchModel.Description))
            {
                query = query.Where(p => p.Description.Contains(searchModel.Description));
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.Journal.SectionId == searchModel.SectionId.Value);
            }
            if (searchModel.AccountId.HasValue)
            {

                query = from a in _context.FiEntry
                        join b in _context.FiEntryDetails on a.Id equals b.EntryId
                        where b.AccountId == searchModel.AccountId
                        select a;
            }
            var results = query.Select(p => p.Id).ToList();
            List<FiEntryDetailsGetVM> items = new List<FiEntryDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item);
                if (isNotNull != null)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].StartDate = searchModel.StartDate?.ToShortDateString();
                        isNotNull[item2].EndDate = searchModel.EndDate?.ToShortDateString();
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;


        }
        public List<FiEntryDetailsGetVM> EntryStatisticalItem(searchFiEntry searchModel)
        {
            var query = _context.FiEntryDetails.AsQueryable();
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Entry.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Entry.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.Entry.Journal.SectionId == searchModel.SectionId.Value);
            }
            if (searchModel.FiAccountItemId.HasValue)
            {
                query = query.Where(p => p.FiAccountItemId == searchModel.FiAccountItemId.Value);
            }
            var results = query.Select(p => p.Entry.Id).ToList();
            List<FiEntryDetailsGetVM> items = new List<FiEntryDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item);
                if (isNotNull != null)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].StartDate = searchModel.StartDate?.ToShortDateString();
                        isNotNull[item2].EndDate = searchModel.EndDate?.ToShortDateString();
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;


        }
        public List<FiEntryDetailsGetVM> EntryCostCenter(searchFiEntry searchModel)
        {
            var query = _context.FiEntryDetails.AsQueryable();
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Entry.Date.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Entry.Date.Date <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.SectionId.HasValue)
            {
                query = query.Where(p => p.Entry.Journal.SectionId == searchModel.SectionId.Value);
            }
            if (searchModel.CostCenterId.HasValue)
            {
                query = query.Where(p => p.CostCenterId == searchModel.CostCenterId.Value);
            }
            var results = query.Select(p => p.Entry.Id).ToList();
            List<FiEntryDetailsGetVM> items = new List<FiEntryDetailsGetVM>();
            foreach (var item in results)
            {
                var isNotNull = GetByHeader(item);
                if (isNotNull != null)
                    for (var item2 = 0; item2 < isNotNull.Count; item2++)
                    {
                        isNotNull[item2].StartDate = searchModel.StartDate?.ToShortDateString();
                        isNotNull[item2].EndDate = searchModel.EndDate?.ToShortDateString();
                        items.Add(isNotNull[item2]);
                    }
            }
            return items;


        }
        public List<FiEntryDetailsGetVM> GetByHeader(int HeaderId) => _context.FiEntryDetails
                .Where(n => n.EntryId == HeaderId)
                .Select(
                n => new FiEntryDetailsGetVM
                {
                    HeaderJournalNo = n.Entry.Journal.No,
                    HeaderFiscalYear = n.Entry.Journal.FiscalYear.fiscalyear,
                    HeaderEntrySourceTypeName = n.Entry.FiEntrySourceType.Name,
                    HeaderNo = n.Entry.No,
                    HeaderDescription = n.Entry.Description,
                    HeaderDate = n.Entry.Date.ToString("dd/MM/yyyy"),
                    HeaderCreditTotal = n.Entry.CreditTotal,
                    HeaderDebitTotal = n.Entry.DebitTotal,
                    HeaderBalance = n.Entry.Balance,
                    Headerstate = n.Entry.State,
                    //details
                    Id = n.Id,
                    Credit = n.Credit,
                    Debit = n.Debit,
                    Description = n.Description,
                    CheckNo = n.CheckNo,
                    AccountName = n.Account.Name,
                    FiAccountItemId = n.FiAccountItemId,
                    AccountItemName = n.FiAccountItem.Name,
                    CostCenterName = n.CostCenter.Name,
                    EntryId = n.EntryId,
                    AccountId = n.AccountId,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name,
                    Section = n.Entry.Journal.Section.Name,
                }).ToList();
    }

}
