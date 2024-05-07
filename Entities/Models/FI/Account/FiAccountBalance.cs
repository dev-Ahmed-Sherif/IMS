using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.FI.Account
{
    public class FiAccountBalance
    {
        public int Id { get; set; }
        [AllowNull]
        public int? AccountId { get; set; }
        [AllowNull]
        public decimal? Balance { get; set; }
        [AllowNull]
        public int? FiscalYearId { get; set; }
        [AllowNull]
        public virtual FiAccount Account { get; set; }
        public virtual StrFiscalYear FiscalYear { get; set; }
    }
}
