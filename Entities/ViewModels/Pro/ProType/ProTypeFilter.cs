using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProType
{
    public class ProTypeFilter
    {
        [AllowNull]
        public string? Name { get; set; }
    }
}
