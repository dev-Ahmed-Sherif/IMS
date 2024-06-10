using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSellerReqViewModels
{
    public class ProTenderSellerReqOutputVM : BaseViewModel
    {
        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public DateTime SendDate { get; set; }
        public string SendType { get; set; }
        public string SendTypeName { get; set; }
        public string Notes { get; set; }
    }
}
