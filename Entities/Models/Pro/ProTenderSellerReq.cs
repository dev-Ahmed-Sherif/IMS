using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderSellerReq : EntityBase
    {
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public int SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual ProSeller Seller { get; set; }
        public DateTime SendDate { get; set; }
        public int SendTypeId { get; set; }
        [ForeignKey(nameof(SendTypeId))]
        public virtual ProTenderSellerReqSendType SendType { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }
}
