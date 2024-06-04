using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderDetailsViewModels
{
    public class ProTenderDetailsFilter
    {
        [AllowNull]
        public int? TenderId { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public double? MinQty { get; set; }
        [AllowNull]
        public double? MaxQty { get; set; }
        [AllowNull]
        public double? MinPrice { get; set; }
        [AllowNull]
        public double? MaxPrice { get; set; }
    }
}
