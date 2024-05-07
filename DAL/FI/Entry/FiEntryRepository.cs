using Entities.ExtensionMethods;
using Entities.ExtensionMethods.FI.Entry;
using Entities.Models.FI.Entry;
using Entities.ViewModels;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.FI.Entry
{
    public class FiEntryRepository
    {
        private AppDbContext _context;
        public FiEntryRepository(AppDbContext context)
        {
            _context = context;
        }
        //-------------------------
        // Add new (FI)Entry
        //-------------------------
        public int GetLastNo()
        {
            int maxNo = _context.FiEntry.Select(item => item.No).DefaultIfEmpty().Max();
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
        public string Add(FiEntryGeneralVM ID)
        {
            bool exists = _context.FiEntry.Any(s => s.No == ID.No);
            if (exists)
            {
                return " Number of entry already exists.";
            }
            var _Row = new FiEntry()
            {
                No = ID.No,
                Description = ID.Description,
                Date = ID.Date,
                CreditTotal = ID.CreditTotal,
                DebitTotal = ID.DebitTotal,
                Balance = ID.Balance,
                State = ID.State,
                JournalId = ID.JournalId,
                FiEntrySourceTypeId = ID.FiEntrySourceTypeId,

                CreatedByID = ID.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.FiEntry.Add(_Row);
            _context.SaveChanges();
            return _Row.Id.ToString();

        }
        //------------------------------------------
        // Update (FI)Entry { where id == Entry.id } 
        //------------------------------------------
        public string Update(FiEntryVM ID)
        {
            bool exists = _context.FiEntry.Any(s => s.No == ID.No && s.Id != ID.Id);
            if (exists)
            {
                return " Number of entry already exists.";
            }
            var _Row = _context.FiEntry.Single(n => n.Id == ID.Id);

            _Row.No = ID.No;
            _Row.Description = ID.Description;
            _Row.Date = ID.Date;
            _Row.CreditTotal = ID.CreditTotal;
            _Row.DebitTotal = ID.DebitTotal;
            _Row.Balance = ID.Balance;
            _Row.State = ID.State;
            _Row.JournalId = ID.JournalId;
            _Row.FiEntrySourceTypeId = ID.FiEntrySourceTypeId;
            _Row.UpdateByID = ID.TransactionUserId;
            _Row.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";


        }
        //------------------------------------------
        // Dellete (FI)Entry { where id == EntryID }
        //------------------------------------------
        public string Delete(int ID)
        {
            try
            {
                var _Row = _context.FiEntry.FirstOrDefault(n => n.Id == ID);
                if (_Row != null)
                {
                    var DetailsToDelete = _context.FiEntryDetails.Where(p => p.EntryId == ID).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.FiEntryDetails.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.FiEntry.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //-------------------------------------------------------------
        // Select * (FI)Entry { with CreateUserName , UpdateUserName  }
        //-------------------------------------------------------------
        public List<FiEntryGetVM> GetAll(int YearID)
            => _context.FiEntry
            .Where(n => n.Journal.FiscalYearId == YearID)
            .Select
            (n => n.ToFiEntryVM()).ToList();
        //---------------------------------------------------------------------------------
        // Select * (FI)Entry where {id = EntryID} { with CreateUserName , UpdateUserName } 
        //---------------------------------------------------------------------------------
        public async Task<FiEntryGetVM> GetByIdAsync(int ID)
        {
            return (await _context.FiEntry.FindAsync(ID)).ToFiEntryVM();
        }
        public List<FiEntryGetVM> GetLastIndex(int? indexSize)
        {
            int size = 100;
            if (indexSize != null)
                size = (int)indexSize;
            var result = _context.FiEntry
                 .OrderByDescending(on => on.Date)
                 .Take(size)
                 .Select(fi => fi.ToFiEntryVM())
                 .ToList();
            return result;
        }
        public List<FiEntryGetVM> Search(searchFiEntry searchModel)
        {

            var query = _context.FiEntry.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
            if (searchModel.JournalId.HasValue)
            {
                query = query.Where(p => p.JournalId == searchModel.JournalId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.StartDate.Value.Date);
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
            List<FiEntryGetVM> results;
            if (searchModel.StartDate.HasValue)
            {
                results = query.Select(p => p.ToFiEntryVM(searchModel.StartDate.Value, searchModel.EndDate.Value)).ToList();

            }
            else
            {
                results = query.Select(p => p.ToFiEntryVM()).ToList();
            }


            return results;


        }
        public PaginatedResult<FiEntryGetVM> SearchPagination(searchFiEntry searchModel , int page, int pageSize)
        {

            var query = _context.FiEntry.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
            if (searchModel.JournalId.HasValue)
            {
                query = query.Where(p => p.JournalId == searchModel.JournalId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.StartDate.Value.Date);
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
            //var results = query.Select(p => p.ToFiEntryVM(searchModel.StartDate.Value, searchModel.EndDate.Value)).ToList();


            return query.ToPaginatedResult(page, pageSize, e => e.ToFiEntryVM());


        }
        //-----------------------------------------------
        // Select data form entry by page and page size 
        //-----------------------------------------------
        public PaginatedResult<FiEntryGetVM> GetPagination(int page, int pageSize, int YearID)
        {
            var Entries = _context.FiEntry
                .OrderByDescending(Entry => Entry.Date)
                .Where(n => n.Journal.FiscalYearId == YearID);
            return Entries.ToPaginatedResult(page, pageSize, e => e.ToFiEntryVM());
        }
        public void CloseFiscalYear(int FiscalYearId)
        {
            var fiEntries = _context.FiEntry.Where(fi => fi.Journal.FiscalYearId == FiscalYearId);

            fiEntries.SelectMany(fi => fi.Fi_Entry_Details.Select(e => e.AccountId));

        }
    }
}
