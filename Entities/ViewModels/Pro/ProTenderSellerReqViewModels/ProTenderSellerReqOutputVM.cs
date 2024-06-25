using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderVendorReqViewModels
{
    public class ProTenderVendorReqOutputVM : BaseViewModel
    {
        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime SendDate { get; set; }
        public int SendTypeId { get; set; }
        public string SendTypeName { get; set; }
        public string Notes { get; set; }
    }
}
