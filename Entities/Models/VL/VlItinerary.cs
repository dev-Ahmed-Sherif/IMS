using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    [Index(nameof(Name), IsUnique = true)]
    public class VlItinerary : EntityBaseNotes
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
