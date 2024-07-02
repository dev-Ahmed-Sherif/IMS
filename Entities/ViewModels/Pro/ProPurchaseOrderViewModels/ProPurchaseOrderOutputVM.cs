using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderViewModels
{
    public class ProPurchaseOrderOutputVM : BaseViewModel
    {

        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public DateTime Date { get; set; }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public string Notes { get; set; }

    }
}
