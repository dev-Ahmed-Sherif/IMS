using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningViewModels
{
    public class ProTenderOpeningFilter
    {
        public int? TenderId { get; set; }

        [AllowNull]
        public int? QuotationId { get; set; }
        [AllowNull]
        public int? StatusId { get; set; }
        public DateTime? Date { get; set; }
        public string? Code { get; set; }

    }
}
