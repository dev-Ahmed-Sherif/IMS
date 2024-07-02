using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderVendorReqViewModels
{
    public class ProTenderVendorReqInputVM : BaseViewModel
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        [Required]
        public int SendTypeId { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }

}
