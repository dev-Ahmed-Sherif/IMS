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
        [AllowNull]
        public int? TenderId { get; set; }
        [AllowNull]
        public int? SellerId { get; set; }
        [AllowNull]
        public int? StatusId { get; set; }
    }
}
