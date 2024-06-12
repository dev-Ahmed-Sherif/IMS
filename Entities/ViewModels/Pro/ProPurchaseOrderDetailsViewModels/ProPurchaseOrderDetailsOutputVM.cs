using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels
{
    public class ProPurchaseOrderDetailsOutputVM : BaseViewModel
    {

        public int PurchaseOrderId { get; set; }

        public int TenderDetailsId { get; set; }
        public string TenderDetailsName { get; set; }
        public int QuotationDetailsId { get; set; }
        public decimal QuotationDetailsPrice { get; set; }
        public string Notes { get; set; }
    }
}
