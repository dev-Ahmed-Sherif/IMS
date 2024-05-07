using Entities.Models.FI.Entry;
using Entities.ViewModels.FI.Entry;
using System;

namespace Entities.ExtensionMethods.FI.Entry
{
    public static class FiEntryExtensions
    {
        public static FiEntryGetVM ToFiEntryVM(this FiEntry n)
        {
            FiEntryGetVM entry = new()
            {
                Id = n.Id,
                No = n.No,
                State = n.State,
                Date = n.Date,
                Balance = n.Balance,
                Description = n.Description,
                CreditTotal = n.CreditTotal,
                DebitTotal = n.DebitTotal,
                JournalId = n.JournalId,
                Journal_Description = n.Journal.Description,
                Journal_StartDate = n.Journal.StartDate,
                Journal_EndDate = n.Journal.EndDate,
                FiEntrySourceTypeId = n.FiEntrySourceTypeId,
                EntrySourceTypeName = n.FiEntrySourceType?.Name,
                JournalNo = n.Journal.No,
                FiscalYear = n.Journal.FiscalYear?.fiscalyear,
                FiscalYearId = n.Journal.FiscalYearId,
                CreateUserName = n.CreatedBy.Name,
                UpdateUserName = n.UpdateBy?.Name,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                TransactionUserId = n.CreatedByID.Value
            };
            return entry;


        }

        public static FiEntryGetVM ToFiEntryVM(this FiEntry n, DateTime startDate, DateTime endDate)
        {
            FiEntryGetVM viewModel = n.ToFiEntryVM();
            viewModel.StartDate = startDate.ToShortDateString();
            viewModel.EndDate = endDate.ToShortDateString();
            viewModel.Section = n.Journal.Section.Name;
            return viewModel;
        }
    }
}
