using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqSendTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderSellerReqSendTypeProfile : Profile
    {
        public ProTenderSellerReqSendTypeProfile()
        {
            CreateMap<ProTenderSellerReqSendType, ProTenderSellerReqSendTypeGeneralVM>()
                .ReverseMap();
        }
    }
}
