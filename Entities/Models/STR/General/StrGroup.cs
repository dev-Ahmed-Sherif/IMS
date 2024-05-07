using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    //مجموعة3
    public class StrGroup : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }

        //Navigation foreign
        public int PlatoonId { get; set; }
        public virtual StrPlatoon STR_Platoon { get; set; }

        //Navigation Primary
        public virtual ICollection<StrItem> STR_Item { get; set; }

        //------------------------------------------------------------------------//
        // Relation { PrUser => StrGroup } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
