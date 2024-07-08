using AutoMapper.Configuration.Annotations;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace Entities.ViewModels.Pro.ProQuotationDetailsViewModels
{
    public class ProQuotationDetailsInputVM
    {
        [Required]
        public int QuotationId { get; set; }
        [Required]
        public int TenderDetailsId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        [AllowNull]
        public IFormFile Attachment { get; set; }
    }
}
