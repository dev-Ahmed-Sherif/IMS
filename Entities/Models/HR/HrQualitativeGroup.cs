using Entities.Models.PR;

namespace Entities.Models.HR
{
    public class HrQualitativeGroup : EntityBase
    {
        public string Name { get; set; }
        public int Code { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }



    }


}
