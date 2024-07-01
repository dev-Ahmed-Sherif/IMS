using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    [Index(nameof(Name), nameof(Code), IsUnique = true)]
    public class ProType : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        public virtual ICollection<ProTender> ProTenders { get; set; }
        public virtual ICollection<ProVendor> ProVendors { get; set; }
    }
}
