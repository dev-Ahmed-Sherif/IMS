using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlManufacturerViewModels;
using Entities.ViewModels.VL.VlModelViewModels;
using Entities.ViewModels.VL.VlTypeModels;

namespace Entities.Profiles.Vl
{
    public class VlManufacturerProfile : Profile
    {
        public VlManufacturerProfile()
        {
            CreateMap<VlManufacturer, VlManufacturerGeneralVM>().ReverseMap();
        }
    }
}
