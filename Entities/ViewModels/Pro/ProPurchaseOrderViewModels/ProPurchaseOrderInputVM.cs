using Entities.Models.Pro;
using Entities.Models.STR.StoreOpen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProPurchaseOrderViewModels
{
    public class ProPurchaseOrderInputVM : BaseViewModel
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
    }
}
