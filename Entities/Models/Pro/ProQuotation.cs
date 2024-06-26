using AutoMapper.Configuration.Annotations;
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
        public int VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public virtual ProSeller Vendor { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int ReceiveTypeId { get; set; }
        [ForeignKey(nameof(ReceiveTypeId))]
        public virtual ProQuotationReceiveType ReceiveType { get; set; }
        public DateTime ValidationDate { get; set; }
        [MaxLength(150)]
        public string Notes { get; set; }
        [Ignore, MaxLength(150)]
        public string Attachment { get; set; }
    }
}
