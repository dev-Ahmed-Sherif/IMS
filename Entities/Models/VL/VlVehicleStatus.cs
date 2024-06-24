using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.VL
{
    [Index(nameof(Name), IsUnique = true)] 
    public class VlVehicleStatus : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
