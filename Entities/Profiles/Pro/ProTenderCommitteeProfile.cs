using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderComitteeViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderCommitteeProfile : Profile
    {
        public ProTenderCommitteeProfile()
        {
            CreateMap<ProTenderCommittee, ProTenderCommitteeOutputVM>()
                .ForMember(dest => dest.EmployeeName, cfg => cfg.MapFrom(src => src.Employee.Name))
                 .ForMember(dest => dest.TenderName, cfg => cfg.MapFrom(src => src.Tender.Name))
                  .ForMember(dest => dest.RoleName, cfg => cfg.MapFrom(src => src.Role.Name))
                .ReverseMap();
        }

    }
}
