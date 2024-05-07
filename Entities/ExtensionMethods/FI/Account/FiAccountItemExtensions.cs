//using Entities.Models.FI.Account;
//using Entities.ViewModels.FI.Account;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entities.ExtensionMethods.FI.Account
//{
//    public static class FiAccountItemExtensions
//    {
//        public static AccountItemVM ToAccountItemVM(this FiAccountItem model, DateTime startDate, DateTime endDate)
//        {
//            DateTime prevStartDate = startDate.AddYears(-1);
//            DateTime prevEndDate = endDate.AddYears(-1);

//            return new AccountItemVM
//            {
//                Id = model.Id,
//                Code = model.Account.Code,
//                Name = model.Name,
//                AccountSubNet = Math.Round(model.FiEntryDetails
//            .Where(fiEntryDetails => fiEntryDetails.Entry.Date >= startDate && fiEntryDetails.Entry.Date < endDate && fiEntryDetails.AccountId == model.Id)
//            .Sum(fiEntryDetails => fiEntryDetails.Debit - fiEntryDetails.Credit), 2),

//                AccountNet = Math.Round(model.FiEntryDetails
//            .Where(fiEntryDetails => fiEntryDetails.Entry.Date >= startDate && fiEntryDetails.Entry.Date < endDate && fiEntryDetails.AccountParent.ParentId == model.Id)
//            .Sum(fiEntryDetails => fiEntryDetails.Debit - fiEntryDetails.Credit), 2),

//                PrevAccountSubNet = Math.Round(model.FiEntryDetails
//            .Where(fiEntryDetails => fiEntryDetails.Entry.Date >= prevStartDate && fiEntryDetails.Entry.Date < prevEndDate && fiEntryDetails.AccountId == model.Id)
//            .Sum(fiEntryDetails => fiEntryDetails.Debit - fiEntryDetails.Credit), 2),

//                PrevAccountNet = Math.Round(model.FiEntryDetails
//            .Where(fiEntryDetails => fiEntryDetails.Entry.Date >= prevStartDate && fiEntryDetails.Entry.Date < prevEndDate && fiEntryDetails.AccountParent.ParentId == model.Id)
//            .Sum(fiEntryDetails => fiEntryDetails.Debit - fiEntryDetails.Credit), 2),

//                StartDate = startDate.ToShortDateString(),
//                EndDate = endDate.ToShortDateString(),
//            }
//        }
//    }
//}
