using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels
{
    public class ProTenderOpeningDetailsInputVM
    {
        [Required]
        public int QuotationId { get; set; }
        [Required]
        public bool Accepted { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [Required]
        public int TenderOpeningId { get; set; }
    }
}
