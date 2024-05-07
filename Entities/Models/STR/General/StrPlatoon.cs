using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    //فصيلة4
    public class StrPlatoon : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }

        //Navigation foreign
        public int GradeId { get; set; }
        public virtual StrGrade STR_Grade { get; set; }
        //Navigation Primary
        public virtual ICollection<StrGroup> STR_Groups { get; set; }
        public virtual ICollection<StrItem> STR_Items { get; set; }

        //------------------------------------------------------------------------//
        // Relation { PrUser => StrPlatoon } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        //public int StorekeeperId { get; set; }
        //public PrUser Storekeeper { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
