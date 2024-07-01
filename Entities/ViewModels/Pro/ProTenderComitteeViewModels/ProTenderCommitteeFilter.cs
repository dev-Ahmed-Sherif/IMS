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
        public int? TenderId { get; set; }
        [AllowNull]
        public bool? Result { get; set; }
        [AllowNull]
        public DateTime? Date { get; set; }
        [AllowNull]
        public string? Code { get; set; }
    }
}
