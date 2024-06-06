using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderCommitteeViewModels
{
    public class ProTenderCommitteeFilter
    {
        [AllowNull]
        public int? RoleId { get; set; }
        [AllowNull]
        public bool? Close { get; set; }
        [AllowNull, MaxLength(50)]
        public string Notes { get; set; }
        //Navigation Properties
        [AllowNull]
        public int? EmployeeId { get; set; }
        [AllowNull]
        public int? TenderId { get; set; }
    }
}
