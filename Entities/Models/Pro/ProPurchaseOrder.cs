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
    public class ProPurchaseOrder : EntityBaseNotes
    {
        public int TenderId { get; set; }
        [ForeignKey(nameof(TenderId))]
        public virtual ProTender Tender { get; set; }
        public DateTime Date { get; set; }
        public int StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual StrStore Store { get; set; }
        public string Attachment { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? StoreDeliverDate { get; set; }
        public bool Delivered { get; set; }
        public int DeliverDelayInDays { get; set; }
        public virtual ICollection<ProPurchaseOrderDetails> Details { get; set; }
    }
}
