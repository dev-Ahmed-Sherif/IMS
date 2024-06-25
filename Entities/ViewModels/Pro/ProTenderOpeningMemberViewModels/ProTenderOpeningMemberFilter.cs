using Entities.Models.HR;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels
{
    public class ProTenderOpeningMemberFilter
    {
        [AllowNull]
        public int? TenderOpeningId { get; set; }
        [AllowNull]
        public int? RoleId { get; set; }
        [AllowNull]
        public int? EmployeeId { get; set; }
    }
}
