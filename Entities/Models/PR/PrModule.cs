using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PR
{
    public class PrModule : EntityBase
    {
        //prop decimal tab
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}