using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Vl
{
    public class VlItineraryProfile : Profile
    {
        public VlItineraryProfile()
        {
            CreateMap<VlModel, VlModelGeneralVM>().ReverseMap();
        }
    }
}
