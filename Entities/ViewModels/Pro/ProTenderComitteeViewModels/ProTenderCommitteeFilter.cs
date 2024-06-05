using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderCommitteeViewModels
{
    public class ProTenderCommitteeFilter
    {
        [Required, MaxLength(50)]
        public string Role { get; set; }
        [Required]
        public bool Close { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
        //Navigation Properties
        public int EmployeeId { get; set; }
        public int TenderId { get; set; }
    }
}
