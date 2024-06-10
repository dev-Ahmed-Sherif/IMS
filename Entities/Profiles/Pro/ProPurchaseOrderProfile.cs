using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProPurchaseOrderProfile : Profile
    {
        public ProPurchaseOrderProfile()
        {
            CreateMap<ProPurchaseOrder, ProPurchaseOrderOutputVM>()
                 .ForMember(dest => dest.TenderName, cfg => cfg.MapFrom(src => src.Tender.Name))
                   .ForMember(dest => dest.SellerName, cfg => cfg.MapFrom(src => src.Seller.Name))
                     .ForMember(dest => dest.StoreName, cfg => cfg.MapFrom(src => src.Store.Name))
                .ReverseMap();
        }
    }
}
