using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSelectionViewModels
{
    public class ProTenderSelectionInputVM : BaseViewModel
    {
        [Required]
        public int TenderDetailsId { get; set; }
        [Required]
        public int QuotationDetailsId { get; set; }
        [Required]
        public bool TechnicalPass { get; set; }
        [Required]
        public int TechnicalScore { get; set; }
        [Required]
        public int FinancialScore { get; set; }
        [Required]
        public int TotalScore { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}
