using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReportViewModels
{
    public class FinancialCenterViewModel
    {
        public List<FixedAssetsFinancialCenterViewModel> FixedAssetsAccounts { get; set; }
        public List<FinancialCenterAccountsViewModel> Accounts { get; set; }
    }
    public class FinancialCenterAccountsViewModel
    {
        public decimal SubAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class FixedAssetsFinancialCenterViewModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Cost { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal FixedAssetNetValue { get; set; }
    }
}

