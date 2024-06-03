using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderSelection : EntityBase
    {
        public int TenderDetailsId { get; set; }
        [ForeignKey(nameof(TenderDetailsId))]
        public virtual ProTenderDetails TenderDetails { get; set; }
        public int QuotationDetailsId { get; set; }
        [ForeignKey(nameof(QuotationDetailsId))]
        public virtual ProQuotationDetails QuotationDetails { get; set; }
        public bool TechnicalPass { get; set; }
        public int TechnicalScore { get; set; }
        public int FinancialScore { get; set; }
        public int TotalScore { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }

    }
}
