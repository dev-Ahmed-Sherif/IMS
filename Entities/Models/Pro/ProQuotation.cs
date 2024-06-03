using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProQuotation : EntityBase
    {
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public int SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual ProSeller Seller { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceiveType { get; set; }
        public DateTime ValidationDate { get; set; }
        [MaxLength(150)]
        public string Notes { get; set; }
        [MaxLength(150)]
        public string Attachment { get; set; }
    }
}
