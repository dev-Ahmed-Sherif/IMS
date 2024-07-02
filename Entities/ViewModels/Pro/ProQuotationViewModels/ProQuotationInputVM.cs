using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.Pro.ProQuotationViewModels
{
    public class ProQuotationInputVM
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public DateTime ReceiveDate { get; set; }
        [Required]
        public int ReceiveTypeId { get; set; }
        [Required]
        public DateTime ValidationDate { get; set; }
        [MaxLength(150)]
        public string Notes { get; set; }
        public IFormFile? Attachment { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
