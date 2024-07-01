using Entities.Models.HR;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderCommitteeMemberViewModels
{
    public class ProTenderCommitteeMemberFilter
    {
        [AllowNull]
        public int? TenderCommitteeId { get; set; }
        [AllowNull]
        public int? RoleId { get; set; }
        [AllowNull]
        public int? EmployeeId { get; set; }
        [AllowNull]
        public string? EmployeeName { get; set; }
    }
}
