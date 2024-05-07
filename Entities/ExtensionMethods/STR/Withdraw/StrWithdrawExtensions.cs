using Entities.Models.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using System.Linq;

namespace Entities.ExtensionMethods.STR.Withdraw
{
    public static class StrWithdrawExtensions
    {
        public static StrWithdrawGetVM ToStrWithdrawGetVM(this StrWithDraw n)
        {
            return new StrWithdrawGetVM
            {
                Id = n.Id,
                Type = n.Type,
                No = n.No,
                Date = n.Date,
                Total = n.Total,
                Notes = n.Notes,
                StoreId = n.StoreId,
                storeName = n.STR_Store?.Name,
                DestStoreId = n.DestStoreId,
                DesstoreName = n.DestStore?.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.HR_Employee?.Name,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter?.Name,
                DestStoreUserId = n.DestStoreUserId,
                DestStoreConfirm = n.DestStoreConfirm,
                CommodityId = n.CommodityId,
                CommodityName = n.STR_Commodity?.Name,
                WithDrawTypeId = n.WithDrawTypeId,
                WithDrawTypeName = n.WithDrawType?.Name,
                Attachment = n.Attachment,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? default,
                fiscalyear = n.Fiscalyear?.fiscalyear,
                FiscalYearId = n.FiscalYearId,
                ApprovalStatusId = n.ApprovalStatusId,
                DesstoreUserName = n.DestStore?.Name,
                ShortDate = n.Date.ToShortDateString(),
                Section = n.STR_Store.Section.Name,
            };
        }
        public static GetWithDrawDetailsByWithDrawDetailsId ToGetWithDrawDetailsByWithDrawDetailsId(this StrWithDraw n)
        {
            return new GetWithDrawDetailsByWithDrawDetailsId
            {
                StrWithdrawGetVM = n.ToStrWithdrawGetVM(),
                StrWithDrawDetailsGetVM = n.STR_Withdraw_Details.Select(e => e.ToStrWithDrawDetailsGetVM()).ToList(),
            };
        }
    }
}
