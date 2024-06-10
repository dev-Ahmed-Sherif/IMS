using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;

namespace Entities.Profiles.Pro
{
    public class ProTenderDetailsProfile : Profile
    {
        public ProTenderDetailsProfile()
        {
            CreateMap<ProTenderDetailsInputVM, ProTenderDetails>();
            CreateMap<ProTenderDetails, ProTenderDetailsOutputVM>();
        }
    }
}
