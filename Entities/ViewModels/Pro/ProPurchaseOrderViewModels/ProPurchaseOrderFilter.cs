using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderViewModels
{
    public class ProPurchaseOrderFilter
    {
        [AllowNull]
        public int? TenderId { get; set; }
        [AllowNull]
        public DateTime? StartDate { get; set; }
        [AllowNull]
        public DateTime? EndDate { get; set; }
        [AllowNull]
        public int? SellerId { get; set; }
        [AllowNull]
        public int? StoreId { get; set; }
    }
}
