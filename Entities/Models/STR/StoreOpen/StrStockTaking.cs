using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.STR.StoreOpen
{
    public class StrStockTaking : EntityBase
    {

        public int No { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }
        public string Attachment { get; set; }

        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear fiscalyear { get; set; }
        //Navigation forign
        public int StoreId { get; set; }
        public virtual StrStore Store { get; set; }

        //-----------------------------------------------------------------------------//
        // Relation { PrUser => StrStockTaking } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------------//


        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public virtual ICollection<StrStockTakingDetails> StrStockTakingDetails { get; set; }


    }
}
