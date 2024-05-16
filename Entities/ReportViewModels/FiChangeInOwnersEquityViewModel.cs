using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReportViewModels
{
    public class FiChangeInOwnersEquityViewModel
    {
        public int AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal BeginningBalance { get; set; }
        public decimal ChangeWithinPeriod { get; set; }
        public decimal EndingBalance { get; set; }
    }
}
