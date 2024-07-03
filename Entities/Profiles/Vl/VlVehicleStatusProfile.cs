using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlVehicleStatusViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Vl
{
    public class VlVehicleStatusProfile : Profile
    {
        public VlVehicleStatusProfile()
        {
            CreateMap<VlVehicleStatus, VlVehicleStatusGeneralVM>().ReverseMap();
        }
    }
}
