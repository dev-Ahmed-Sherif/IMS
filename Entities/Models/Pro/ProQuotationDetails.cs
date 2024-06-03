using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProQuotationDetails : EntityBase
    {
        public int QuotationId { get; set; }
        [ForeignKey(nameof(QuotationId))]
        public virtual ProQuotation Quotation { get; set; }
        public int PurchaseOrderDetailsId { get; set; }
        [ForeignKey(nameof(PurchaseOrderDetailsId))]
        public virtual ProPurchaseOrderDetails PurchaseOrderDetails { get; set; }
        public float Price { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [MaxLength(150)]
        public string Attachment { get; set; }
    }
}
