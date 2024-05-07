using Entities.Models.FI.Account;
using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    //سلعة 1
    public class StrCommodity : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        public int? AccountId { get; set; }
        public virtual FiAccount Account { get; set; }
        //----------------------------------------------------------------------------//
        // Relation { Commodity ==> Grade,Item } ++ {Navigation Primary ==> CommodityId}
        //----------------------------------------------------------------------------//
        public virtual ICollection<StrGrade> STR_Grade { get; set; }
        public virtual ICollection<StrItem> STR_Item { get; set; }

        //--------------------------------------------------------------------------------//
        // Relation { PrUser => Commodity } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
