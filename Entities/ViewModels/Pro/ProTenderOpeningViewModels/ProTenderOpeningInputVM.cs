using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningViewModels
{
    public class ProTenderOpeningInputVM : BaseViewModel
    {
        [Required]
        public int VendorId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [Required]
        public int TenderId { get; set; }
    }
}
