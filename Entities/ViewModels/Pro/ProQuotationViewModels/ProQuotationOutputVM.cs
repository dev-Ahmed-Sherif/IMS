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
    public class ProQuotationOutputVM : BaseViewModel
    {
        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int ReceiveTypeId { get; set; }
       public string ReceiveTypeName { get; set; }
        public DateTime ValidationDate { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
    }
}
