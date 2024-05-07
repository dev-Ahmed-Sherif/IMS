using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using System;

namespace Entities.ExtensionMethods.STR.StoreOpen
{
    public static class StrOpeningStockExtensions
    {
        public static StrOpeningStockGetVM ToStrOpeningStockGetVM(this StrOpeningStock n)
        {
            return new StrOpeningStockGetVM
            {
                Id = n.Id,
                No = n.No,
                StoreId = n.StoreId,
                Date = n.Date,
                Notes = n.Notes,
                fiscalyear = n.fiscalyear?.fiscalyear,
                FiscalYearId = n.FiscalYearId,
                Total = n.Total,
                Attachment= n.Attachment,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? default,
                Section = n.STR_Store.Section.Name,
                storeName = n.STR_Store.Name,
                ShortDate = n.Date.ToShortDateString(),
            };
        }
        public static StrOpeningStockGetVM ToStrOpeningStockGetVM(this StrOpeningStock n, DateTime startDate, DateTime endDate)
        {
            StrOpeningStockGetVM viewModel = n.ToStrOpeningStockGetVM();
            viewModel.StartDate = startDate.ToString("dd/MM/yyyy");
            viewModel.EndDate = endDate.ToString("dd/MM/yyyy");
            return viewModel;
        }
    }
}
