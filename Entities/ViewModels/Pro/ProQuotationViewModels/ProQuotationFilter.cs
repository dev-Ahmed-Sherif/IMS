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

namespace Entities.ViewModels.Pro.ProQuotationViewModels
{
    public class ProQuotationFilter
    {
        [AllowNull]
        public int? TenderId { get; set; }
        [AllowNull]
        public int? VendorId { get; set; }
        [AllowNull]
        public DateTime? StartReceiveDate { get; set; }
        [AllowNull]
        public DateTime? EndReceiveDate { get; set; }
        [AllowNull]
        public int? ReceiveTypeId { get; set; }
        [AllowNull]
        public DateTime? StartValidationDate { get; set; }
        [AllowNull]
        public DateTime? EndValidationDate { get; set; }
    }
}
