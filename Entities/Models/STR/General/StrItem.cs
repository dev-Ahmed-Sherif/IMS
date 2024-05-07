using Entities.Models.PR;
using Entities.Models.STR.Add;
using Entities.Models.STR.Employee;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.General
{
    public class StrItem : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string No { get; set; }
        [StringLength(10)]
        public string FullCode { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public bool IsActive { get; set; }

        //Navigation foreign

        public int CommodityId { get; set; }
        public virtual StrCommodity STR_Commodity { get; set; }
        public int GradeId { get; set; }
        public virtual StrGrade STR_Grade { get; set; }
        public int PlatoonId { get; set; }
        public virtual StrPlatoon STR_Platoon { get; set; }
        public int GroupId { get; set; }
        public virtual StrGroup STR_Group { get; set; }
        public int UnitId { get; set; }
        public virtual StrUnit STR_Unit { get; set; }

        //Navigation Primary
        public virtual ICollection<StrOpeningStockDetails> STR_Opening_Stock_Details { get; set; }
        public virtual ICollection<StrAddDetails> STR_Add_Details { get; set; }

        public virtual ICollection<StrEmployeeExchangeDetails> STR_Employee_Exchange_Details { get; set; }
        public virtual ICollection<StrWithDrawDetails> STR_Withdraw_Details { get; set; }
        public virtual ICollection<StrEmployeeOpeningCustodyDetails> STR_Employee_Opening_Custody_Details { get; set; }
        public virtual ICollection<StrStockTakingDetails> StrStockTakingDetails { get; set; }
        //------------------------------------------------------------------------//
        // Relation { PrUser => StrItem } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }



    }
}
