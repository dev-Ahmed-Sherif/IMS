using Entities.Models.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.STR.Withdraw
{
    public static class StrWithdrawDetailsExtensions
    {
        public static StrWithDrawDetailsGetVM ToStrWithDrawDetailsGetVM(this StrWithDrawDetails model)
        {
            var entity = new StrWithDrawDetailsGetVM();
            entity.Id = model.Id;
            entity.Unit = model.STR_Item.STR_Unit.Name;
            entity.Qty = model.Qty;
            entity.Price = model.Price;
            entity.State = model.State;
            entity.Percentage = model.Percentage;
            entity.Notes = model.Notes;
            entity.Total = model.Total;
            entity.ItemId = model.ItemId;
            entity.ItemName = model.STR_Item.Name;
            entity.FullCode = model.STR_Item.FullCode;
            entity.STR_WithdrawId = model.STR_WithdrawId;
            entity.WithDrawNo = model.STR_Withdraw.No;
            //Add Header
            entity.HeaderStoreName = model.STR_Withdraw.STR_Store.Name;
            entity.HeaderDestinationName = model.STR_Withdraw.CostCenter != null ? model.STR_Withdraw.CostCenter.Name : model.STR_Withdraw.DestStore.Name;
            //HeaderDesstoreName = model.STR_Withdraw.DestStore.Name;
            //HeaderCostCenterName = model.STR_Withdraw.FI_CostCenter.Name;
            entity.HeaderEmployeeName = model.STR_Withdraw.HR_Employee.Name;
            entity.HeaderDesstoreUserName = model.STR_Withdraw.DestStore?.Name;
            entity.HeaderCreateUserName = model.STR_Withdraw.CreatedBy.Name;
            entity.HeaderFiscalYear = model.STR_Withdraw.Fiscalyear.fiscalyear;
            entity.HeaderNo = model.STR_Withdraw.No;
            entity.HeaderTotal = model.STR_Withdraw.Total;
            entity.HeaderDate = model.STR_Withdraw.Date.ToString("dd/MM/yyyy");
            entity.ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");//Details
            entity.CreateUserName = model.CreatedBy.Name;
            entity.TransactionUserId = model.CreatedBy.Id;
            return entity;
        }
    }
}
