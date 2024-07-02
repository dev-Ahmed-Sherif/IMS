using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels
{
    public class ProTenderOpeningDetailsFilter
    {
        [AllowNull]
        public int? QuotationId { get; set; }
        [AllowNull]
        public bool? Accepted { get; set; }
    }
}
