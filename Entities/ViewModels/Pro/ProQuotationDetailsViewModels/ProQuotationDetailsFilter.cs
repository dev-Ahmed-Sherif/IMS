using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProQuotationDetailsViewModels
{
    public class ProQuotationDetailsFilter
    {
        [AllowNull]
        public int? QuotationId { get; set; }
        [AllowNull]
        public int? TenderDetailsId { get; set; }
        [AllowNull]
        public decimal? MinPrice { get; set; }
        [AllowNull]
        public decimal? MaxPrice { get; set; }
    }
}
