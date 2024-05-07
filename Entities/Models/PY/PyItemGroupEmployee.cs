using Entities.Models.HR;
using Entities.Models.PR;

namespace Entities.Models.PY
{
    public class PyItemGroupEmployee : EntityBase
    {
        //------------------------------------------------------
        // Relation { HrEmployee  } +++ { FK => EmployeeId } 
        //------------------------------------------------------

        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int ItemGroupId { get; set; }
        public virtual PyItemGroup ItemGroup { get; set; }
        //----------------------------------------------------------
        // Relation { PrUser } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
