using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderDetails : EntityBase
    {
        public int TenderOpeningId { get; set; }
        [ForeignKey(nameof(TenderOpeningId))]
        public virtual ProTenderOpening TenderOpening { get; set; }
        public virtual ProPurchaseOrderDetails PurchaseOrderDetails { get; set; }
        public virtual ICollection<ProTenderSelection> ProTenderSelections { get; set; }
        public virtual ICollection<ProQuotationDetails> ProQuotationDetails { get; set; }
        [Required, MaxLength(50)]
        public required string Name { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }
}
