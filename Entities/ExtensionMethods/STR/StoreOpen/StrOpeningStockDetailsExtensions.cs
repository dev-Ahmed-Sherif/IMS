using Entities.Models.STR.StoreOpen;
using Entities.ReportViewModel;
using Entities.ViewModels;
using Entities.ViewModels.STR.StoreOpen;
using System;

namespace Entities.ExtensionMethods.STR.StoreOpen
{
    public static class StrOpeningStockDetailsExtensions
    {
        public static BalanceStoreViewModel ToBalanceStoreViewModel
            (
            this StrOpeningStockDetails model,
            DateTime startDate,
            DateTime endDate,
            QuantityAndTotal AddQuantityAndTotal,
            QuantityAndTotal WithdrawQuantityAndTotal,
            decimal Price
            )
        {
            return new BalanceStoreViewModel
            {
                CommodityId = model.STR_Item.CommodityId,
                CommodityName = model.STR_Item?.STR_Commodity?.Name,
                GradeId = model.STR_Item.STR_Grade.Id,
                GradeName = model.STR_Item.CommodityId == 6 ? model.STR_Item?.STR_Grade?.Name : "",
                StartDate = startDate.ToString("dd/MM/yyyy"),
                EndDate = endDate.ToString("dd/MM/yyyy"),
                ItemCode = model.STR_Item?.FullCode,
                ItemName = model.STR_Item?.Name,
                ItemPrice = Price,
                OpenQty = model.Qty,
                OpenTotalQty = model.Total,
                StoreName = model.STR_Opening_Stock?.STR_Store?.Name,
                StoreId = model.STR_Opening_Stock?.StoreId ?? default,

                AddQty =
                AddQuantityAndTotal.QtyCommoditiesNotFromStore +
                AddQuantityAndTotal.QtyInvestNotFromStore,

                AddTotalQty =
                AddQuantityAndTotal.TotalCommoditiesNotFromStore +
                AddQuantityAndTotal.TotalInvestNotFromStore,

                AddTransQty =
                AddQuantityAndTotal.QtyCommoditiesFromStore +
                AddQuantityAndTotal.QtyInvestFromStore,

                AddTotalTrans =
                AddQuantityAndTotal.TotalCommoditiesFromStore +
                AddQuantityAndTotal.TotalInvestFromStore,

                WithdrawQty =
                WithdrawQuantityAndTotal.QtyCommoditiesNotFromStore +
                WithdrawQuantityAndTotal.QtyInvestNotFromStore,

                WithdrawTotalQty =
                WithdrawQuantityAndTotal.TotalCommoditiesNotFromStore +
                WithdrawQuantityAndTotal.TotalInvestNotFromStore,

                WithdrawTransQty =
                WithdrawQuantityAndTotal.QtyCommoditiesFromStore +
                WithdrawQuantityAndTotal.QtyInvestFromStore,

                WithdrawTotalTrans =
                WithdrawQuantityAndTotal.TotalCommoditiesFromStore +
                WithdrawQuantityAndTotal.TotalInvestFromStore,

                FinalTotal =
                model.Total +
                AddQuantityAndTotal.TotalCommoditiesNotFromStore +
                AddQuantityAndTotal.TotalInvestNotFromStore +
                AddQuantityAndTotal.TotalCommoditiesFromStore +
                AddQuantityAndTotal.TotalInvestFromStore
                 -
                (
                WithdrawQuantityAndTotal.TotalCommoditiesNotFromStore +
                WithdrawQuantityAndTotal.TotalInvestNotFromStore +
                WithdrawQuantityAndTotal.TotalCommoditiesFromStore +
                WithdrawQuantityAndTotal.TotalInvestFromStore
                ),

                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
            };
        }


        public static StrOpeningStockDetailsGetVM ToStrOpeningStockDetailsGetVM(this StrOpeningStockDetails b)
        {
            return new StrOpeningStockDetailsGetVM
            {
                STR_Opening_StockId = b.STR_Opening_StockId,
                HeaderStoreName = b.STR_Opening_Stock?.STR_Store?.Name,
                HeaderCreateUserName = b.STR_Opening_Stock?.CreatedBy?.Name,
                HeaderFiscalYear = b.STR_Opening_Stock?.fiscalyear?.fiscalyear,
                HeaderNo = b.STR_Opening_Stock?.No ?? default,
                HeaderTotal = b.STR_Opening_Stock?.Total ?? default,
                HeaderDate = b.STR_Opening_Stock.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Id = b.Id,
                Qty = b.Qty,
                Price = b.Price,
                Total = b.Total,
                Notes = b.Notes,
                ItemId = b.ItemId,
                ItemName = b.STR_Item?.Name,
                FullCode = b.STR_Item?.FullCode,
                STR_Opening_StockNo = b.STR_Opening_Stock?.No ?? default,
                CreateUserName = b.CreatedBy?.Name
            };
        }
    }
}
