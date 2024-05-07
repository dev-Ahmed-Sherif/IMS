using Entities.Models.FI.Journal;
using Entities.ViewModels.FI.General;
using System;

namespace Entities.ExtensionMethods.FI.General
{
    public static class FiJournalExtensions
    {
        public static FiJournalGetVM ToFiJournalVM(this FiJournal fi)
        {
            FiJournalGetVM Journal = new()
            {
                Id = fi.Id,
                No = fi.No,
                Description = fi.Description,
                TransactionUserId = fi.CreatedBy.Id,
                CreateUserName = fi.CreatedBy.Name,
                FiscalYearId = fi.FiscalYearId,
                FiscalYear = fi.FiscalYear.fiscalyear,
                StartDate = fi.StartDate,
                EndDate = fi.EndDate
            };
            return Journal; 
        }
        public static FiJournalGetVM ToFiJournalVM(this FiJournal fi, DateTime startDate, DateTime endDate)
        {
            FiJournalGetVM viewModel = fi.ToFiJournalVM();
            viewModel.StartDate = startDate;
            viewModel.EndDate = endDate;
            return viewModel;
        }
    }
}
