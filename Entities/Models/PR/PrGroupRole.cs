
namespace Entities.Models.PR
{
    public class PrGroupRole : EntityBase
    {

        //Navigation foreign
        public int GroupId { get; set; }
        public virtual PrGroup PR_Group { get; set; }
        public int RoleId { get; set; }
        public virtual PrRole PR_Role { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanInsert { get; set; }
        public bool CanPrint { get; set; }

        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
