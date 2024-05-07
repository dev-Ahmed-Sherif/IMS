using Entities.Models.SE;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PR
{
    public class PrGroup : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        //Navigation Primary

        public virtual ICollection<PrUserGroup> PR_User_Group { get; set; }
        public virtual ICollection<PrGroupRole> PrGroupRole { get; set; }
        public virtual ICollection<PrGroupPrivileges> PrGroupPrivileges { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
