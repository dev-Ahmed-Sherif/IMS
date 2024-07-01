using Entities.Models.HR;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderCommitteeViewModels
{
    public class ProTenderCommitteeInputVM : BaseViewModel
    {
        [Required]
        public int StatusId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        //Navigation Properties
        [Required]
        public int TenderId { get; set; }

        public DateTime Date { get; set; }
        public string Code { get; set; }
    }
}
