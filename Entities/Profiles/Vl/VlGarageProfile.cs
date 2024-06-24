using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlGarageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Vl
{
    public class VlGarageProfile : Profile
    {
        public VlGarageProfile()
        {
            CreateMap<VlGarage, VlGarageGeneralVM>()
                .ReverseMap();
        }
    }
}
