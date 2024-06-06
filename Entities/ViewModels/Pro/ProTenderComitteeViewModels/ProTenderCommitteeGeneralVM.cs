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
    public class ProTenderCommitteeGeneralVM : BaseViewModel
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool Close { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
        //Navigation Properties
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int TenderId { get; set; }
    }
}
