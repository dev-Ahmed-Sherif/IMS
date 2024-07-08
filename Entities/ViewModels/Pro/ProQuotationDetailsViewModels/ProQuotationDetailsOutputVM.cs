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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Entities.ViewModels.Pro.ProQuotationDetailsViewModels
{
    public class ProQuotationDetailsOutputVM : BaseViewModel
    {
        public int QuotationId { get; set; }
        public int TenderDetailsId { get; set; }
        public string TenderDetailsName { get; set; }
        public decimal Price { get; set; }
        public decimal TenderDetailsPrice { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
