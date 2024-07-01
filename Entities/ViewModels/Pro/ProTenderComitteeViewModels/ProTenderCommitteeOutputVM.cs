using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderCommitteeViewModels
{
    public class ProTenderCommitteeOutputVM : BaseViewModel
    {
        public bool Result { get; set; }
        public string Notes { get; set; }

        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
    }
}
