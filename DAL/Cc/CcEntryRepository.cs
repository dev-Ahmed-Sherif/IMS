using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcEntryRepository
    {
        private AppDbContext _context;
        public CcEntryRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------
        //add function
        //----------------
        public string Add(CcEntryGeneralVM Add)
        {
            try
            {
                var _Add = new CcEntry()
                {
                    No = Add.No,
                    Description = Add.Description,
                    Date = Add.Date,
                    CreditTotal = Add.CreditTotal,
                    DebitTotal = Add.DebitTotal,
                    Balance = Add.Balance,
                    FiscalYearId = Add.FiscalYearId,
                    JournalId = Add.JournalId,
                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcEntry.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
            }

            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //-------------------
        //update function
        //-------------------
        public string Update(CcEntryVM update)
        {
            
                var _update = _context.CcEntry.Single(n => n.Id == update.Id);
               
                    _update.No = update.No;
                    _update.Description = update.Description;
                    _update.Date = update.Date;
                    _update.CreditTotal = update.CreditTotal;
                    _update.DebitTotal = update.DebitTotal;
                    _update.Balance = update.Balance;
                    _update.FiscalYearId = update.FiscalYearId;
                    _update.JournalId = update.JournalId;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        //-------------------
        //delet function
        //-------------------

        public string Delete(int EntryId)
        {
            try
            {
                var _Row = _context.CcEntry.FirstOrDefault(n => n.Id == EntryId);
                if (_Row != null)
                {
                    var DetailsToDelete = _context.CcEntryDetails.Where(p => p.EntryId == EntryId).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.CcEntryDetails.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.CcEntry.Remove(_Row);
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

            //var _dele = _context.CcEntry.Single(n => n.Id == EntryId);

            //    _context.CcEntry.Remove(_dele);
            //    _context.SaveChanges();
            //    return "Succeeded";

        }
        //----------------
        //get function
        //-----------------
        public List<CcEntryGetVM> GetAll()
            => _context.CcEntry.Select(n => new CcEntryGetVM
            {
                Id = n.Id,
                No = n.No,
                Description = n.Description,
                Date = n.Date,
                CreditTotal = n.CreditTotal,
                DebitTotal = n.DebitTotal,
                Balance = n.Balance,
                FiscalYearId = n.FiscalYearId,
                JournalId = n.JournalId,
                JournalName = n.Journal.Description,
                JournalStartDate=n.Journal.StartDate,
                JournalEndDate = n.Journal.EndDate,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public CcEntryGetVM GetById(int itemId)
            => _context.CcEntry.Select(n => new CcEntryGetVM
            {
                Id = n.Id,
                No = n.No,
                Description = n.Description,
                Date = n.Date,
                CreditTotal = n.CreditTotal,
                DebitTotal = n.DebitTotal,
                Balance = n.Balance,
                FiscalYearId = n.FiscalYearId,
                JournalId = n.JournalId,
                JournalName = n.Journal.Description,
                JournalStartDate = n.Journal.StartDate,
                JournalEndDate = n.Journal.EndDate,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == itemId);

        public List<CcEntryGetVM> Search(searcccentry searchModel)
        {
            var query = _context.CcEntry.AsQueryable();
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.JournalId.HasValue)
            {
                query = query.Where(p => p.JournalId == searchModel.JournalId);
            }
            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date.Date <= searchModel.Date.Value.Date);
            }
            var results = query.Select(p => new CcEntryGetVM
            {
                Id = p.Id,
               Date = p.Date,
               // ShortDate = p.Date.ToString("dd/MM/yyyy"),
               // StartDate = searchModel.StartDate.HasValue ? searchModel.StartDate.Value.ToString("dd/MM/yyyy") : "",
              //  EndDate = searchModel.EndDate.HasValue ? searchModel.EndDate.Value.ToString("dd/MM/yyyy") : "",
              //  ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                No = p.No,
                JournalId =p.JournalId,
                JournalEndDate=p.Journal.EndDate,
                JournalStartDate=p.Journal.StartDate,
                JournalName=p.Journal.Description,
                FiscalYearId=p.FiscalYearId,
                Description=p.Description,
                CreditTotal=p.CreditTotal,
                DebitTotal=p.DebitTotal,
                Balance=p.Balance,
              //  Date= p.Date.ToString("dd/MM/yyyy"),
             
            }).OrderBy(x => x.Date).ThenBy(x => x.Id).ToList();


            return results;

        }
            //----------------------------------------------------------
            // GET Pagenation { Data with ( page , pagesize )} 
            //----------------------------------------------------------
            public PaginatedResult<CcEntryGetVM> GetAllByPagination(int page, int pageSize , int YearId)
        {
            var totalCount = _context.CcEntry.Count();
            List<CcEntryGetVM> Item = _context.CcEntry
                .Where(n=> n.Journal.FiscalYearId == YearId)
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcEntryGetVM
                {
                    Id = n.Id,
                    No = n.No,
                    Description = n.Description,
                    Date = n.Date,
                    CreditTotal = n.CreditTotal,
                    DebitTotal = n.DebitTotal,
                    Balance = n.Balance,
                    FiscalYearId = n.FiscalYearId,
                    JournalId = n.JournalId,
                    JournalName = n.Journal.Description,
                    JournalStartDate = n.Journal.StartDate,
                    JournalEndDate = n.Journal.EndDate,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcEntryGetVM>
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
