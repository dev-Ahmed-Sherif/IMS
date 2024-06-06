using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Entities.ViewModels.Pro.ProTenderSelectionViewModels
{
    public class ProTenderSelectionFilter
    {
        [AllowNull]
        public int? TenderDetailsId { get; set; }
        [AllowNull]
        public int? QuotationDetailsId { get; set; }
        [AllowNull]
        public bool? TechnicalPass { get; set; }
        [AllowNull]
        public int? TechnicalScore { get; set; }
        [AllowNull]
        public int? FinancialScore { get; set; }
        [AllowNull]
        public int? TotalScore { get; set; }
    }
}
