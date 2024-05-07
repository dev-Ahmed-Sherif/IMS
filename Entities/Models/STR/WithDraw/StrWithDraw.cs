using Entities.Models.Cc;
using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.Add;
using Entities.Models.STR.General;
using Entities.Models.STR.StoreOpen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.WithDraw
{
    public class StrWithDraw : EntityBase
    {

        //public STR_Withdraw()
        //{
        //    CreatedByID=base.CreatedByID;
        //}
        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public int? ApprovalStatusId { get; set; }
        public virtual StrApprovalStatus ApprovalStatus { get; set; }
        public int? DestStoreId { get; set; }
        public virtual StrStore DestStore { get; set; }
        public bool? DestStoreConfirm { get; set; } = false;
        public int DestStoreUserId { get; set; }
        public virtual PrUser DestStoreUser { get; set; }
        [StringLength(50)]
        public string Attachment { get; set; }
        //Navigation foreign
        public int StoreId { get; set; }
        public virtual StrStore STR_Store { get; set; }
        public int? EmployeeId { get; set; }
        public virtual HrEmployee HR_Employee { get; set; }
        public int? CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear Fiscalyear { get; set; }
        public int? CommodityId { get; set; }
        public virtual StrCommodity STR_Commodity { get; set; }
        public int? WithDrawTypeId { get; set; }

        public virtual StrWithDrawType WithDrawType { get; set; }
        public virtual ICollection<StrWithDrawDetails> STR_Withdraw_Details { get; set; }
        // public List<StrAdd> STR_Add{ get; set; }
        //------------------------------------------------------------------------//
        // Relation { PrUser => StrWithDraw } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
