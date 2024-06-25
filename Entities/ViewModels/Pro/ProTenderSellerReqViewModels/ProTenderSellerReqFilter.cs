using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSellerReqViewModels
{
    public class ProTenderSellerReqFilter
    {
        [AllowNull]
        public int? TenderId { get; set; }
        [AllowNull]
        public int? VendorId { get; set; }
        [AllowNull]
        public DateTime? StartSendDate { get; set; }
        [AllowNull]
        public DateTime? EndSendDate { get; set; }
        [AllowNull]
        public int? SendTypeId { get; set; }
    }
}
