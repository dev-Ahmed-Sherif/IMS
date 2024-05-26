using Entities.ExtensionMethods;
using Entities.ExtensionMethods.FI.General;
using Entities.Models.FI.Journal;
using Entities.ViewModels.FI.General;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FI.General
{
    public class FiJournalRepository
    {
        private AppDbContext _context;
        public FiJournalRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------------
        // Add new (FI)Journal
        //--------------------
        public string Add(FiJournalGeneralVM ID)
        {
            bool exists = _context.FiJournal.Any(s => s.No == ID.No && s.FiscalYearId == ID.FiscalYearId);
            if (exists)
            {
                return " Number of entry already exists.";
            }
            var _Row = new FiJournal()
                {
                    No = ID.No,
                    Description = ID.Description,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now,
                    StartDate = ID.StartDate,
                    TypeId = ID.TypeId,
                    EndDate = ID.EndDate,
                    FiscalYearId = ID.FiscalYearId,
                };
                _context.FiJournal.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
         
        }
        //-------------------------------------------------------
        // Update (FI)Journal { where id == Journal.id } 
        //-------------------------------------------------------
        public string Update(FiJournalVM ID)
        {
            bool exists = _context.FiJournal.Any(s => s.No == ID.No && s.Id != ID.Id && s.FiscalYearId == ID.FiscalYearId);
            if (exists)
            {
                return " Number of entry already exists.";
            }

            var _Row = _context.FiJournal.Single(n => n.Id == ID.Id);
               
                    _Row.No = ID.No;
                    _Row.Description = ID.Description;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;
                    _Row.StartDate = ID.StartDate;
                    _Row.TypeId = ID.TypeId;
                    _Row.EndDate = ID.EndDate;
                    _Row.FiscalYearId = ID.FiscalYearId;
                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        //------------------------------------------
        // Dellete (FI)Journal { where id == JournalID }
        //------------------------------------------
        public string Delete(int ID)
        {
            try
            {
                // Find the journal entry by ID
                var journalEntry = _context.FiJournal.FirstOrDefault(n => n.Id == ID);

                if (journalEntry == null)
                {
                    // Return a message if no journal entry is found
                    return "Nothing to be deleted";
                }

                // Find all associated entries to delete
                var entriesToDelete = _context.FiEntry.Where(p => p.JournalId == ID).ToList();

                if (entriesToDelete.Any())
                {
                    // Find all related FiEntryDetails to delete
                    var entryIds = entriesToDelete.Select(e => e.Id).ToList();
                    var entryDetailsToDelete = _context.FiEntryDetails.Where(ed => entryIds.Contains(ed.EntryId)).ToList();

                    if (entryDetailsToDelete.Any())
                    {
                        // Remove associated entry details
                        _context.FiEntryDetails.RemoveRange(entryDetailsToDelete);
                    }

                    // Remove associated entries
                    _context.FiEntry.RemoveRange(entriesToDelete);
                }

                // Remove the journal entry
                _context.FiJournal.Remove(journalEntry);

                // Save changes to the database
                _context.SaveChanges();

                // Return success message
                return "Succeeded";
            }
            catch (Exception ex)
            {
                // Return the exception message for debugging purposes
                return ex.ToString();
            }

        }
        //-------------------------------------------------------------------
        // Select * (FI)Journal { with CreateUserName , UpdateUserName  }
        //-------------------------------------------------------------------
        public List<FiJournalGetVM> GetAll(int YearID)

            => _context.FiJournal
             .Where(n => n.FiscalYearId == YearID)
            .Select(
                n => n.ToFiJournalVM()).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiJournalGetVM> GetAllByPagination(int page, int pageSize, int YearID)
        {
            var totalCount = _context.FiJournal.Where(n => n.FiscalYearId == YearID).Count();
            var Item = _context.FiJournal
                .OrderByDescending(Item => Item.CreationDate)
                .Where(n => n.FiscalYearId == YearID);
            return Item.ToPaginatedResult(page, pageSize, e => e.ToFiJournalVM());
        }
        
        //---------------------------------------------------------------------------------------
        // Select * (FI)Journal where {id = JournalId} { with CreateUserName , UpdateUserName } 
        //---------------------------------------------------------------------------------------
        public FiJournalGetVM GetById(int ID)
            => _context.FiJournal.Select(
                n => n.ToFiJournalVM()).Single(n => n.Id == ID);
        //-----------------------------------------------------------------------------------------------
        // Select * Journal where {Description = JournalDescription} { with CreateUserName , TransactionUserId } 
        //-----------------------------------------------------------------------------------------------
        public List<FiJournalGetVM> GetByName(string Description)
        {
            return _context.FiJournal
                .Where(n => n.Description.Contains(Description))
                .Select(n => n.ToFiJournalVM()).ToList();
        }

        public List<FiJournalGetVM> Search(Searchjournal searchModel)
        {

            var query = _context.FiJournal.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
            if (searchModel.FiscalYearId.HasValue)
            {
                query = query.Where(p => p.FiscalYearId == searchModel.FiscalYearId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.StartDate >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.StartDate <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.No.HasValue)
            {
                query = query.Where(p => p.No == searchModel.No);
            }
            if (!string.IsNullOrEmpty(searchModel.Description))
            {
                query = query.Where(p => p.Description.Contains(searchModel.Description));
            }

            //var results = query.Select(n => n.ToFiJournalVM(searchModel.StartDate.Value, searchModel.EndDate.Value)).ToList();

            var results = query.Select(n => n.ToFiJournalVM()).ToList();
            return results;


        }
    }
}
