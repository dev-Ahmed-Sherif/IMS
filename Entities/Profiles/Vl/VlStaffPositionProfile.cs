using AutoMapper;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlStaffPosition;
using Entities.ViewModels.VL.VlStaffStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Vl
{
    public class VlStaffPositionProfile : Profile
    {
        public VlStaffPositionProfile()
        {
            CreateMap<VlModel, VlStaffPositionGeneralVM>().ReverseMap();
        }
    }
}
