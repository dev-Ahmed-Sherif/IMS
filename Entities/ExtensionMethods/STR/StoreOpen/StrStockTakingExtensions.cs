using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using System;

namespace Entities.ExtensionMethods.STR.StoreOpen
{
    public static class StrStockTakingExtensions
    {
        public static StrStockTakingGetVM ToStrStockTakingGetVM(this StrStockTaking p)
        {
            return new StrStockTakingGetVM
            {
                Id = p.Id,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),
                Date = p.Date,
                No = p.No,
                Total = p.Total,
                Notes = p.Notes,
                Attachment = p.Attachment,
                StoreId = p.StoreId,
                CreateUserName = p.CreatedBy?.Name,
                fiscalyear = p.fiscalyear.fiscalyear,
                StoreName = p.Store.Name,
                Section = p.Store.Section.Name,
                FiscalYearId = p.FiscalYearId,
                TransactionUserId = p.CreatedByID ?? default,
                UpdateUserName = p.UpdateBy?.Name,
            };
        }
        public static StrStockTakingGetVM ToStrStockTakingGetVM(this StrStockTaking p, DateTime startDate, DateTime endDate)
        {
            StrStockTakingGetVM viewModel = p.ToStrStockTakingGetVM();
            viewModel.StartDate = startDate.ToString("dd/MM/yyyy");
            viewModel.EndDate = endDate.ToString("dd/MM/yyyy");
            viewModel.ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
            return viewModel;
        }
    }
}
