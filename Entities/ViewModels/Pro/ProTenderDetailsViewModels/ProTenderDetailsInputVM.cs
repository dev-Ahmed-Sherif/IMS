using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderDetailsViewModels
{
    public class ProTenderDetailsInputVM
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TenderId { get; set; }
        [Required]
        public decimal Qty { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Total { get; set; }
        [MaxLength(50)]
        public string Notes { get; set; }
    }
}
