using Entities.Models.HR;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels
{
    public class ProTenderComitteeMemberInput : BaseViewModel
    {
        [Required]
        public int RoleId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        //Navigation Properties
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int TenderCommitteeId { get; set; }
    }
}
