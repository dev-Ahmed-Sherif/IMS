using Entities.Models.PR;

namespace Entities.Models.Pro
{
    public class ProContractorTypes : EntityBase
    {
        public int ContractorId { get; set; }
        public virtual ProContractor Contractor { get; set; }
        public int ContractorTypeId { get; set; }
        public virtual ProSupplierType ContractorType { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
