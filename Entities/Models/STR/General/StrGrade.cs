using Entities.Models.FI.Account;
using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    //نوعية2
    public class StrGrade : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }

        //Navigation foreign
        public int CommodityId { get; set; }
        public virtual StrCommodity STR_Commodity { get; set; }
        public int? AccountId { get; set; }
        public virtual FiAccount Account { get; set; }

        //Navigation Primary
        public virtual ICollection<StrPlatoon> STR_Platoon { get; set; }
        public virtual ICollection<StrItem> STR_Item { get; set; }

        //------------------------------------------------------------------------//
        // Relation { PrUser => StrGrade } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
