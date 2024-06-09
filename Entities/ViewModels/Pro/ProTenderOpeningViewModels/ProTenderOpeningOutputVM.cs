using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningViewModels
{
   public class ProTenderOpeningOutputVM:BaseViewModel
    {
        public int SellerId { get; set; }
        public String SellerName { get; set; }
        public int StatusName { get; set; }
       
        public string Notes { get; set; }
 
        public int TenderId { get; set; }

    }
}
