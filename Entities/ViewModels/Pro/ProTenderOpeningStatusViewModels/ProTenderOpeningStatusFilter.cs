using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningStatusViewModels
{
    public class ProTenderOpeningStatusFilter
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
