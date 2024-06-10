using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProTenderOpeningStatus : EntityBase
    {
        [Required, MaxLength(50)]
        public required string Name { get; set; }
    }
}
