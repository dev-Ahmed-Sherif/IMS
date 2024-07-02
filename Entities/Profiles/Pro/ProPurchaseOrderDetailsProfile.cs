using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class ProPurchaseOrderDetailsProfile : Profile
    {
        public ProPurchaseOrderDetailsProfile()
        {
            CreateMap<ProPurchaseOrderDetailsInputVM, ProPurchaseOrderDetails>();
            CreateMap<ProPurchaseOrderDetails, ProPurchaseOrderDetailsOutputVM>()
            .ForMember(dest => dest.TenderDetailsId, cfg => cfg.MapFrom(src => src.QuotationDetails.TenderDetailsId))
            .ForMember(dest => dest.TenderDetailsName, cfg => cfg.MapFrom(src => src.QuotationDetails.TenderDetails.Name));
        }
    }
}
