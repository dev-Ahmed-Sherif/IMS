using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Entities.Constants.FiConstants;
using Entities.Models.FI.Account;
using Entities.Models.FI.Entry;
using Entities.Models.STR.Add;
using Entities.Models.STR.General;
using Entities.ReportViewModels;
using Entities.ViewModels.FI.Account;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Identity.Client;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using Entities.ViewModels;

namespace DAL.FI.Account
{
    public class FiAccountRepository
    {

        private AppDbContext _context;
        private StrFiscalYearRepository _strFiscalRepository;
        private DbSet<FiAccount> _accountsSet;
        private readonly FiNewAccountsCodes _fiAccountsCodes;

        public FiAccountRepository(AppDbContext context, StrFiscalYearRepository strFiscalRepository, IOptionsSnapshot<FiNewAccountsCodes> fiAccountsCodes)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
            _accountsSet = context.FiAccount;
            _fiAccountsCodes = fiAccountsCodes.Value;

        }

        //---------------------
        // Add new (FI)_account
        //---------------------
        public string Add(FiAccountGVM ID)
        {
            bool exists = _context.FiAccount.Any(s => s.Name == ID.Name || s.Code == ID.Code);
            if (exists)
            {
                return " Name or code  already exists.";
            }

            var _Account = new FiAccount()
            {
                Name = ID.Name,
                Code = ID.Code,
                FiAccountHierarchyId = ID.FiAccountHierarchyId,
                CreatedByID = ID.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.FiAccount.Add(_Account);
            _context.SaveChanges();
            return "Succeeded";


        }
        //----------------------------------------------
        // Update (FI)_account { where id == Account.id } 
        //----------------------------------------------
        public string Update(FiAccountVM ID)
        {
            bool exists = _context.FiAccount.Any(s => (s.Name == ID.Name || s.Code == ID.Code) && s.Id != ID.Id);
            if (exists)
            {
                return " Name or code  already exists.";
            }


            var _Row = _context.FiAccount.Single(n => n.Id == ID.Id);

            _Row.Name = ID.Name;
            _Row.Code = ID.Code;
            _Row.FiAccountHierarchyId = ID.FiAccountHierarchyId;
            _Row.UpdateByID = ID.TransactionUserId;
            _Row.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";


        }
        //------------------------------------------------
        // Dellete (FI)_account { where id == Account_id }
        //------------------------------------------------
        public string Delete(int ID)
        {

            var _Account = _context.FiAccount.Single(n => n.Id == ID);
            _context.FiAccount.Remove(_Account);
            _context.SaveChanges();
            return "Succeeded";

        }
        //--------------------------------------------------------------------------------------
        // Select * (FI)_account { with CreateUserName , UpdateUserName , FiAccountHierarchyId }
        //--------------------------------------------------------------------------------------
        public List<FiAccountGetVM> GetAll()
            => _context.FiAccount.Select(
                n => new FiAccountGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FiAccountHierarchyId = n.FiAccountHierarchyId,
                    FiAccountHierarchyName = n.FiAccountHierarchy.Name,
                    FiAccountlevel = n.FiAccountHierarchy.Level,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountGetVM[]> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.FiAccount.Count();

            // Query to retrieve data
            List<FiAccountGetVM> items = _context.FiAccount
                .OrderByDescending(item => item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new FiAccountGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FiAccountHierarchyId = n.FiAccountHierarchyId,
                    FiAccountHierarchyName = n.FiAccountHierarchy.Name,
                    FiAccountlevel = n.FiAccountHierarchy.Level,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                })
                .ToList();

            // Group items by the length of the Code property
            var nestedArray = new FiAccountGetVM[9][];
            for (int i = 0; i < 9; i++)
            {
                nestedArray[i] = items.Where(n => n.Code.Length == i + 1).ToArray();
            }

            var paginatedResult = new PaginatedResult<FiAccountGetVM[]>
            {
                Items = nestedArray.ToList(),
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
        //-------------------------------------------------------------------------------------------------------------
        // Select * (FI)_account where {id = AccountID} { with CreateUserName , UpdateUserName , FiAccountHierarchyId } 
        //-------------------------------------------------------------------------------------------------------------
        public FiAccountGetVM GetById(int ID)

            => _context.FiAccount.Select(
                n => new FiAccountGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FiAccountHierarchyId = n.FiAccountHierarchyId,
                    FiAccountHierarchyName = n.FiAccountHierarchy.Name,
                    FiAccountlevel = n.FiAccountHierarchy.Level,
                    TransactionUserId = n.CreatedBy.Id,
                    CreateUserName = n.CreatedBy.Name,
                    UpdateUserName = n.UpdateBy.Name
                }).Single(n => n.Id == ID);
        //-------------------------------------------------------------------------------------------------------------
        // Select * (FI)_account where {Name = AccountName} {aaath CreateUserName , UpdateUserName , FiAccountHierarchyId } 
        //-------------------------------------------------------------------------------------------------------------
        public List<FiAccountGetVM> GetByName(string accountName)
        {
            return _context.FiAccount
                .Where(n => n.Name.Contains(accountName))
                .Select(n => new FiAccountGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    FiAccountHierarchyId = n.FiAccountHierarchyId,
                    FiAccountHierarchyName = n.FiAccountHierarchy.Name,
                    FiAccountlevel = n.FiAccountHierarchy.Level,
                    CreateUserName = n.CreatedBy.Name

                })
               .ToList();
        }
        public List<AccountItemVM> GetStoreAccountsReportData(DateTime startDate, DateTime endDate, int sectionId)
        {
            List<AccountItemVM> result;

            if (sectionId != 0)
            {

                List<string> section = _context.FiEntry.Where(e => e.Journal.SectionId == sectionId).Select(e => e.Journal.Section.Name).ToList();
                var query = from fiAccount in _context.FiAccount
                            select new AccountItemVM
                            {
                                Id = fiAccount.Id,
                                Code = fiAccount.Code,
                                CodeInt = Int32.Parse(fiAccount.Code),
                                Name = fiAccount.Name,

                                AccountSubNetDebit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                 join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                                 where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiEntryDetails.AccountId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                                 select (fiEntryDetails.Debit)).Sum(), 2),

                                AccountSubNetCredit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                  join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                                  where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiEntryDetails.AccountId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                                  select (fiEntryDetails.Credit)).Sum(), 2),

                                AccountSubNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                            join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                            where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiEntryDetails.AccountId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                            select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                         join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                         from fiEntry in entryGroup.DefaultIfEmpty()
                                                         join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                         from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                         where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiAccountParent.ParentId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                         select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNetCredit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                               join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                               from fiEntry in entryGroup.DefaultIfEmpty()
                                                               join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                               from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                               where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiAccountParent.ParentId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                               select (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNetDebit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                              join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                              from fiEntry in entryGroup.DefaultIfEmpty()
                                                              join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                              from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                              where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiAccountParent.ParentId == fiAccount.Id && fiEntry.Journal.SectionId == sectionId
                                                              select (fiEntryDetails.Debit)).Sum(), 2),


                                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                                StartDate = startDate.ToString("dd/MM/yyyy"),
                                EndDate = endDate.ToString("dd/MM/yyyy"),
                                Section = section.Count != 0 ? section[0] : "",
                            };

                result = query.Select(e => Positive(e)).ToList();
            }
            else
            {
                var query = from fiAccount in _context.FiAccount
                            select new AccountItemVM
                            {
                                Id = fiAccount.Id,
                                Code = fiAccount.Code,
                                CodeInt = Int32.Parse(fiAccount.Code),
                                Name = fiAccount.Name,

                                AccountSubNetDebit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                 join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                                 where fiEntry.Date >= startDate && fiEntry.Date <= endDate
                                                                 && fiEntryDetails.AccountId == fiAccount.Id
                                                                 select (fiEntryDetails.Debit)).Sum(), 2),

                                AccountSubNetCredit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                  join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                                  where fiEntry.Date >= startDate && fiEntry.Date <= endDate
                                                                  && fiEntryDetails.AccountId == fiAccount.Id
                                                                  select (fiEntryDetails.Credit)).Sum(), 2),

                                AccountSubNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                            join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                            where fiEntry.Date >= startDate && fiEntry.Date <= endDate
                                                            && fiEntryDetails.AccountId == fiAccount.Id
                                                            select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                         join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                         from fiEntry in entryGroup.DefaultIfEmpty()
                                                         join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId
                                                         equals fiAccountParent.AccountId into parentGroup
                                                         from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                         where fiEntry.Date >= startDate && fiEntry.Date < endDate
                                                         && fiAccountParent.ParentId == fiAccount.Id
                                                         select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNetCredit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                               join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                               from fiEntry in entryGroup.DefaultIfEmpty()
                                                               join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId
                                                               equals fiAccountParent.AccountId into parentGroup
                                                               from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                               where fiEntry.Date >= startDate && fiEntry.Date < endDate
                                                               && fiAccountParent.ParentId == fiAccount.Id
                                                               select (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNetDebit = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                              join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                              from fiEntry in entryGroup.DefaultIfEmpty()
                                                              join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId
                                                              equals fiAccountParent.AccountId into parentGroup
                                                              from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                              where fiEntry.Date >= startDate && fiEntry.Date < endDate
                                                              && fiAccountParent.ParentId == fiAccount.Id
                                                              select (fiEntryDetails.Debit)).Sum(), 2),


                                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                                StartDate = startDate.ToString("dd/MM/yyyy"),
                                EndDate = endDate.ToString("dd/MM/yyyy"),
                                Section = "",
                            };

                result = query.Select(e => Positive(e)).ToList();
            }

            return result;

        }

        public async Task<List<AccountItemVM>> GetFinancialCenterReportData(int fiscalYearId, string code, int codeLength)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(fiscalYearId);
            DateTime startDate = fiscalYear.StartDate;
            DateTime endDate = fiscalYear.EndDate;
            DateTime prevStartDate = startDate.AddYears(-1);
            DateTime prevEndDate = endDate.AddYears(-1);


            if (codeLength != 0)
            {


                var query = from fiAccount in _context.FiAccount
                            where fiAccount.Code.StartsWith(code) && fiAccount.Code.Length < codeLength
                            select new AccountItemVM
                            {
                                Id = fiAccount.Id,
                                Code = fiAccount.Code,
                                Name = fiAccount.Name,

                                AccountSubNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                            join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                            where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiEntryDetails.AccountId == fiAccount.Id
                                                            select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                AccountNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                         join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                         from fiEntry in entryGroup.DefaultIfEmpty()
                                                         join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                         from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                         where fiEntry.Date >= startDate && fiEntry.Date < endDate && fiAccountParent.ParentId == fiAccount.Id
                                                         select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                PrevAccountSubNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id
                                                                where fiEntry.Date >= prevStartDate && fiEntry.Date < prevEndDate && fiEntryDetails.AccountId == fiAccount.Id
                                                                select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                                PrevAccountNet = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                             join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                             from fiEntry in entryGroup.DefaultIfEmpty()
                                                             join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                             from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                             where fiEntry.Date >= prevStartDate && fiEntry.Date < prevEndDate && fiAccountParent.ParentId == fiAccount.Id
                                                             select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),
                                StartDate = startDate.ToShortDateString(),
                                EndDate = endDate.ToShortDateString(),
                            };

                //var resultList = await query.Select(e => Positive(e)).ToListAsync();
                var resultList = await query.OrderBy(e => e.Code).ToListAsync();
                return resultList;
            }
            else
            {
                var query = from fiAccount in _context.FiAccount
                            join fiEntryDetails in _context.FiEntryDetails
                            on fiAccount.Id equals fiEntryDetails.AccountId into entryDetailsGroup
                            from edg in entryDetailsGroup.DefaultIfEmpty()
                            group new { fiAccount, edg } by new
                            {
                                fiAccount.Id,
                                fiAccount.Code,
                                fiAccount.Name
                            } into g
                            select new AccountItemVM
                            {
                                Id = g.Key.Id,
                                Code = g.Key.Code,
                                Name = g.Key.Name,
                                AccountNet = (
                                    (g.Sum(x => x.edg.Debit) + (
                                        from inDetails in _context.FiEntryDetails
                                        join fa in _context.FiAccount on inDetails.AccountId equals fa.Id
                                        join fap in _context.FiAccountParent on inDetails.AccountId equals fap.AccountId
                                        where fap.ParentId == g.Key.Id && inDetails.IsDeleted != true
                                        select (decimal?)inDetails.Debit).Sum() ?? 0
                                    ) -
                                    (g.Sum(x => x.edg.Credit) + (
                                        from inDetails in _context.FiEntryDetails
                                        join fa in _context.FiAccount on inDetails.AccountId equals fa.Id
                                        join fap in _context.FiAccountParent on inDetails.AccountId equals fap.AccountId
                                        where fap.ParentId == g.Key.Id && inDetails.IsDeleted != true

                                        select (decimal?)inDetails.Credit).Sum() ?? 0
                                    )
                                ),
                                //AccountNet = _context.FiEntryDetails
                                //                    .Where(e => e.CreationDate == startDate && g.Key.Id == e.AccountId)
                                //                    .Select(e => e.Debit - e.Credit).FirstOrDefault() != 0 ||
                                //                    _context.FiEntryDetails
                                //                    .Where(e => g.Key.Id == e.AccountId)
                                //                    .Select(e => e.Debit - e.Credit).FirstOrDefault() != 0 ?
                                //                    _context.FiEntryDetails
                                //                    .Where(e => e.CreationDate == startDate && g.Key.Id == e.AccountId)
                                //                    .Select(e => e.Debit - e.Credit).FirstOrDefault() +
                                //                    _context.FiEntryDetails
                                //                    .Where(e => e.CreationDate != startDate && g.Key.Id == e.AccountId)
                                //                    .Select(e => e.Debit - e.Credit).Sum()
                                //                    :
                                //                       Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                //                                   join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                //                                   from fiEntry in entryGroup.DefaultIfEmpty()
                                //                                   join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                //                                   from fiAccountParent in parentGroup.DefaultIfEmpty()
                                //                                   where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.ParentId == g.Key.Id
                                //                                   && fiEntryDetails.CreationDate == startDate
                                //                                   select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).FirstOrDefault(), 2)
                                //                       +
                                //                      Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                //                        join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                //                        from fiEntry in entryGroup.DefaultIfEmpty()
                                //                        join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                //                        from fiAccountParent in parentGroup.DefaultIfEmpty()
                                //                        where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.ParentId == g.Key.Id
                                //                        && fiEntryDetails.CreationDate != startDate
                                //                        select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2)
                                //                                  ,
                                StartDate = startDate.ToShortDateString(),
                                EndDate = endDate.ToShortDateString(),
                                PrevAccountNet = _context.FiEntryDetails
                                                    .Where(e => e.CreationDate == startDate && g.Key.Id == e.AccountId)
                                                    .Select(e => e.Debit - e.Credit).FirstOrDefault() != 0 ?
                                                    _context.FiEntryDetails
                                                    .Where(e => e.CreationDate == startDate && g.Key.Id == e.AccountId)
                                                    .Select(e => e.Debit - e.Credit).FirstOrDefault()
                                                    : Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                                  join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                                  from fiEntry in entryGroup.DefaultIfEmpty()
                                                                  join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                                  from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                                  where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.ParentId == g.Key.Id
                                                                  && fiEntryDetails.CreationDate == startDate
                                                                  select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),
                            };

                //var resultList = await query.OrderBy(e => e.Code).Select(e => Positive(e)).ToListAsync();
                var resultList = await query.OrderBy(e => e.Code).ToListAsync();
                return resultList;
            }
        }
        private static AccountItemVM Positive(AccountItemVM e)
        {
            e.AccountSubNet = e.AccountSubNet >= 0 ? e.AccountSubNet : e.AccountSubNet * -1;
            e.AccountNet = e.AccountNet >= 0 ? e.AccountNet : e.AccountNet * -1;
            e.PrevAccountSubNet = e.PrevAccountSubNet >= 0 ? e.PrevAccountSubNet : e.PrevAccountSubNet * -1;
            e.PrevAccountNet = e.PrevAccountNet >= 0 ? e.PrevAccountNet : e.PrevAccountNet * -1;
            return e;
        }
        public List<AccountItemByCode> GetAccountMasterReportData(string code, int fiscalYearId)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(fiscalYearId);
            DateTime startDate = fiscalYear.StartDate;
            DateTime endDate = fiscalYear.EndDate;
            var query = from fiEntryDetails in _context.FiEntryDetails
                        join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                        from fiEntry in entryGroup.DefaultIfEmpty()
                        join fiJournal in _context.FiJournal on fiEntry.JournalId equals fiJournal.Id into journalGroup
                        from fiJournal in journalGroup.DefaultIfEmpty()
                        join fiAccount in _context.FiAccount on fiEntryDetails.AccountId equals fiAccount.Id into accountGroup
                        from fiAccount in accountGroup.DefaultIfEmpty()
                        where fiAccount.Code == code && fiEntry.Date >= startDate && fiEntry.Date <= endDate
                        select new AccountItemByCode
                        {
                            Id = fiAccount.Id,
                            Code = fiAccount.Code,
                            Name = fiAccount.Name,
                            Debit = Math.Round(fiEntryDetails.Debit, 2),
                            Credit = Math.Round(fiEntryDetails.Credit, 2),
                            Date = fiEntry.Date.ToString("dd/MM/yyyy"),
                            date = fiEntry.Date,
                            No = fiEntry.No,
                            Description = fiEntry.Description,
                            StartDate = startDate.ToShortDateString(),
                            EndDate = endDate.ToShortDateString(),
                            Section = fiEntry.Journal.Section.Name,
                        };

            var result = query.OrderBy(e => e.date).ToList();
            return result;
        }
        public List<AccountItemWithParent> GetAccountMasterDetailsReportData(string code, int fiscalYearId)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(fiscalYearId);
            DateTime startDate = fiscalYear.StartDate;
            DateTime endDate = fiscalYear.EndDate;
            var query = from fiEntryDetails in _context.FiEntryDetails
                        join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                        from fiEntry in entryGroup.DefaultIfEmpty()
                        join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into accountParentGroup
                        from fiAccountParent in accountParentGroup.DefaultIfEmpty()
                        join fiAccount in _context.FiAccount on fiAccountParent.ParentId equals fiAccount.Id into parentAccountGroup
                        from fiAccount in parentAccountGroup.DefaultIfEmpty()
                        where fiAccount.Code == code && fiEntry.Date >= startDate && fiEntry.Date <= endDate
                        select new AccountItemWithParent
                        {
                            //ParentCode = parentAccount.Code,
                            //ParentName = parentAccount.Name,
                            ParentCode = fiAccount.Code,
                            ParentName = fiAccount.Name,
                            Id = fiAccount.Id,
                            Code = fiAccount.Id == fiAccountParent.ParentId ? fiAccountParent.Account.Code : "",
                            Name = fiAccount.Id == fiAccountParent.ParentId ? fiAccountParent.Account.Name : "",
                            Debit = Math.Round(fiEntryDetails.Debit, 2),
                            Credit = Math.Round(fiEntryDetails.Credit, 2),
                            Date = fiEntry.Date.ToString("dd/MM/yyyy"),
                            date = fiEntry.Date,
                            No = fiEntry.No,
                            Description = fiEntry.Description,
                            StartDate = startDate.ToShortDateString(),
                            EndDate = endDate.ToShortDateString(),
                            Section = fiEntry.Journal.Section.Name,
                        };
            var result = query.OrderBy(e => e.date).ToList();
            return result;
        }

        public List<withdrawToCostCenter> GetWithdrawToCostCenterReportData(int sectionId, DateTime startDate, DateTime endDate)
        {
            var query = (from section in _context.ImsSection
                         join costCenter in _context.CcCostCenter on section.Id equals costCenter.SectionId
                         join entryDetail in _context.FiEntryDetails on costCenter.SectionId equals entryDetail.Entry.Journal.SectionId
                         join account in _context.FiAccount on entryDetail.AccountId equals account.Id
                         join entry in _context.FiEntry on entryDetail.EntryId equals entry.Id
                         where entry.Journal.SectionId == sectionId && entry.Date >= startDate && entry.Date <= endDate &&
                         (
                            account.Code == "311" || account.Code == "3111" || account.Code == "3112" || account.Code == "3113" ||
                            account.Code == "312" || account.Code == "3121" || account.Code == "312101" || account.Code == "3122" || account.Code == "3123" || account.Code == "31231" ||
                            account.Code == "313" || account.Code == "31301" ||
                            account.Code == "34" || account.Code == "341" || account.Code == "342"
                         )
                         orderby account.Code, costCenter.Code
                         select new withdrawToCostCenter
                         {
                             //AccountName = account.Name,
                             AccountCode = account.Code,
                             CostCenterName = costCenter.Name,
                             CostCenterCode = costCenter.Code,
                             Total = entryDetail.Debit - entryDetail.Credit,
                             StartDate = startDate.ToString("dd/MM/yyyy"),
                             EndDate = endDate.ToString("dd/MM/yyyy"),
                             Section = section.Name,
                             SectionId = entry.Journal.SectionId,
                             ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
                         }).ToList();

            return query;
        }
        public async Task<List<FiAccountItemBalancesViewModel>> GetAccountItemsByAccountCodeReportData(string accountCode, int fiscalYearId)
        {
            var fiscalYear = await _context.FiscalYear.FindAsync(fiscalYearId) ??
                throw new KeyNotFoundException("Fiscal Year Id Key Not Found");
            IQueryable<FiAccountItem> accountItemsRelatedToAccount =
             _context
             .FiAccountItem
             .Where(e => e.Code.StartsWith(accountCode))
             .Where(e => e.FiEntryDetails != null &&
                 e.FiEntryDetails
                 .Any(ed => ed.Entry.Journal.FiscalYear.Id == fiscalYearId && ed.IsDeleted != true));

            var list = accountItemsRelatedToAccount.ToList();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    var item = _context.FiEntryDetails.Where(e => list[i].Id == 3417 || list[i].Id == 3423).ToList();
            //    for (int j = 0; j < item.Count; j++)
            //    {
            //        list[i].FiEntryDetails.Add(item[j]);
            //    }
            //}
            //var listWithEntryDetails = list;
            //var query = accountItemsRelatedToAccount.ToQueryString();

            return
                accountItemsRelatedToAccount
                .ToList()
                .Select(InitData)
                .ToList();
        }
        private static FiAccountItemBalancesViewModel InitData(FiAccountItem e)
        {
            //SqlDataReader rdr = (SqlDataReader)e.FiEntryDetails;
            //bool isDeleted = rdr.IsDBNull(e.FiEntryDetails.Select(e => e.IsDeleted).ToString());
            FiEntryDetails beginningEntry = new FiEntryDetails();
            decimal creditWithinPeriod = 0, debitWithinPeriod = 0;
            try
            {
                beginningEntry =
                   e.FiEntryDetails
                   .OrderBy(e => e.Entry.Date)
                   .First();

                creditWithinPeriod =
                   e.FiEntryDetails
                   .Where(e => e.Id != beginningEntry.Id)
                   .Sum(e => e.Credit);

                debitWithinPeriod =
                   e.FiEntryDetails
                    .Where(e => e.Id != beginningEntry.Id)
                   .Sum(e => e.Debit);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {


                    //beginningEntry =
                    //    e.FiEntryDetails
                    //    .Where(ed => ed.FiAccountItemId == e.Id)
                    //    .OrderBy(e => e.Entry.Date)
                    //    .First();

                    //creditWithinPeriod =
                    //    e.FiEntryDetails
                    //    .Where(e => e.Id != beginningEntry.Id)
                    //    .Sum(e => e.Credit);

                    //debitWithinPeriod =
                    //   e.FiEntryDetails
                    //    .Where(e => e.Id != beginningEntry.Id)
                    //   .Sum(e => e.Debit);
                }

            }
            return new FiAccountItemBalancesViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                AccountName = e.Account.Name,
                AccountCode = e.Account.Code,
                BeginningCredit = beginningEntry.Credit,
                BeginningDebit = beginningEntry.Debit,
                WithinPeriodCredit = creditWithinPeriod,
                WithinPeriodDebit = debitWithinPeriod,
                CreditBalance = creditWithinPeriod + beginningEntry.Credit,
                DebitBalance = debitWithinPeriod + beginningEntry.Debit,
            };


        }
        public List<FiChangeInOwnersEquityViewModel> GetChangeInOwnersEquityReportData(int fiscalYearId)
        {
            // Old Tree
            //List<string> ChangeInOwnersEquityAccountsCodes = [AccountsCodes.رأس_المال_المصدر, AccountsCodes.احتياطيات, AccountsCodes.ارباح_أو_خسائر_مرحلة, AccountsCodes.اسهم_الخزينة];

            // New Tree
            List<string> ChangeInOwnersEquityAccountsCodes =
                [
                    _fiAccountsCodes.رأس_المال_المدفوع_21,
                    _fiAccountsCodes.الاحتياطات_23,
                    _fiAccountsCodes.احتياطى_قانونى_231,
                    _fiAccountsCodes.احتياطى_نظامى_232,
                    _fiAccountsCodes.احتياطى_رأسمالى_233,
                    _fiAccountsCodes.احتياطى_أخرى_234,
                    _fiAccountsCodes.الأرباح_أو_الخسائر_المرحلة_24,
                    _fiAccountsCodes.بنود_دخل_شامل_يعاد_تبوبيها_إلى_الأرباح_أو_الخسائر_261,
                    _fiAccountsCodes.بنود_الدخل_الشامل_التى_لا_يعاد_تبوبيها_إلى_الأرباح_أو_الخسائر_262,
                    _fiAccountsCodes.مدفوعات_مبنية_على_أسهم_271,
                    _fiAccountsCodes.مكون_حقوق_الملكية_لأدوات_الدين_القابلة_للتحول_إلى_أسهم_272,
                    _fiAccountsCodes.أسهم_خزينة_مدين_28
                ];

            IQueryable<FiAccount> filteredAccounts = _context.FiAccount.Where(e => ChangeInOwnersEquityAccountsCodes.Contains(e.Code));

            return filteredAccounts.Select(account => GetChangeInOwnersEquityData(account, fiscalYearId)).ToList();
        }
        private static FiChangeInOwnersEquityViewModel GetChangeInOwnersEquityData(FiAccount account, int fiscalYearId)
        {
            var filteredEntryDetails =
                account
                .FiEntryDetails
                .Where(e => e.Entry.Journal.FiscalYearId == fiscalYearId)
                .OrderBy(e => e.Id);

            var firstEntry = filteredEntryDetails.FirstOrDefault();

            FiChangeInOwnersEquityViewModel result = new()
            {
                AccountCode = account.Code,
                AccountName = account.Name,
                BeginningBalance = (firstEntry?.Credit - firstEntry?.Debit) ?? 0,
                ChangeWithinPeriod = filteredEntryDetails.Skip(1).Sum(e => e.Credit - e.Debit),

            };
            result.EndingBalance = result.BeginningBalance + result.ChangeWithinPeriod;
            return result;
        }
        public async Task<FinancialCenterViewModel> GetFinancialCenterData(int fiscalYearId)
        {
            FinancialCenterViewModel result = new()
            {
                //Accounts = Sub & Total Values  : GetAllDataByHierarchy
                FixedAssetsAccounts = await GetFixedAssetsFinancialCenterData(fiscalYearId),
            };

            return result;

        }
        public async Task<List<FixedAssetsFinancialCenterViewModel>> GetFixedAssetsFinancialCenterData(int fiscalYearId)
        {

            //var yearId = _context.FiscalYear.FindAsync(fiscalYearId);
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(fiscalYearId);
            DateTime startDate = fiscalYear.StartDate;
            DateTime endDate = fiscalYear.EndDate;
            DateTime prevStartDate = startDate.AddYears(-1);
            DateTime prevEndDate = endDate.AddYears(-1);


            List<FiAccount> fixedAssetsAccounts =
                await
                _context
                .FiAccount
                .Where(e => e.Code.StartsWith("11") && e.Code.Length == 3)
                .ToListAsync();

            List<FiAccount> fixedAssetsDepreciationAccountsChilds =
                await
                _context
                .FiAccount
                .Where(e => e.Code.StartsWith("261"))
                .OrderBy(e => e.Code)
                .ToListAsync();

            List<string> fixedAssetsDepreciationAccountsCodes =
                fixedAssetsAccounts
                .Select(e => ConvertFixedAssetToFixedAssetDepreciationAccountCode(e.Code))
                .ToList();



            List<FiAccount> fixedAssetsDepreciationAccounts =
                await
                _context
                .FiAccount
                .Where(e => fixedAssetsDepreciationAccountsCodes.Contains(e.Code))
                .ToListAsync();


            //To be continued
            List<FixedAssetsFinancialCenterViewModel> result = new();

            foreach (FiAccount account in fixedAssetsAccounts)
            {
                var DepreciationAccountCode = ConvertFixedAssetToFixedAssetDepreciationAccountCode(account.Code);
                var depit = _context.FiEntryDetails.Where(e => e.CreationDate == startDate && account.Id == e.AccountId).Select(e => e.Debit).FirstOrDefault();
                FixedAssetsFinancialCenterViewModel e = new()
                {
                    AccumulatedDepreciation = Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                                          join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                                          from fiEntry in entryGroup.DefaultIfEmpty()
                                                          join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                                          from fiAccountParent in parentGroup.DefaultIfEmpty()
                                                          where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.Parent.Code == DepreciationAccountCode
                                                          select (fiEntryDetails.Credit) - (fiEntryDetails.Debit)).Sum(), 2),

                    //عايزين تكلفة الاصل الثابت بالكامل هنا
                    // Debit - Credit
                    Cost = (decimal)(account.Code.StartsWith("11") && fixedAssetsAccounts
                            .FirstOrDefault
                            (e => e.Code == account.Code)?
                            .FiEntryDetails
                            .Where(e => e.Entry.Journal.FiscalYearId == fiscalYearId)
                            .Sum(e => e.Debit - e.Credit) != 0 ? fixedAssetsAccounts
                            .FirstOrDefault
                            (e => e.Code == account.Code)?
                            .FiEntryDetails
                            .Where(e => e.Entry.Journal.FiscalYearId == fiscalYearId)
                            .Sum(e => e.Debit - e.Credit) :
                            Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                        join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                        from fiEntry in entryGroup.DefaultIfEmpty()
                                        join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                        from fiAccountParent in parentGroup.DefaultIfEmpty()
                                        where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.ParentId == account.Id
                                        select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2)),

                    PrevFixedAssetNetValue = depit != 0 ? depit
                              : Math.Round((from fiEntryDetails in _context.FiEntryDetails
                                            join fiEntry in _context.FiEntry on fiEntryDetails.EntryId equals fiEntry.Id into entryGroup
                                            from fiEntry in entryGroup.DefaultIfEmpty()
                                            join fiAccountParent in _context.FiAccountParent on fiEntryDetails.AccountId equals fiAccountParent.AccountId into parentGroup
                                            from fiAccountParent in parentGroup.DefaultIfEmpty()
                                            where fiEntry.Journal.FiscalYearId == fiscalYearId && fiAccountParent.ParentId == account.Id
                                            && fiEntryDetails.CreationDate == startDate
                                            select (fiEntryDetails.Debit) - (fiEntryDetails.Credit)).Sum(), 2),

                    Code = account.Code,
                    AccountName = account.Name,
                };

                e.FixedAssetNetValue = e.Cost - e.AccumulatedDepreciation;
                result.Add(e);
            }

            return result;

        }
        private static string ConvertFixedAssetToFixedAssetDepreciationAccountCode(string fixedAssetCode)
        {
            List<char> code = fixedAssetCode.ToList();
            var depreciationAccountCode = code.Skip(1).Prepend('6').Prepend('2');
            var depreciationAccountCodeString = string.Join("", depreciationAccountCode);
            return depreciationAccountCodeString;
        }
        private static string ConvertFixedAssetDepreciationToFixedAssetAccountCode(string fixedAssetDepreciationAccountCode)
        {
            List<char> code = fixedAssetDepreciationAccountCode.ToList();
            var fixedAssetAccountCode = code.Skip(2).Prepend('1');
            var fixedAssetAccountCodeString = string.Join("", fixedAssetAccountCode);
            return fixedAssetAccountCodeString;
        }
        public async Task<List<FiAccountItemBalancesViewModel>> GetTriaBalanceReportData(int fiscalYearId)
        {
            var fiscalYear = await _context.FiscalYear.FindAsync(fiscalYearId) ??
                throw new KeyNotFoundException("Fiscal Year Id Key Not Found");
            IQueryable<FiAccount> fiAccounts =
            _context
            .FiAccount
            .Where(e =>
                e.FiEntryDetails
                .Any(ed => ed.Entry.Journal.FiscalYear.Id == fiscalYearId));

            var list = fiAccounts.ToList();

            var query = fiAccounts.ToQueryString();

            return
                fiAccounts
                .ToList()
                .Select(InitDataTriaBalance)
                .ToList();
        }
        private static FiAccountItemBalancesViewModel InitDataTriaBalance(FiAccount e)
        {
            FiEntryDetails beginningEntry = new FiEntryDetails();
            decimal creditWithinPeriod = 0, debitWithinPeriod = 0;
            try
            {
                beginningEntry =
                   e.FiEntryDetails
                   .OrderBy(e => e.Entry.Date)
                   .First();

                creditWithinPeriod =
                   e.FiEntryDetails
                   .Where(e => e.Id != beginningEntry.Id)
                   .Sum(e => e.Credit);

                debitWithinPeriod =
                   e.FiEntryDetails
                    .Where(e => e.Id != beginningEntry.Id)
                   .Sum(e => e.Debit);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {


                    //beginningEntry =
                    //    e.FiEntryDetails
                    //    .Where(ed => ed.FiAccountItemId == e.Id)
                    //    .OrderBy(e => e.Entry.Date)
                    //    .First();

                    //creditWithinPeriod =
                    //    e.FiEntryDetails
                    //    .Where(e => e.Id != beginningEntry.Id)
                    //    .Sum(e => e.Credit);

                    //debitWithinPeriod =
                    //   e.FiEntryDetails
                    //    .Where(e => e.Id != beginningEntry.Id)
                    //   .Sum(e => e.Debit);
                }

            }
            return new FiAccountItemBalancesViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                AccountName = e.Name,
                AccountCode = e.Code,
                BeginningCredit = beginningEntry.Credit,
                BeginningDebit = beginningEntry.Debit,
                WithinPeriodCredit = creditWithinPeriod,
                WithinPeriodDebit = debitWithinPeriod,
                CreditBalance = creditWithinPeriod + beginningEntry.Credit,
                DebitBalance = debitWithinPeriod + beginningEntry.Debit,
            };

        }
        public FiAccountGetParentVM GetParent(string code)
        {
            var maxLength = code.Length;
            var parentcode = code.Substring(0, maxLength - 1);

            var matchingAccounts = _context.FiAccount
                .Where(fiAccount => fiAccount.Code.StartsWith(parentcode))
                .Select(fiAccount => new FiAccountGetParentVM
                {
                    Code = fiAccount.Code,
                    Id = fiAccount.Id,
                    Name = fiAccount.Name,
                    FiAccountHierarchyId = fiAccount.FiAccountHierarchyId,
                    AccountHierarchyName = fiAccount.FiAccountHierarchy.Name,
                    AccountHierarchyLevel = fiAccount.FiAccountHierarchy.Level


                })
                 .FirstOrDefault();

            return matchingAccounts;
        }
        public async Task<List<FiEntryDetails>?> GetAccountBalances(FiAccountBalancesFilter filter)
        {
            FiAccount? account = await _accountsSet.FirstOrDefaultAsync(e => e.Code == filter.AccountCode);
            if (account == null) return null;
            IEnumerable<FiEntryDetails> details = account.FiEntryDetails;
            if (filter.StartDate.HasValue)
            {
                details = details.Where(e => e.Entry.Date >= filter.StartDate);
            }
            if (filter.EndDate.HasValue)
            {
                details = details.Where(e => e.Entry.Date <= filter.EndDate);
            }
            return details.ToList();

        }
        public async Task<List<Part1ViewModel>> GetPart1ViewData()
        {
            return await _context.Database.SqlQueryRaw<Part1ViewModel>("SELECT * FROM VW_ACC_Balance_Part1").ToListAsync();
        }public async Task<List<Part2ViewModel>> GetPart2ViewData()
        {
            return await _context.Database.SqlQueryRaw<Part2ViewModel>("SELECT * FROM VW_ACC_Balance_Part2").ToListAsync();
        }
    }

}