using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels
{
    public class ProPurchaseOrderDetailsInputVM : BaseViewModel
    {
        [Required]
        public int PurchaseOrderId { get; set; }
        [Required]
        public int TenderDetailsId { get; set; }
        [Required]
        public int QuotationDetailsId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}
