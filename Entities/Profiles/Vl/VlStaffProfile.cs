using AutoMapper;
using Entities.Models.Pro;
using Entities.Models.VL;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels.VL.VlStaff;
using Entities.ViewModels.VL.VlStaffStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Vl
{
    public class VlStaffProfile:Profile
    {
        public VlStaffProfile()
        {
            CreateMap<VlStaff, VlStaffInputVM>().ReverseMap();
         
            CreateMap<VlStaff, VlStaffOutputVM>().ReverseMap();
        }
    }
}
