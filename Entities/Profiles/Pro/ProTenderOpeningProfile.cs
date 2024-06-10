using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderOpeningProfile : Profile
    {
        public ProTenderOpeningProfile()
        {
            CreateMap<ProTenderOpening, ProTenderOpeningOutputVM>()
                 .ForMember(dest => dest.SellerName, cfg => cfg.MapFrom(src => src.Seller.Name))
                  .ForMember(dest => dest.StatusName, cfg => cfg.MapFrom(src => src.Status.Name))
                .ReverseMap();
        }
    }
}
