using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningViewModels
{
    public class ProTenderOpeningOutputVM : BaseViewModel
    {
        public int QuotationId { get; set; }
        public string QuotationVendorId { get; set; }
        public string QuotationVendorName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Notes { get; set; }
        public int TenderId { get; set; }
        public string TenderName { get; set; }

    }
}
