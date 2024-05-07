using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class HrDisciplinary : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary





    }
}
