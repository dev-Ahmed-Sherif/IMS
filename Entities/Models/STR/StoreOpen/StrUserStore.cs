using Entities.Models.PR;

namespace Entities.Models.STR.StoreOpen
{
    public class StrUserStore : EntityBase
    {
        public int UserId { get; set; }
        public virtual PrUser User { get; set; }
        public int StoreId { get; set; }
        public virtual StrStore Store { get; set; }


        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
