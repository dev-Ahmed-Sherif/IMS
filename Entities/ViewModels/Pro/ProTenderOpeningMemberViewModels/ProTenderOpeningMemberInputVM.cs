using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels
{
    public class ProTenderOpeningMemberInputVM : BaseViewModel
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [Required]
        public int TenderOpeningId { get; set; }
    }
}
