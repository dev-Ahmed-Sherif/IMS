using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class ProTenderOpeningProfile : Profile
    {
        public ProTenderOpeningProfile()
        {
            CreateMap<ProTenderOpening, ProTenderOpeningInputVM>()
                .ReverseMap();
        }
    }
}
