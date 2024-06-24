using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlModelViewModels;
using Entities.ViewModels.VL.VlTypeModels;

namespace Entities.Profiles.Vl
{
    public class VlModelProfile : Profile
    {
        public VlModelProfile()
        {
            CreateMap<VlModel, VlModelGeneralVM>().ReverseMap();
        }
    }
}
