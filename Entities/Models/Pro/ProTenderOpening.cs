using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderOpening : EntityBase
    {
        public int VendorId { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual ProTenderOpeningStatus Status { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        [ForeignKey(nameof(VendorId))]
        public virtual ProVendor Vendor { get; set; }
    }
}
