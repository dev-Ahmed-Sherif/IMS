using Entities.Models.PR;

namespace Entities.Models.PY
{
    public class PyItemGroupDetails : EntityBase
    {

        //---------------------------------------------
        // Relation { PyItem  } +++ { FK => PyItemId } 
        //---------------------------------------------
        public int PyItemId { get; set; }
        public virtual PyItem PyItem { get; set; }
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
