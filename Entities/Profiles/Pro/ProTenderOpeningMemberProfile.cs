using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels;


namespace Entities.Profiles.Pro
{
    public class ProTenderOpeningMemberProfile : Profile
    {
        public ProTenderOpeningMemberProfile()
        {
            CreateMap<ProTenderOpeningMemberInputVM, ProTenderOpeningMember>();
            CreateMap<ProTenderOpeningMember, ProTenderOpeningMemberOutputVM>();
        }

    }
}
