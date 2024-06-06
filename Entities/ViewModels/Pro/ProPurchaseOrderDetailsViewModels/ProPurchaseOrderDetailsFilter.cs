using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels
{
    public class ProPurchaseOrderDetailsFilter
    {
        [AllowNull]
        public int? PurchaseOrderId { get; set; }
        [AllowNull]
        public int? TenderDetailsId { get; set; }
        [AllowNull]
        public int? QuotationDetailsId { get; set; }
    }
}
