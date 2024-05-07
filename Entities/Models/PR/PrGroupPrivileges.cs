namespace Entities.Models.PR
{
    public class PrGroupPrivileges : EntityBase
    {
        public int GroupId { get; set; }
        public virtual PrGroup PR_Group { get; set; }
        public int PrivilegesId { get; set; }
        public virtual PrPrivileges Privileges { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => PrGroupPrivileges } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
