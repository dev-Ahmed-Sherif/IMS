using Entities.Models.STR.StoreOpen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Pro
{
    public class ProPurchaseOrder : EntityBase
    {
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public DateTime Date { get; set; }
        //public int VendorId { get; set; }
        //[ForeignKey(nameof(VendorId))]
        //public virtual ProSeller Vendor { get; set; }
        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual StrStore Store { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}
