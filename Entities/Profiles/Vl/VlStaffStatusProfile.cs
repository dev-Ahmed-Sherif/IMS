using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlModelViewModels;
using Entities.ViewModels.VL.VlStaffStatus;

namespace Entities.Profiles.Vl
{
    public class VlStaffStatusProfile :Profile
    {
        public VlStaffStatusProfile()
        {
            CreateMap<VlModel, VlStaffStatusGeneralVM>().ReverseMap();
        }

    }
}
