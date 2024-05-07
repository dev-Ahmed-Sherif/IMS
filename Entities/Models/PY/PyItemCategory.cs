using Entities.Models.PR;

namespace Entities.Models.PY
{
    public class PyItemCategory : EntityBase
    {
        public string Name { get; set; }

        //----------------------------------------------------------
        // Relation { PrUser } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
