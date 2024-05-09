using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReportViewModels
{
    public class FiAccountItemBalancesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public string Code { get; set; }
        public string AccountCode { get; set; }
        public decimal BeginningDebit { get; set; }
        public decimal BeginningCredit { get; set; }
        public decimal WithinPeriodDebit { get; set; }
        public decimal WithinPeriodCredit { get; set; }
        public decimal DebitBalance { get; set; }
        public decimal CreditBalance { get; set; }
    }
}
