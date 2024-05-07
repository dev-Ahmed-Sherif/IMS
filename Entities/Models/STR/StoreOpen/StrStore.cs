using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.SE;
using Entities.Models.STR.Add;
using Entities.Models.STR.WithDraw;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.StoreOpen
{
    public class StrStore : EntityBase
    {

        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        //Navigation Primary
        public virtual ICollection<StrOpeningStock> STR_Opening_Stock { get; set; }

        public virtual ICollection<StrAdd> STR_Add { get; set; }
        public virtual ICollection<StrAdd> STR_Add1 { get; set; }
        public virtual ICollection<StrWithDraw> STR_Withdraw { get; set; }
        public virtual ICollection<StrWithDraw> STR_Withdraw2 { get; set; }
        public virtual ICollection<StrUserStore> Str_UserStore { get; set; }

        //-------------------------------------------------------------------//
        // Relation { PrUser => StrStore } +++ {View Model => TransactionUserId} 
        //-------------------------------------------------------------------//
        public int? StorekeeperId { get; set; }
        public virtual HrEmployee Storekeeper { get; set; }
        public int? SectionId { get; set; }
        public virtual ImsSection Section { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
