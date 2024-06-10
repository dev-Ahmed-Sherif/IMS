using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderDetailsViewModels
{
    public class ProTenderDetailsOutputVM:BaseViewModel
    {
    
        public int TenderId { get; set; }
        public String TenderName { get; set; }
        public string Item { get; set; }
    
        public string Name { get; set; }
        public decimal Qty { get; set; }

        public decimal Price { get; set; }
 
        public decimal Total { get; set; }
       
        public string Notes { get; set; }
    }
}
