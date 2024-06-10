using AutoMapper;
using Entities.Models.HR;
using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class HrSpecializationProfile : Profile
    {
        public HrSpecializationProfile()
        {
            CreateMap<HrSpecialization, HrSpecializationGetVM>()
                .ForMember(dest => dest.CreateUserName, cfg => cfg.MapFrom(src => src.CreatedBy.Name))
                .ForMember(dest => dest.UpdateUserName, cfg => cfg.MapFrom(src => src.UpdateBy.Name))
                .ForMember(dest => dest.TransactionUserId, cfg => cfg.MapFrom(src => src.CreatedByID));
        }
    }
}
