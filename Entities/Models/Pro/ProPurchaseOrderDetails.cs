using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProPurchaseOrderDetails : EntityBase
    {
        public int PurchaseOrderId { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual ProPurchaseOrder PurchaseOrder { get; set; }
        public int TenderDetailsId { get; set; }
        [ForeignKey(nameof(TenderDetailsId))]
        public virtual ProTenderDetails TenderDetails { get; set; }
        public int QuotationDetailsId { get; set; }
        [ForeignKey(nameof(QuotationDetailsId))]
        public virtual ProQuotationDetails QuotationDetails { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}
