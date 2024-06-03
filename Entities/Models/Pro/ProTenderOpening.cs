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
        public int SellerId { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual ProTenderOpeningStatus Status { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual ProSeller Seller { get; set; }
    }
}
