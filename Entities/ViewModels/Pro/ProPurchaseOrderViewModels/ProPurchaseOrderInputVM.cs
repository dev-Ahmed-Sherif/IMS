using Entities.Models.Pro;
using Entities.Models.STR.StoreOpen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.Pro.ProPurchaseOrderViewModels
{
    public class ProPurchaseOrderInputVM
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int StoreId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        public IFormFile Attachment { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? StoreDeliverDate { get; set; }
        public bool Delivered { get; set; }
    }
}
