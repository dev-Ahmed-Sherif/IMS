using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderViewModels
{
    public class ProPurchaseOrderOutputVM : BaseViewModel
    {

        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public DateTime Date { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public string Notes { get; set; }
        public string AttachmentUrl { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? StoreDeliverDate { get; set; }
        public bool Delivered { get; set; }
        public int DeliverDelayInDays { get; set; }
        public HashSet<string> VendorsNames { get; set; }
    }
}
