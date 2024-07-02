using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProVendorAttachment : EntityBaseNotes
    {
        public int VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public virtual ProVendor Vendor { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string FileUrl { get; set; }
    }
}
