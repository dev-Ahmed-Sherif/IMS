using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProVendorAttachments
{
    public class ProVendorAttachmentFilter
    {
        [AllowNull]
        public int? VendorId { get; set; }
        [AllowNull]
        public string? Name { get; set; }
    }
}
