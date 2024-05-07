
namespace Entities.Models.PR
{
    public class PrUserModule : EntityBase
    {
        //Navigation foreign
        public int UserId { get; set; }
        public virtual PrUser User { get; set; }

        public int ModuleId { get; set; }
        public virtual PrModule Module { get; set; }

        public bool? IsAdmin { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
