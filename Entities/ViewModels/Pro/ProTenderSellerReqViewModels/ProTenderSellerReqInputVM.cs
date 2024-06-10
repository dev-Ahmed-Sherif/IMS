using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSellerReqViewModels
{
    public class ProTenderSellerReqInputVM : BaseViewModel
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        [Required, MaxLength(50)]
        public int SendTypeId { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }

}
