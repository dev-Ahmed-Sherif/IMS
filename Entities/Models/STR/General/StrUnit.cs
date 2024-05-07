using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    public class StrUnit : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }
        //Navigation Primary
        public virtual ICollection<StrItem> STR_Item { get; set; }

        //---------------------------------------------------------------------//
        // Relation { PrUser => StrUnit } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
