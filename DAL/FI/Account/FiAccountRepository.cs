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

namespace DAL.FI.Account
{
    public class FiAccountRepository
    {

        private AppDbContext _context;
        private StrFiscalYearRepository _strFiscalRepository;

        public FiAccountRepository(AppDbContext context, StrFiscalYearRepository strFiscalRepository)
        {
            _context = context;
            _strFiscalRepository = strFiscalRepository;
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
            bool exists = _context.FiAccount.Any(s => s.Name == ID.Name || s.Code == ID.Code && s.Id != ID.Id);
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
            //var accounToDelete = _context.FiEntryDetails.Where(p => p.AccountId== ID).ToList();

            //_context.FiEntryDetails.RemoveRange(accounToDelete);
            //_context.SaveChanges();



            //var strAddRecords = _context.StrAdd.Where(s => s.CommodityId == ID).ToList();
            //_context.StrAdd.RemoveRange(strAddRecords);

            //var strAddDetailsRecords = _context.StrAddDetails.Where(s => s.AddId ==s.STR_Add.Id).ToList();
            //_context.StrAddDetails.RemoveRange(strAddDetailsRecords);

            //var accounToDeleteCommodity = _context.StrCommodity.Where(p => p.AccountId == ID).ToList();

            //_context.StrCommodity.RemoveRange(accounToDeleteCommodity);
            //_context.SaveChanges();

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
                
                string section =
                        _context
                        .FiEntry
                        .First(e => e.Journal.SectionId == sectionId)
                        .Journal
                        .Section
                        .Name;
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
                                Section = section,
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
        public List<AccountItemVM> GetFinancialCenterReportData(int fiscalYearId, string code, int codeLength)
        {
            FiscalYearGetVM fiscalYear = _strFiscalRepository.GetById(fiscalYearId);
            DateTime startDate = fiscalYear.StartDate;
            DateTime endDate = fiscalYear.EndDate;
            DateTime prevStartDate = startDate.AddYears(-1);
            DateTime prevEndDate = endDate.AddYears(-1);

            if (codeLength != 0)
            {
                
                
                var query = from fiAccount in _context.FiAccount
                            where fiAccount.Code.StartsWith(code) || fiAccount.Code.Length < codeLength
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

                var resultList = query.Select(e => Positive(e)).ToList();
                return resultList;
            }
            else
            {
                var query = from fiAccount in _context.FiAccount
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
                var resultList = query.Select(e => Positive(e)).ToList();
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
        public List<AccountItemByCode> GetAccountMasterReportData(string code,int fiscalYearId)
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
        //public List<AccountItemVM> Search(search searchModel)
        //{
        //    var query = _context.FiAccount.AsQueryable();
        //    if (searchModel.ClassCode.HasValue)
        //    {
        //        query = query.Where(p => p.Code.Length == 1).Where(p => p.Code == searchModel.ClassCode.ToString());
        //    }
        //    if (searchModel.CategoryCode.HasValue)
        //    {
        //        query = query.Where(p => p.Code.Length == 2).Where(p => p.Code == searchModel.CategoryCode.ToString());
        //    }
        //    if (searchModel.SubCategoryCode.HasValue)
        //    {
        //        query = query.Where(p => p.Code.Length == 3).Where(p => p.Code == searchModel.SubCategoryCode.ToString());
        //    }
        //    var results = query.Select(p => new FiAccountGetVM
        //    {
        //        Code = p.Code,
        //    }).ToList();
        //    List<AccountItemVM> items = new List<AccountItemVM>();
        //    foreach (var item in results)
        //    {
        //        var isNotNull = GetByHierarchy(item.Code);
        //        if (isNotNull != null)
        //            for (var item2 = 0; item2 < isNotNull.Count; item2++)
        //            {
        //                items.Add(isNotNull[item2]);
        //            }
        //    }
        //    return items;

        //}
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

            //IQueryable<FiAccountItem> accountItemsRelatedToAccount =
            //_context
            //.FiAccountItem
            //.Where(e => string.Equals(e.Account.Code, accountCode))
            //.Where(e =>
            //    e.FiEntryDetails
            //    .Any(ed => ed.Entry.Journal.FiscalYear.Id == fiscalYearId));

            IQueryable<FiAccountItem> accountItemsRelatedToAccount =
            _context
            .FiAccountItem
            .Where(e => e.Code.StartsWith(accountCode))
            .Where(e =>
                e.FiEntryDetails
                .Any(ed => ed.Entry.Journal.FiscalYear.Id == fiscalYearId));

            var list = accountItemsRelatedToAccount.ToList();

            var query = accountItemsRelatedToAccount.ToQueryString();

            return
                accountItemsRelatedToAccount
                .ToList()
                .Select(InitData)
                .ToList();
        }
        private static FiAccountItemBalancesViewModel InitData(FiAccountItem e)
        {
            if (e.FiEntryDetails.Count != 0)
            {
                FiEntryDetails beginningEntry =
               e.FiEntryDetails
               .OrderBy(e => e.Entry.Date)
               .First();

                decimal creditWithinPeriod =
                    e.FiEntryDetails
                    .Where(e => e.Id != beginningEntry.Id)
                    .Sum(e => e.Credit);

                decimal debitWithinPeriod =
                    e.FiEntryDetails
                     .Where(e => e.Id != beginningEntry.Id)
                    .Sum(e => e.Debit);

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
            else
            {
                return null;
            }
            
        }
        public List<FiChangeInOwnersEquityViewModel> GetChangeInOwnersEquityReportData(int fiscalYearId)
        {
            List<string> ChangeInOwnersEquityAccountsCodes = [AccountsCodes.رأس_المال_المصدر, AccountsCodes.احتياطيات, AccountsCodes.ارباح_أو_خسائر_مرحلة, AccountsCodes.اسهم_الخزينة];

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
                AccountId = account.Id,
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

            List<FiAccount> fixedAssetsAccounts =
                await
                _context
                .FiAccount
                .Where(e => e.Code.StartsWith("11") && e.Code.Length == 3)
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
                FixedAssetsFinancialCenterViewModel e = new()
                {
                    AccumulatedDepreciation =
                     fixedAssetsDepreciationAccounts
                     .FirstOrDefault
                     (e => e.Code == ConvertFixedAssetToFixedAssetDepreciationAccountCode(account.Code))?
                     .FiEntryDetails
                     .Where(e => e.Entry.Journal.FiscalYearId == fiscalYearId)
                     .Sum(e => e.Credit - e.Debit) ?? 0,

                    //عايزين تكلفة الاصل الثابت بالكامل هنا
                    //Cost =,

                    AccountId = account.Id,
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

        public async Task<List<FiAccountItemBalancesViewModel>> TriaBalance(int fiscalYearId)
        {
            List<string> codes =  _context.FiAccount.Select(e=> e.Code).ToList();
            List<FiAccountItemBalancesViewModel> triaBalance = new List<FiAccountItemBalancesViewModel>();
            foreach (var code in codes)
            {

                triaBalance.AddRange(await GetAccountItemsByAccountCodeReportData(code, fiscalYearId));
            }
            return triaBalance;
        }
    }

}