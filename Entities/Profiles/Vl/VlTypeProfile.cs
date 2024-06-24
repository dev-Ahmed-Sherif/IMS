using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlTypeModels;

namespace Entities.Profiles.Vl
{
    public class VlTypeProfile : Profile
    {
        public VlTypeProfile()
        {
            CreateMap<VlType, VlTypeGeneralVM>().ReverseMap();
        }
    }
}
