using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderSellerReqProfile : Profile
    {
        public ProTenderSellerReqProfile()
        {
            CreateMap<ProTenderSellerReq, ProTenderSellerReqInputVM>()
                .ReverseMap();

            CreateMap<ProTenderSellerReq, ProTenderSellerReqOutputVM>()
                .ForMember(dest => dest.SellerName, cfg => cfg.MapFrom(src => src.Seller.Name))
                .ForMember(dest => dest.TenderName, cfg => cfg.MapFrom(src => src.Tender.Name))
             .ReverseMap();
        }
    }
}
