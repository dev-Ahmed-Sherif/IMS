using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningStatusViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderOpeningStatusProfile : Profile
    {
        public ProTenderOpeningStatusProfile()
        {
            CreateMap<ProTenderOpeningStatus, ProTenderOpeningStatusGeneralVM>()
                .ReverseMap();
        }
    }
}
