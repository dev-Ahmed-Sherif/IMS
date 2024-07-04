using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSelectionViewModels
{
    public class ProTenderSelectionOutputVM : BaseViewModel
    {
        public int TenderCommitteeId { get; set; }
        public int TenderDetailsId { get; set; }
        public string TenderDetailsName { get; set; }
        public int QuotationDetailsId { get; set; }
        public decimal QuotationDetailsPrice { get; set; }

        public bool TechnicalPass { get; set; }

        public int TechnicalScore { get; set; }

        public int FinancialScore { get; set; }

        public int TotalScore { get; set; }

        public string Notes { get; set; }
    }
}
