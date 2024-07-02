using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels
{
    public class ProTenderOpeningDetailsOutputVM : BaseViewModel
    {
        public int QuotationId { get; set; }
        public string QuotationVendorId { get; set; }
        public string QuotationVendorName { get; set; }
        public bool Accepted { get; set; }
        public string Notes { get; set; }
        public int TenderOpeningId { get; set; }
        public string TenderOpeningCode{ get; set; }

    }
}
