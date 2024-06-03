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
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public virtual ProPurchaseOrderDetails PurchaseOrderDetails { get; set; }
        public virtual ICollection<ProTenderSelection> ProTenderSelections { get; set; }
        [MaxLength(50)]
        public string Item { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }
}
