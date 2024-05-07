
namespace Entities.Models.PR
{
    public class PrUserGroup : EntityBase
    {
        //Navigation foreign
        public int UserId { get; set; }
        public virtual PrUser PrUser { get; set; }

        public int GroupId { get; set; }
        public virtual PrGroup PR_Group { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
