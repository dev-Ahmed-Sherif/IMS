using Entities.Models.PR;
using Entities.Models.TR.General;

namespace Entities.Models.TR.Excuted
{
    public class TrExcutedFinancier : EntityBase
    {
        public int ExcutedId { get; set; }
        public virtual TrExcuted Excuted { get; set; }
        public int FinancierId { get; set; }
        public virtual TrFinancier Financier { get; set; }

        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
