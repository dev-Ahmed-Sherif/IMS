using Entities.Models.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    [Index(nameof(Name), IsUnique = true)]
    public class VlStaffStatus : EntityBase
    {
        [StringLength(50)]
        public string Name { get;set; }

    }
}
