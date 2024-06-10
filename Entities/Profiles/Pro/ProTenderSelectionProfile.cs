using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSelectionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderSelectionProfile : Profile
    {
        public ProTenderSelectionProfile()
        {
            CreateMap<ProTenderSelection, ProTenderSelectionOutputVM>()
                 .ForMember(dest => dest.TenderDetailsName, cfg => cfg.MapFrom(src => src.TenderDetails.Name))
               
                .ReverseMap();
        }
    }
}
