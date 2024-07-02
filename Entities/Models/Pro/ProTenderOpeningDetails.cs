using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderOpeningDetails : EntityBaseNotes
    {
        public int QuotationId { get; set; }
        [ForeignKey(nameof(QuotationId))]
        public virtual ProQuotation Quotation { get; set; }
        public int TenderOpeningId { get; set; }
        [ForeignKey(nameof(TenderOpeningId))]
        public virtual ProTenderOpening TenderOpening { get; set; }
        public bool Accepted { get; set; }
    }
}
