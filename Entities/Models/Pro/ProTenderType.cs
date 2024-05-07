using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Pro
{
    public class ProTenderType : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //--------------------------
        //Navigation
        //--------------------------------
        public virtual ICollection<ProTender> ProTender { get; set; }
    }
}
