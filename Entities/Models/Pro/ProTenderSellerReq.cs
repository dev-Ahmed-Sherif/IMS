using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderVendorReq : EntityBase
    {
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public int VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public virtual ProSeller Vendor { get; set; }
        public DateTime SendDate { get; set; }
        public int SendTypeId { get; set; }
        [ForeignKey(nameof(SendTypeId))]
        public virtual ProTenderVendorReqSendType SendType { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }
}
