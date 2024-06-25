using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderVendorReqSendTypeProfile : Profile
    {
        public ProTenderVendorReqSendTypeProfile()
        {
            CreateMap<ProTenderVendorReqSendType, ProTenderVendorReqSendTypeGeneralVM>()
                .ReverseMap();
        }
    }
}
