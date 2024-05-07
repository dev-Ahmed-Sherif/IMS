using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PR
{
    public class PrPrivileges : EntityBase
    {
        //prop decimal tab
        [StringLength(50)]
        public string Name { get; set; }




        //--------------------------------------------------------------------------
        // Relation { PrUser => privileges } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<PrGroupPrivileges> PrGroup_Privileges { get; set; }

    }
}
