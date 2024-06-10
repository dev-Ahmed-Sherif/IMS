using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;

namespace Entities.Profiles
{
    public class ProTenderDetailsProfile : Profile
    {
        public ProTenderDetailsProfile()
        {
            CreateMap<ProTenderDetails, ProTenderDetailsInputVM>()
                .ReverseMap();
        }
    }
}
