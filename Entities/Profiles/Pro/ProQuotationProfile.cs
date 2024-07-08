using AutoMapper;
using Entities.Enums;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProQuotationProfile : Profile
    {
        public ProQuotationProfile()
        {
            CreateMap<ProQuotation, ProQuotationOutputVM>();
            CreateMap<ProQuotationInputVM, ProQuotation>();
        }
    }
}
