using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderVendorReqProfile : Profile
    {
        public ProTenderVendorReqProfile()
        {
            CreateMap<ProTenderVendorReqInputVM, ProTenderVendorReq>();
            CreateMap<ProTenderVendorReq, ProTenderVendorReqOutputVM>();
        }
    }
}
