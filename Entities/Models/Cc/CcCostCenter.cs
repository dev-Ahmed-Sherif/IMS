using Entities.Models.Fa;
using Entities.Models.FI.Entry;
using Entities.Models.PR;
using Entities.Models.SE;
using Entities.Models.STR.Employee;
using Entities.Models.STR.WithDraw;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Cc
{
    public class CcCostCenter : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public int FunctionId { get; set; }
        public virtual CcFunction Function { get; set; }
        public int SourceId { get; set; }
        public virtual CcSource Source { get; set; }
        public int RegionId { get; set; }
        public virtual CcRegion Region { get; set; }
        public int SubRegionId { get; set; }
        public virtual CcSubRegion SubRegion { get; set; }
        public int PlantId { get; set; }
        public virtual CcPlant Plant { get; set; }
        public int PlantComponentId { get; set; }
        public virtual CcPlantComponent PlantComponent { get; set; }
        public int ActivityId { get; set; }
        public virtual CcActivity Activity { get; set; }
        public int? SectionId { get; set; }
        public virtual ImsSection Section { get; set; }
        public int? CostCenterCategoryId { get; set; }
        public virtual CcCostCenterCategory CostCenterCategory { get; set; }
        // Relation { PrUser => TrExcutedFinancier} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //Navigation
        public virtual ICollection<CcEquipment> CcEquipment { get; set; }//23/10
        public virtual ICollection<CcEntryDetails> CcEntryDetails { get; set; }//24-10
        public virtual ICollection<FaFixedAsset> FaFixedAsset { get; set; }//24-10

        public virtual ICollection<StrEmployeeOpeningCustody> STR_Employee_Opening_Custody { get; set; }

        public virtual ICollection<StrEmployeeExchange> STR_Employee_Exchange { get; set; }

        public virtual ICollection<StrWithDraw> STR_Withdraw { get; set; }
        public virtual ICollection<FiEntryDetails> FiEntryDetails { get; set; }
    }
}
