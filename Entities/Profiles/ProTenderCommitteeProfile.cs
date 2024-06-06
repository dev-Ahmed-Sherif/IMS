using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class ProTenderCommitteeProfile : Profile
    {
        public ProTenderCommitteeProfile()
        {
            CreateMap<ProTenderCommittee, ProTenderCommitteeGeneralVM>()
                .ReverseMap();
        }

    }
}
