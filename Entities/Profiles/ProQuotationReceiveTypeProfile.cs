using AutoMapper;
using Entities.Enums;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationReceiveTypeViewModels;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class ProQuotationReceiveTypeProfile : Profile
    {
        public ProQuotationReceiveTypeProfile()
        {
            CreateMap<ProQuotationReceiveType, ProQuotationReceiveTypeGeneralVM>()
                .ReverseMap();
        }
    }
}
