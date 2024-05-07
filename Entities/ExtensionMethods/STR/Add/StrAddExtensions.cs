using Entities.Models.STR.Add;
using Entities.ViewModels.STR.AddDetails;

namespace Entities.ExtensionMethods.STR.Add
{
    public static class StrAddExtensions
    {
        public static StrAddGetVM ToStrAddGetVM(this StrAdd n)
        {
            return new StrAddGetVM
            {
                Id = n.Id,
                No = n.No,
                Date = n.Date,
                Total = n.Total,
                EntryNo = n.EntryNo,
                Notes = n.Notes,
                Attachment = n.Attachment,
                SourceStoreId = n.SourceStoreId,
                SourceStoreName = n.SourceStore?.Name,
                StoreId = n.StoreId,
                StoreName = n.STR_Store?.Name,
                SellerId = n.SellerId,
                SellerName = n.Seller?.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee?.Name,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? 1,
                fiscalyear = n.fiscalyear?.fiscalyear,
                FiscalYearId = n.FiscalYearId,
                Type = n.Type,
                ApprovalStatusId = n.ApprovalStatusId,
                ApprovalStatusName = n.ApprovalStatus?.Name,
                withdrawId = n.withdrawId,
                WithDrawNo = n.withdraw?.No,
                AddTypeId = n.AddTypeId,
                AddTypeName = n.AddType?.Name,
                CommodityId = n.CommodityId,
                CommodityName = n.STR_Commodity?.Name
            };
        }
    }
}
