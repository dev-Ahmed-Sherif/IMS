using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.Pro;
using Entities.Models.STR.General;
using Entities.Models.STR.StoreOpen;
using Entities.Models.STR.WithDraw;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.STR.Add
{
    public class StrAdd : EntityBase
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public int? EntryNo { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }
        [StringLength(50)]
        public string Attachment { get; set; }
        public string Type { get; set; }

        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //---------------------------------------------------------------------------//
        // Relation Foregin Key { Store,AddType,AddReceipt,Vendor,Employee,FiscalYear }
        //---------------------------------------------------------------------------//
        public int? SourceStoreId { get; set; }
        [ForeignKey("SourceStoreId")]
        public virtual StrStore SourceStore { get; set; }
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual StrStore STR_Store { get; set; }
        public int? withdrawId { get; set; }
        public virtual StrWithDraw withdraw { get; set; }
        public int? VendorId { get; set; }
        public virtual ProVendor Vendor { get; set; }
        public int? EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear fiscalyear { get; set; }
        public int? ApprovalStatusId { get; set; }
        public virtual StrApprovalStatus ApprovalStatus { get; set; }
        public int CommodityId { get; set; }
        public virtual StrCommodity STR_Commodity { get; set; }
        public int? AddTypeId { get; set; }
        public virtual StrAddType AddType { get; set; }

        //---------------------------------------------------------------//
        // Relation { Add => AddDetails } +++ {Navigation Primary => AddId} 
        //---------------------------------------------------------------//
        public virtual ICollection<StrAddDetails> STR_Add_Details { get; set; }


    }
}
