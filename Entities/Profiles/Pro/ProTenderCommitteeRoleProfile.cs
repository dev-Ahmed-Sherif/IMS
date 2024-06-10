using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeRoleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderCommitteeRoleProfile : Profile
    {
        public ProTenderCommitteeRoleProfile()
        {
            CreateMap<ProTenderCommitteeRole, ProTenderCommitteeRoleGeneralVM>()
                .ReverseMap();
        }
    }
}
