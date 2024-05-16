using Entities.Models.FI.Entry;
using Entities.ViewModels.FI.Entry;
using System;
namespace Entities.ExtensionMethods.FI.Entry
{
    public static class FiEntryDetailsExtensions
    {
        public static FiEntryDetailsGetVM ToFiEntryDetailsVM(this FiEntryDetails n)
        {
            FiEntryDetailsGetVM EentryDetails = new()
            {
                Id = n.Id,
                Credit = n.Credit,
                Debit = n.Debit,
                Description = n.Description ?? "",
                CheckNo = n.CheckNo?? 0,
                CostCenterName = n.CostCenterId != null ? n.CostCenter.Name : "",
                CostCenterId = n.CostCenterId ?? 0,
                AccountName = n.Account.Name,
                FiAccountItemId = n.FiAccountItemId?? 0,
                AccountItemName = n.FiAccountItemId!=null ? n.FiAccountItem.Name :  "",
                EntryId = n.EntryId,
                AccountId = n.AccountId,
                CreateUserName = n.CreatedBy.Name,
                UpdateUserName = n.UpdateByID!=null?n.UpdateBy.Name:"",
                
                HeaderJournalNo = n.Entry.Journal.No,
                HeaderFiscalYear = n.Entry.Journal.FiscalYear.fiscalyear,
                HeaderEntrySourceTypeName = n.Entry.FiEntrySourceType.Name??"",
                HeaderNo = n.Entry.No,
                HeaderDescription = n.Entry.Description ?? "",
                HeaderDate = n.Entry.Date.ToString("dd/MM/yyyy"),
                HeaderCreditTotal = n.Entry.CreditTotal,
                HeaderDebitTotal = n.Entry.DebitTotal,
                HeaderBalance = n.Entry.Balance,
                Headerstate = n.Entry.State ?? "",
                //Headerstate = n.Entry.State,
            };
            return EentryDetails;

        }
    }
}
